using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using book.Domain.Entities;
using book.Domain.Interfaces.services;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace book.Infrastructure.Common.services
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly UserManager<User> userManager;
        private readonly AuthConfigurations config;
        public TokenGenerator(UserManager<User> userManager, AuthConfigurations config)
        {
            this.config = config;
            this.userManager = userManager;

        }
        public async Task<Token> GenerateTokenAsync(User user)
        {
            
            ;
            List<Claim> claims = await GetClaims(user) ; 
            return GenerateTokenByClaims(claims) ; 
        }


        private async Task<List<Claim>> GetClaims(User user) {
            IEnumerable<string> roles = await userManager.GetRolesAsync(user);
            List<Claim> claims = new List<Claim>()  ;
            foreach(var role in roles) {
                var claim = new Claim(ClaimTypes.Role , role) ; 
                claims.Add(claim)  ;
            }
            var idClaim = new Claim(ClaimTypes.NameIdentifier  , user.Id ) ; 
            claims.Add(idClaim) ;
            return claims ;  
        }
        private Token GenerateTokenByClaims(List<Claim> claims) {
            var tokenHandler = new JwtSecurityTokenHandler() ;
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config.Key))  ;  
            var tokenDescription = new SecurityTokenDescriptor {
                Issuer = config.Issuer , 
                
                Subject = new ClaimsIdentity(claims) , 
                Expires = DateTime.UtcNow.AddDays(config.ExpirationTime) ,
                 SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
            } ; 
            var token = tokenHandler.CreateToken(tokenDescription) ;
            return convertStringToToken(tokenHandler.WriteToken(token)) ; 
        } 
        private Token convertStringToToken(string token) {
            var tokenModel = new Token {
                Accesstoken = token
            } ;
            return tokenModel ; 
        } 
    }
}