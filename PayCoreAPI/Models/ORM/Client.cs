﻿namespace PayCoreAPI.Models.ORM
{
    public class Client : BaseEntity
    {
        public string EMail { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
