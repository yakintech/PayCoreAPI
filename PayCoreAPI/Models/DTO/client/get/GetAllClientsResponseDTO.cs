namespace PayCoreAPI.Models.DTO.client.get
{
    public class GetAllClientsResponseDTO
    {
        public int Id { get; set; }
        public DateTime AddDate { get; set; }
        public string EMail { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
