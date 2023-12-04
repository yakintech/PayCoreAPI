using Microsoft.AspNetCore.Mvc;
using PayCoreAPI.Models;

namespace PayCoreAPI.Controllers
{
    //GET - POST - PUT - DELETE
    //Asagidaki controller icerisinde bulunan metotlara erismek icin api/webuser rotasini kullanacagim

    [Route("api/[controller]")]
    [ApiController]
    public class WebUserController : ControllerBase
    {
        List<WebUser> _users;

        public WebUserController()
        {
            _users= new List<WebUser>();

            _users.Add(new WebUser()
            {
                Id= 1,
                Email = "cagatay@mail.com",
                Name = "Cagatay"
            });

            _users.Add(new WebUser()
            {
                Id = 2,
                Email = "ahmet@mail.com",
                Name = "Ahmet"
            });

            _users.Add(new WebUser()
            {
                Id = 3,
                Email = "muge@mail.com",
                Name = "Muge"
            });
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_users);
        }

        //api/webuser/5

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);
            
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }


        [HttpDelete("{id}")] 
        public IActionResult Delete(int id)
        {
            var webuser = _users.FirstOrDefault(q => q.Id == id);

            if (webuser == null)
            {
                return NotFound();
            }
            else
            {
                _users.Remove(webuser);

                return Ok(_users);
            }
        }


        [HttpPost]
        public IActionResult Create(WebUser user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            else
            {
                user.Id = _users.Count + 1;
                _users.Add(user);
                return Ok(_users);
            }
        }

        [HttpPut]
        public IActionResult Put(WebUser user)
        {
            var webUser = _users.FirstOrDefault(q => q.Id == user.Id);
            //update operation
            return Ok("");
        }

    }
}
