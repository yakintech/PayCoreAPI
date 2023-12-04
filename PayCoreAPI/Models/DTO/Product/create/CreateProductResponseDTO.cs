namespace PayCoreAPI.Models.DTO.Product.create
{
    public class CreateProductResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }

        public DateTime AddDate { get; set; }
    }
}
