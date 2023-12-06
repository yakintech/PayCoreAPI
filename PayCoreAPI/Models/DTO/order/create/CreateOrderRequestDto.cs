namespace PayCoreAPI.Models.DTO.order.create
{
    public class CreateOrderRequestDto
    {
        public int ClientId { get; set; }
        public string Address { get; set; }

        public List<OrderDetailDtoForCreateOrder> Details { get; set; }

    }

    public class OrderDetailDtoForCreateOrder
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
