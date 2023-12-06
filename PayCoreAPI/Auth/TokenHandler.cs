using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PayCoreAPI.Auth
{
    public class TokenHandler
    {
        public Token CreateAccessToken(string email, int id)
        {

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.UserData, id.ToString())
            };

            var token = new Token();
            token.ExpireDate = DateTime.Now.AddDays(1);

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("loremipsimloremipsimloremipsimloremipsimloremipsimloremipsimloremipsim"));

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityTokenjwtToken = new JwtSecurityToken(
                    issuer: "paycore@mail.com",
                    audience: "info@mail.com",
                    signingCredentials: signingCredentials,
                    expires: token.ExpireDate
                    //claims: claims
                );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            token.AccessToken = tokenHandler.WriteToken(jwtSecurityTokenjwtToken);

            return token;

        }
    }

    public class Token
    {
        public string AccessToken { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
