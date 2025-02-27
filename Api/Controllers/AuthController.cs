using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(IConfiguration configuration) : ControllerBase
{
    [HttpGet("login")]
    public IActionResult Login()
    {
        var clientId = configuration["GoogleOAuth:ClientId"];
        var redirectUri = "http://localhost:5050/auth/callback"; 

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
        var redirectUri = "http://localhost:5050/auth/callback"; 

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
        
        var responseString = await tokenResponse.Content.ReadAsStringAsync();
        Response.Cookies.Append("auth_token", responseString, new CookieOptions
        {
            HttpOnly = false,
            Secure = false,
            SameSite = SameSiteMode.Unspecified
        });

        return Redirect($"http://localhost:4200/callback");
    }
}