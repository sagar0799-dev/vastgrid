using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Enable verbose JWT decoding logs to troubleshoot 401 Unauthorized errors
Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();
builder.AddRedisClientBuilder("cache")
    .WithOutputCache();

// Add services to the container.
builder.Services.AddProblemDetails();
builder.Services.AddControllers();
builder.Services.AddSignalR(); // Register SignalR
builder.Services.AddHttpClient<VastGrid.Server.Services.KeycloakService>();
builder.Services.AddScoped<VastGrid.Server.Interfaces.IManagerDashboardService, VastGrid.Server.Services.ManagerDashboardService>();
builder.Services.AddScoped<VastGrid.Server.Interfaces.IApartmentService, VastGrid.Server.Services.ApartmentService>();
builder.Services.AddScoped<VastGrid.Server.Interfaces.ITicketService, VastGrid.Server.Services.TicketService>();
builder.Services.AddScoped<VastGrid.Server.Interfaces.IBuilderService, VastGrid.Server.Services.BuilderService>();
builder.Services.AddScoped<VastGrid.Server.Interfaces.IVisitorService, VastGrid.Server.Services.VisitorService>();

builder.AddNpgsqlDbContext<VastGrid.Server.Data.VastGridDbContext>("sqldb");

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Register JwtBearer token authentication services mapped dynamically to Keycloak configuration
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var authority = builder.Configuration["Keycloak:Authority"]?.TrimEnd('/');
        if (authority != null && !authority.Contains("/realms/"))
        {
            authority = $"{authority}/realms/vastgrid-realm";
        }
        options.Authority = authority;
        options.Audience = builder.Configuration["Keycloak:Audience"] ?? "vastgrid-spa-client";
        options.RequireHttpsMetadata = false; // Allow HTTP for local Docker container environments
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false, // Relaxed for local dev environments
            ValidateIssuer = false,   // Prevents mismatch between container internal host and browser host
            ValidateLifetime = true
        };
        options.Events = new JwtBearerEvents
        {
            OnTokenValidated = context =>
            {
                var claimsIdentity = context.Principal?.Identity as System.Security.Claims.ClaimsIdentity;
                if (claimsIdentity != null)
                {
                    // Map Keycloak realm_access roles to standard role claims
                    var realmAccessClaim = claimsIdentity.FindFirst("realm_access");
                    if (realmAccessClaim != null)
                    {
                        try
                        {
                            var realmAccess = System.Text.Json.JsonDocument.Parse(realmAccessClaim.Value);
                            if (realmAccess.RootElement.TryGetProperty("roles", out var rolesElement))
                            {
                                foreach (var role in rolesElement.EnumerateArray())
                                {
                                    claimsIdentity.AddClaim(new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Role, role.GetString()!));
                                }
                            }
                        }
                        catch { /* Ignored */ }
                    }
                }
                return Task.CompletedTask;
            },
            OnAuthenticationFailed = context =>
            {
                var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Program>>();
                logger.LogError(context.Exception, "JWT Authentication failed for request at {Time}", DateTime.UtcNow);
                return Task.CompletedTask;
            }
        };
    });
builder.Services.AddAuthorization();

var app = builder.Build();

app.Logger.LogInformation("VastGrid Server built successfully. Environment: {Environment}", app.Environment.EnvironmentName);

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.Logger.LogInformation("Development environment active. Mapping OpenApi spec routes...");
    app.MapOpenApi();
}

app.Logger.LogInformation("Applying EF Core Database Migrations dynamically...");
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<VastGrid.Server.Data.VastGridDbContext>();
    db.Database.Migrate();
}

app.Logger.LogInformation("Configuring Output Cache pipelines...");
app.UseOutputCache();

app.Logger.LogInformation("Configuring Authentication & Authorization middlewares...");
app.UseAuthentication();
app.UseAuthorization();

string[] summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

var api = app.MapGroup("/api");
api.MapGet("weatherforecast", (ILogger<Program> logger) =>
{
    logger.LogInformation("Incoming request to GET /api/weatherforecast resolved.");
    logger.LogDebug("Generating {Count} day weather forecast dataset dynamically.", 5);

    var forecast = Enumerable.Range(1, 5).Select(index =>
    {
        var tempC = Random.Shared.Next(-20, 55);
        var summary = summaries[Random.Shared.Next(summaries.Length)];
        
        if (tempC > 40)
        {
            logger.LogWarning("Extreme high temperature generated: {TempC}°C ({Summary})", tempC, summary);
        }
        else if (tempC < -10)
        {
            logger.LogWarning("Extreme freezing temperature generated: {TempC}°C ({Summary})", tempC, summary);
        }

        return new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            tempC,
            summary
        );
    })
    .ToArray();

    logger.LogInformation("Successfully dispatched {Count} forecast records to the client.", forecast.Length);
    return forecast;
})
.CacheOutput(p => p.Expire(TimeSpan.FromSeconds(5)))
.WithName("GetWeatherForecast")
.RequireAuthorization(); // Secure this API route with JWT Authorization validation

app.MapDefaultEndpoints();
app.MapControllers();
app.MapHub<VastGrid.Server.Hubs.VisitorHub>("/hubs/visitor");
app.MapHub<VastGrid.Server.Hubs.TicketHub>("/hubs/ticket");

app.Logger.LogInformation("Real-time SignalR Hubs mapped at /hubs/visitor and /hubs/ticket");

app.Logger.LogInformation("Configuring Static File Server routes...");
app.UseFileServer();

app.Logger.LogInformation("VastGrid Server fully initialized. Running request listeners...");
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
