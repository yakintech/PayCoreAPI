﻿namespace PayCoreAPI.Models.DTO.client.create
{
    public class CreateClientRequestDto
    {
        public string EMail { get; set; }

        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
