using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BackEnd.Class;

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Méthode pour connecter un utilisateur
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            // 1. Vérifier si l'utilisateur existe et est authentifié (par exemple, avec la base de données)
            var user = AuthenticateUser(loginModel);

            if (user == null)
            {
                return Unauthorized("Nom d'utilisateur ou mot de passe incorrect.");
            }

            // 2. Créer un JWT pour l'utilisateur
            var token = GenerateJwtToken(user);

            return Ok(new { token });
        }

        private Personne AuthenticateUser(LoginModel loginModel)
        {
            // Logique pour authentifier l'utilisateur, par exemple, vérifier dans une base de données
            // Ici, on simule que l'utilisateur "test" existe avec un mot de passe "password"
            if (loginModel.Username == "test" && loginModel.Password == "password")
            {
                return new Personne {  Username = "test", Email = "test@example.com" }; // Tu peux remplacer avec une authentification réelle
            }

            return null;
        }

        private string GenerateJwtToken(Personne user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                // Ajouter d'autres informations d'utilisateur dans les "claims" si nécessaire
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"])); // Clé secrète pour signer le JWT
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"], 
                audience: _configuration["Jwt:Audience"], 
                claims: claims,
                expires: DateTime.Now.AddMinutes(30), 
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
