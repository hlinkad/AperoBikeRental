using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace AperoRental.API.DataContexts { 

    public class TokenGenerator : ITokenGenerator { 
         
        private Claim[] _claims;

        private JwtSecurityTokenHandler _tokenHandler;

        private string _token;
        public TokenGenerator(int id, string username,string token){
          InitClaims(id,username);
          _token = token;
          _tokenHandler = new JwtSecurityTokenHandler();
        }

        private void InitClaims(int id, string username){
            
            Claim c1 = new Claim(ClaimTypes.NameIdentifier,id.ToString());
            Claim c2 = new Claim(ClaimTypes.Name, username);
            _claims = new []{
               c1,c2 
            };
        }

        private SymmetricSecurityKey GenerateSecurityKey(string token) {

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_token));

            return key;
        }

        public SecurityToken GenerateTokenForClient(){

            SigningCredentials loginCredentials = new SigningCredentials(GenerateSecurityKey(_token),SecurityAlgorithms.HmacSha512Signature);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(_claims),
                Expires = DateTime.Now.AddDays(1), //change this to something more appropriate later on
                SigningCredentials = loginCredentials
            };

    
            SecurityToken token = _tokenHandler.CreateToken(descriptor);
            return token;
        }

        public string WriteToken(SecurityToken token){
        
            string serializedToken = _tokenHandler.WriteToken(token);
            return serializedToken;
        }
    }
}