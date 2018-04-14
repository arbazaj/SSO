using JWT.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace JWT.Service
{

    public class TokenGeneration
    {
        private const string Secret = "b2c74a18abe275904d7719205acaff53";

        public static string GenerateToken(Employee emp)
        {

            var symmetricKey = Convert.FromBase64String(Secret);
            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, emp.Name),
                        new Claim(JwtRegisteredClaimNames.Email,emp.Email),
                        new Claim(JwtRegisteredClaimNames.Iat,now.ToString()),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new Claim(ClaimTypes.Role,emp.Role)
                    }),

                Expires = now.AddMinutes(Convert.ToInt32(20)),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
            
        }
    }
}
