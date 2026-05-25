using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace VastGrid.Server.Services
{
    public class KeycloakService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<KeycloakService> _logger;

        public KeycloakService(HttpClient httpClient, IConfiguration configuration, ILogger<KeycloakService> logger)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _logger = logger;
        }

        private async Task<string> GetAdminAccessTokenAsync(string authority)
        {
            var tokenEndpoint = $"{authority}/realms/master/protocol/openid-connect/token";
            var adminPassword = _configuration["Keycloak:AdminPassword"] ?? "admin";
            var requestData = new Dictionary<string, string>
            {
                { "grant_type", "password" },
                { "client_id", "admin-cli" },
                { "username", "admin" },
                { "password", adminPassword }
            };

            var request = new HttpRequestMessage(HttpMethod.Post, tokenEndpoint)
            {
                Content = new FormUrlEncodedContent(requestData)
            };

            var response = await _httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                _logger.LogError("Failed to get Keycloak admin access token: {StatusCode} {Error}", response.StatusCode, errorContent);
                throw new Exception($"Failed to authenticate with Keycloak master realm: {response.StatusCode}");
            }

            var json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);
            return doc.RootElement.GetProperty("access_token").GetString() 
                   ?? throw new Exception("Access token not found in response.");
        }

        public async Task<string> CreateResidentUserAsync(string username, string email, string firstName, string lastName, string password)
        {
            var authority = _configuration["Keycloak:Authority"]?.TrimEnd('/');
            if (string.IsNullOrEmpty(authority))
            {
                throw new Exception("Keycloak authority is not configured.");
            }

            var adminToken = await GetAdminAccessTokenAsync(authority);

            // 1. Create the user
            var createUserUrl = $"{authority}/admin/realms/vastgrid-realm/users";
            var userPayload = new
            {
                username = username,
                email = email,
                enabled = true,
                emailVerified = true,
                firstName = firstName,
                lastName = lastName,
                credentials = new[]
                {
                    new
                    {
                        type = "password",
                        value = password,
                        temporary = false
                    }
                }
            };

            var createRequest = new HttpRequestMessage(HttpMethod.Post, createUserUrl)
            {
                Content = new StringContent(JsonSerializer.Serialize(userPayload), Encoding.UTF8, "application/json")
            };
            createRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", adminToken);

            var createResponse = await _httpClient.SendAsync(createRequest);
            if (!createResponse.IsSuccessStatusCode)
            {
                var errorContent = await createResponse.Content.ReadAsStringAsync();
                _logger.LogError("Failed to create user in Keycloak: {StatusCode} {Error}", createResponse.StatusCode, errorContent);
                throw new Exception($"Failed to create resident in Keycloak: {createResponse.StatusCode}. Details: {errorContent}");
            }

            // Extract the Keycloak User ID from the Location header
            // Keycloak returns standard Location header: .../users/{userId}
            var locationHeader = createResponse.Headers.Location;
            if (locationHeader == null)
            {
                throw new Exception("Failed to get user details: Location header was missing in creation response.");
            }

            var keycloakUserId = locationHeader.ToString().Split('/').Last();
            _logger.LogInformation("Successfully created Keycloak user. User ID: {UserId}", keycloakUserId);

            // 2. Query the role 'resident' representation to get its ID
            var getRoleUrl = $"{authority}/admin/realms/vastgrid-realm/roles/resident";
            var roleRequest = new HttpRequestMessage(HttpMethod.Get, getRoleUrl);
            roleRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", adminToken);

            var roleResponse = await _httpClient.SendAsync(roleRequest);
            if (!roleResponse.IsSuccessStatusCode)
            {
                var errorContent = await roleResponse.Content.ReadAsStringAsync();
                _logger.LogError("Failed to fetch 'resident' role representation from Keycloak: {StatusCode} {Error}", roleResponse.StatusCode, errorContent);
                throw new Exception($"Failed to fetch resident role representation: {roleResponse.StatusCode}");
            }

            var roleJson = await roleResponse.Content.ReadAsStringAsync();
            using var roleDoc = JsonDocument.Parse(roleJson);
            var roleId = roleDoc.RootElement.GetProperty("id").GetString();
            var roleName = roleDoc.RootElement.GetProperty("name").GetString();

            // 3. Map the 'resident' role to the user
            var mapRoleUrl = $"{authority}/admin/realms/vastgrid-realm/users/{keycloakUserId}/role-mappings/realm";
            var rolePayload = new[]
            {
                new
                {
                    id = roleId,
                    name = roleName
                }
            };

            var mapRoleRequest = new HttpRequestMessage(HttpMethod.Post, mapRoleUrl)
            {
                Content = new StringContent(JsonSerializer.Serialize(rolePayload), Encoding.UTF8, "application/json")
            };
            mapRoleRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", adminToken);

            var mapRoleResponse = await _httpClient.SendAsync(mapRoleRequest);
            if (!mapRoleResponse.IsSuccessStatusCode)
            {
                var errorContent = await mapRoleResponse.Content.ReadAsStringAsync();
                _logger.LogError("Failed to assign 'resident' role to user {UserId} in Keycloak: {StatusCode} {Error}", keycloakUserId, mapRoleResponse.StatusCode, errorContent);
                throw new Exception($"Failed to assign role to Keycloak user: {mapRoleResponse.StatusCode}");
            }

            _logger.LogInformation("Successfully assigned 'resident' role to Keycloak user {UserId}", keycloakUserId);
            return keycloakUserId;
        }
    }
}
