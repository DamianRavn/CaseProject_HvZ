using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Utilities
{
    public static class JwtGenerator
    {
        /// <summary>
        /// Used to generate a user token for security
        /// </summary>
        /// <param name="username">the name the user logs on with</param>
        /// <returns>A secure token</returns>
        public static string GenerateUserToken(string username)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, username),
            };

            return GenerateToken(claims, DateTime.UtcNow.AddHours(8));
        }
        /// <summary>
        /// Generates the actual token
        /// </summary>
        /// <param name="claims">the claims</param>
        /// <param name="expires">when the token expires</param>
        /// <returns>A secure token</returns>
        private static string GenerateToken(Claim[] claims, DateTime expires)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            //Get secret and issuer from the environment
            var secret = Environment.GetEnvironmentVariable("JWT_SECRET");
            var issuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
            //encode the secret to make a key
            var key = Encoding.ASCII.GetBytes(secret);
            //Make a tokendescriptor using the key and HmacSha256Signature
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expires,
                Issuer = issuer,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            //Create token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            //Return token after writing it
            return tokenHandler.WriteToken(token);
        }
    }
}
