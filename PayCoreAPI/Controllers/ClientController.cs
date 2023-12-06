﻿using Microsoft.AspNetCore.Mvc;
using PayCoreAPI.Models.DTO.client.create;
using PayCoreAPI.Models.DTO.client.get;
using PayCoreAPI.Models.ORM;

namespace PayCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        PayCoreContext db;

        public ClientController() { 
            db = new PayCoreContext();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<GetAllClientsResponseDTO> response = db.Clients.Select(x => new GetAllClientsResponseDTO (){ 
                Id= x.Id,
                Name= x.Name,
                EMail= x.EMail,
                Surname= x.Surname,
                Phone= x.Phone,
                AddDate= x.AddDate,
                Address= x.Address,

            }).ToList();

            return Ok(response);
        }

        [HttpPost]
        public IActionResult Crate(CreateClientRequestDto model)
        {
            var client = new Client();
            client.EMail = model.EMail;
            client.Name = model.Name;
            client.Phone = model.Phone;
            client.Surname = model.Surname;
            client.Address = model.Address;

            db.Clients.Add(client);
            db.SaveChanges();

            return Ok(client.Id);
        }
    }
}
