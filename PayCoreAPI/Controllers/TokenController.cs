using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PayCoreAPI.Models.DTO.token;
using PayCoreAPI.Models.ORM;

namespace PayCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        PayCoreContext db;
        public TokenController()
        {
            db = new PayCoreContext();
        }

        [HttpPost]
        public IActionResult Login(LoginRequestModel loginRequestModel)
        {
            //email ve sifre dogruya kullaniciya token verecegim!

            var user = db.Clients.FirstOrDefault(q => q.EMail== loginRequestModel.EMail && q.Password == loginRequestModel.Password);

            if (user == null)
            {
                return NotFound();
            }
            else
            {
                PayCoreAPI.Auth.TokenHandler tokenHandler = new PayCoreAPI.Auth.TokenHandler();
                var token = tokenHandler.CreateAccessToken(user.EMail, user.Id);

                return Ok(token);
            }

           
        }
    }
}
