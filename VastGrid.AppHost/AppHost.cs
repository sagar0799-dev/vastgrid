var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var adminPassword = builder.AddParameter("keycloak-password", "admin");

// Orchestrate Keycloak container resource with pre-seeded realm configurations imported on startup
var keycloak = builder.AddKeycloak("keycloak", adminPassword: adminPassword)
    // .WithDataVolume()
    .WithRealmImport("../realms")
    .WithExternalHttpEndpoints();


var postgres = builder.AddPostgres("postgres")
    .WithDataVolume()
    .WithPgAdmin();
var sqldb = postgres.AddDatabase("sqldb");

var server = builder.AddProject<Projects.VastGrid_Server>("server")
    .WithReference(cache)
    .WithReference(keycloak)
    .WithReference(sqldb)
    .WithEnvironment("Keycloak__Authority", keycloak.GetEndpoint("http"))
    .WithEnvironment("Keycloak__Audience", "vastgrid-spa-client")
    .WithEnvironment("Keycloak__AdminPassword", adminPassword)
    .WaitFor(cache)
    .WaitFor(sqldb)
    .WithHttpHealthCheck("/health")
    .WithExternalHttpEndpoints();

var webfrontend = builder.AddViteApp("webfrontend", "../frontend")
    .WithReference(server)
    .WithReference(keycloak)
    .WithEnvironment("VITE_KEYCLOAK_URL", keycloak.GetEndpoint("http"))
    .WithEnvironment("VITE_ENABLE_KEYCLOAK", "true")
    .WaitFor(server);

server.PublishWithContainerFiles(webfrontend, "wwwroot");

builder.Build().Run();
