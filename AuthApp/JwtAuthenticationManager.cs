using System.IdentityModel.Tokens.Jwt;

namespace AuthApp
{
    public class JwtAuthenticationManager: IJwtAuthenticationManager
    {
        public string Authenticate(string username, string password)
        {
            return string.Empty; 
        }
    }
}
