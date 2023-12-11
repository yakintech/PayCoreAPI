namespace PayCoreAPI.Models.DTO.Product.create
{
    public class CreateProductRequestDTO
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }

        public int Stock { get; set; }
    }
}
