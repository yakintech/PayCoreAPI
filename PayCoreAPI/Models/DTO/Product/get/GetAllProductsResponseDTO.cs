namespace PayCoreAPI.Models.DTO.Product.get
{
    public class GetAllProductsResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal KDVTaxPrice { get; set; }

        public DateTime AddDate { get; set; }
    }
}
