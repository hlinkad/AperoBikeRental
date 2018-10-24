using Microsoft.IdentityModel.Tokens;

namespace AperoRental.API.DataContexts
{
    public interface ITokenGenerator
    {
       SecurityToken GenerateTokenForClient();

       string WriteToken(SecurityToken token);

       
    }
}