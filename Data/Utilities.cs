using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Angular.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Angular.Data
{
    public static class Utilities
    {
     

       

        public static string SignJwtToken(User foundUser , IConfiguration _config)
        {
          
        // Anything we want to be encrypted in token 
                      var claims = new [] {
                          new Claim (ClaimTypes.NameIdentifier , foundUser.Id.ToString()),
                          new Claim (ClaimTypes.Name , foundUser.Username),
                      } ;

                      // A Key for decrypt and encrypt the token
                      var key = new SymmetricSecurityKey(Encoding.UTF8.
                       GetBytes(_config.GetSection("AppSettings:Token").Value));



                      // Security algorithm for engcryption
                       var creds = new SigningCredentials(key , SecurityAlgorithms.HmacSha512Signature);

                      // Boundling 
                       var tokenDescriptor = new SecurityTokenDescriptor{
                           Subject  = new ClaimsIdentity(claims),
                           Expires  = DateTime.Now.AddDays(1),
                           SigningCredentials = creds ,
                       };
                      // Creating token
                       var tokenHandler = new JwtSecurityTokenHandler(); 
                       var token = tokenHandler.CreateToken(tokenDescriptor);
                       var result = tokenHandler.WriteToken(token);
                       return result ;
                         
        }
    }
}