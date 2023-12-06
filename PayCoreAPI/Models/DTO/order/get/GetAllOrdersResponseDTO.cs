namespace PayCoreAPI.Models.DTO.order.get
{
    public class GetAllOrdersResponseDTO
    {
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string Address { get; set; }
        public GetClientForGetAllOrdersResmponseDto client { get; set; }
        public List<GetOrderDetailsForGetallOrdersResponseDto> orderDetails { get; set; }

    }

    public class GetClientForGetAllOrdersResmponseDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
    }

    public class GetOrderDetailsForGetallOrdersResponseDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
