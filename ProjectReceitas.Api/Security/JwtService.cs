using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProjectReceitas.Api.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReceitas.Api.Security
{
    public class JwtService
    {
        private readonly IConfiguration Configuration;

        public JwtService(IConfiguration config)
        {
            Configuration = config;
        }

        public string AutenticarUsuarioJwt(UserLogin user)
        {
            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.User),
                    new Claim("ProjectReceitas", "user")
                }),
                Issuer = Configuration["Jwt:Issuer"],
                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
