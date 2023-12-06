using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PayCoreAPI.Models.ORM;

namespace PayCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class BaseController : ControllerBase
    {
        public PayCoreContext db;

        public BaseController()
        {
            db = new PayCoreContext();
        }
     
    }
}
