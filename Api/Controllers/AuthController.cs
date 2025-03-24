using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Core.Entities;
using Core.Interfaces;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(
    IConfiguration configuration,
    IAuthRepository repository
    ) : ControllerBase
{
    [HttpGet("login")]
    public IActionResult Login()
    {
        var clientId = configuration["GoogleOAuth:ClientId"];
        var redirectUri = "https://localhost:5050/auth/callback"; 

        var googleAuthUrl = $"https://accounts.google.com/o/oauth2/auth?" +
                            $"client_id={clientId}&" +
                            $"redirect_uri={redirectUri}&" +
                            $"response_type=code&" +
                            $"scope=email%20profile%20https://www.googleapis.com/auth/drive.file&" +
                            $"access_type=offline";

        return Redirect(googleAuthUrl);
    }

    [HttpGet("callback")]
    public async Task<IActionResult> Callback([FromQuery] string code)
    {
        if (string.IsNullOrEmpty(code))
        {
            return BadRequest("Código de autorización no proporcionado.");
        }

        var clientId = configuration["GoogleOAuth:ClientId"];
        var clientSecret = configuration["GoogleOAuth:ClientSecret"];
        var redirectUri = "https://localhost:5050/auth/callback"; 

        using var httpClient = new HttpClient();
        var tokenResponse = await httpClient.PostAsync("https://oauth2.googleapis.com/token",
            new FormUrlEncodedContent(new Dictionary<string, string>
            {
                {"code", code},
                {"client_id", clientId},
                {"client_secret", clientSecret},
                {"redirect_uri", redirectUri},
                {"grant_type", "authorization_code"}
            }));
        
        if (!tokenResponse.IsSuccessStatusCode)
        {
            return BadRequest("Error obteniendo el token de Google.");
        }

        var responseJson = await tokenResponse.Content.ReadAsStringAsync();
        var tokenData = JsonSerializer.Deserialize<GoogleTokenResponse>(responseJson);
        if (tokenData == null || string.IsNullOrEmpty(tokenData.id_token))
        {
            return BadRequest(responseJson);
        }

        var payload = await GoogleJsonWebSignature.ValidateAsync(tokenData.id_token);
        var email = payload.Email;

        var user = await repository.GetUserByEmailWithRole(email);

        if (user == null)
        {
            user = await repository.RegisterUser(new User()
            {
                Email = email,
                Name = payload.Name,
                AvatarUrl = payload.Picture,
                RoleId = 2,
                Birthday = new DateOnly(DateTime.UtcNow.Year - 13, DateTime.UtcNow.Month, DateTime.UtcNow.Day),
            });
        }
        
        if (user.Role == null)
        {
            user = await repository.GetUserByEmailWithRole(email);
        }
        
        if (user == null || user.Role == null) return Problem("error al recuperar el usuario");
        var role = user.Role.RoleName;

        var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(tokenData.id_token);
        UserTokenInfo userInfo = new UserTokenInfo()
        {
            at_hash = jwtToken.Claims.FirstOrDefault(c => c.Type == "at_hash")?.Value,
            aud = jwtToken.Claims.FirstOrDefault(c => c.Type == "aud")?.Value,
            azp = jwtToken.Claims.FirstOrDefault(c => c.Type == "azp")?.Value,
            email = email,
            email_verified = jwtToken.Claims.FirstOrDefault(c => c.Type == "email_verified")?.Value == "true",
            exp = long.Parse(jwtToken.Claims.FirstOrDefault(c => c.Type == "exp")?.Value ?? "0"),
            family_name = jwtToken.Claims.FirstOrDefault(c => c.Type == "family_name")?.Value,
            given_name = jwtToken.Claims.FirstOrDefault(c => c.Type == "given_name")?.Value,
            iat = long.Parse(jwtToken.Claims.FirstOrDefault(c => c.Type == "iat")?.Value ?? "0"),
            iss = jwtToken.Claims.FirstOrDefault(c => c.Type == "iss")?.Value,
            name = jwtToken.Claims.FirstOrDefault(c => c.Type == "name")?.Value,
            picture = jwtToken.Claims.FirstOrDefault(c => c.Type == "picture")?.Value,
            sub = jwtToken.Claims.FirstOrDefault(c => c.Type == "sub")?.Value
        };
        var generateJwtToken = GenerateJwtToken(userInfo, email, role);

        Response.Cookies.Append("auth_token", generateJwtToken, new CookieOptions
        {
            HttpOnly = false,
            Secure = false,
            SameSite = SameSiteMode.Lax
        });

        return Redirect($"https://localhost:4200/callback");
    }
    private string GenerateJwtToken(UserTokenInfo userInfo, string email, string role)
    {
        var secretKey = configuration["Jwt:SecretKey"];
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim("at_hash", userInfo.at_hash ?? ""),
            new Claim("aud", userInfo.aud ?? ""),
            new Claim("azp", userInfo.azp ?? ""),
            new Claim("email", userInfo.email ?? ""),
            new Claim("email_verified", userInfo.email_verified.ToString().ToLower()),
            new Claim("exp", userInfo.exp.ToString()),
            new Claim("family_name", userInfo.family_name ?? ""),
            new Claim("given_name", userInfo.given_name ?? ""),
            new Claim("iat", userInfo.iat.ToString()),
            new Claim("iss", userInfo.iss ?? ""),
            new Claim("name", userInfo.name ?? ""),
            new Claim("picture", userInfo.picture ?? ""),
            new Claim("sub", userInfo.sub ?? ""),
            new Claim("role", role)
        };

        var newToken = new JwtSecurityToken(
            issuer: "https://accounts.google.com",
            audience: userInfo.aud,
            claims: claims,
            expires: DateTime.UtcNow.AddDays(7),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(newToken);
    }
    
    public class GoogleTokenResponse
    {
        public string access_token { get; set; }
        public string id_token { get; set; }
    }
    public class UserTokenInfo
    {
        public string at_hash { get; set; }
        public string aud { get; set; }
        public string azp { get; set; }
        public string email { get; set; }
        public bool email_verified { get; set; }
        public long exp { get; set; }
        public string family_name { get; set; }
        public string given_name { get; set; }
        public long iat { get; set; }
        public string iss { get; set; }
        public string name { get; set; }
        public string picture { get; set; }
        public string sub { get; set; }
        public string role { get; set; }
    }
}