using Microsoft.AspNetCore.Mvc;
using PayCoreAPI.Models.DTO.order.create;
using PayCoreAPI.Models.DTO.order.get;
using PayCoreAPI.Models.ORM;

namespace PayCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        PayCoreContext db;

        public OrderController()
        {
            db = new PayCoreContext();
        }

        [HttpGet]
        public IActionResult GetAllOrders() 
        {
            var data = db.Orders;

            var response = db.Orders.Select(q => new GetAllOrdersResponseDTO()
            {
                OrderDate= q.OrderDate,
                Address= q.Address,
                OrderNumber = q.OrderNumber,
                client = new GetClientForGetAllOrdersResmponseDto()
                {
                    Name = q.Client.Name,
                    Surname = q.Client.Surname,
                    Phone = q.Client.Phone,
                },
                orderDetails = q.OrderDetails.Select(x => new GetOrderDetailsForGetallOrdersResponseDto()
                {
                    ProductId= x.ProductId,
                    Quantity=x.Quantity

                }).ToList(),
            }).ToList();


            return Ok(response);

        }

        [HttpPost]
        public IActionResult Create(CreateOrderRequestDto model)
        {
            var order = new Order();
            order.ClientId = model.ClientId;
            order.Address = model.Address;

            var random = new Random();
            var orderNumber = random.Next(1,100000);
            order.OrderNumber = orderNumber;

            db.Orders.Add(order);
            db.SaveChanges();


            foreach (var item in model.Details)
            {
                var detail = new OrderDetail();
                detail.OrderId = order.Id;
                detail.ProductId = item.ProductId;
                
                var product = db.Products.Find(item.ProductId);

                detail.UnitPrice = product.UnitPrice;

                db.OrderDetails.Add(detail);
                db.SaveChanges();
            }

            return Ok(order.Id);

        }
    }
}
