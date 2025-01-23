using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BackEndCompas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            // Obtener el client_secret desde variables de entorno
            string clientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET");
            if (string.IsNullOrEmpty(clientSecret))
            {
                return StatusCode(500, new { message = "El client_secret no está configurado en las variables de entorno." });
            }

            var client = _httpClientFactory.CreateClient();
            var parameters = new Dictionary<string, string>
            {
                { "client_id", "BackEndCompas" }, // Nombre del cliente en Keycloak
                { "client_secret", clientSecret },
                { "username", request.Username },
                { "password", request.Password },
                { "grant_type", "password" }
            };

            var content = new FormUrlEncodedContent(parameters);

            var response = await client.PostAsync("http://localhost:8080/realms/ApiProductosRealm/protocol/openid-connect/token", content);

            if (!response.IsSuccessStatusCode)
            {
                return Unauthorized(new { message = "Credenciales inválidas o error en la autenticación." });
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            var json = JsonSerializer.Deserialize<JsonElement>(responseBody);

            return Ok(json);
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
