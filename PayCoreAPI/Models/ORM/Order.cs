using System.ComponentModel.DataAnnotations.Schema;

namespace PayCoreAPI.Models.ORM
{
    public class Order : BaseEntity
    {
        //10 haneli random bir numara olacak
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatus { get; set; } = 0;

        public string Address { get; set; }

        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
