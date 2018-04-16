using JWT.Models;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace JWT.Service
{

    public class TokenGeneration
    {
        private const string Secret = "93948c2e214820766c7c284e0eca44e6";//should be generated from helprace sso settings

        public static string GenerateToken(Employee emp)// need the object of user for token generation
        {

            var symmetricKey = Encoding.UTF8.GetBytes(Secret);

            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                    {
                       //jti is mandatory for uniquely identifying a token
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),

                        //Iat is necessary to get the time when token was created
                        new Claim(JwtRegisteredClaimNames.Iat,(now.Second).ToString()),
                        new Claim("email",emp.Email),

                        //for a particular email external_id should be same always 
                        //new Claim("external_id",Guid.NewGuid().ToString()),
                        new Claim("name", emp.Name),
                        new Claim("organization","csharp"),
                        new Claim("orgnization_url","http://localhost:63719/"),
                        new Claim("job_title","developer"),
                        new Claim(ClaimTypes.Role,emp.Role)
                    }),

                //time for validity for token; can be customized to any value
                Expires = now.AddMinutes(Convert.ToInt32(20)),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
            
        }
    }
}
