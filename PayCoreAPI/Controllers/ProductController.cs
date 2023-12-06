using Microsoft.AspNetCore.Mvc;
using PayCoreAPI.Models.DTO.Product.create;
using PayCoreAPI.Models.DTO.Product.get;
using PayCoreAPI.Models.ORM;

namespace PayCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        PayCoreContext db;

        public ProductController()
        {
            db = new PayCoreContext();
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            List<GetAllProductsResponseDTO> response = db.Products.Select(x => new GetAllProductsResponseDTO()
            {
                Id = x.Id,
                Name = x.Name,
                UnitPrice = x.UnitPrice,
                KDVTaxPrice = x.UnitPrice * 1.2M,
                Stock = x.Stock
            }).ToList();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = db.Products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                var response = new GetProductByIdResponseDTO();
                response.Name = product.Name;
                response.Id = product.Id;
                response.UnitPrice = product.UnitPrice;
                response.AddDate = product.AddDate;
                response.UpdateDate = product.UpdateDate;
                response.Stock = product.Stock;
                return Ok(response);
            }


        }

        [HttpPost]
        public IActionResult Create(CreateProductRequestDTO model)
        {
            Product product = new Product();
            product.Name = model.Name;
            product.UnitPrice = model.UnitPrice;

            db.Products.Add(product);
            db.SaveChanges();

            var response = new CreateProductResponseDTO();
            response.Id = product.Id;
            response.Name = product.Name;
            response.UnitPrice = product.UnitPrice;
            response.AddDate = product.AddDate;


            return StatusCode(201, response);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            //disaridan parametre olarak aldigi id ye gore urunu yakaliyorum
            var product = db.Products.FirstOrDefault(x => x.Id == id);

            if (product == null)
                return NotFound();


            db.Products.Remove(product);
            db.SaveChanges();

            return Ok();
        }

    }
}
