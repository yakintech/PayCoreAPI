using Microsoft.AspNetCore.Mvc;
using PayCoreAPI.Models.ORM;

namespace PayCoreAPI.Controllers
{

    public class CategoryController : BaseController
    {
  

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Category> categories = db.Categories.ToList();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = db.Categories.FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(category);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //var category = db.Categories.FirstOrDefault(q =>q.Id == id);
            var category = db.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }
            else
            {
                db.Categories.Remove(category);
                db.SaveChanges();
                return Ok();
            }

           
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();

            //return Created("", category);
            //return StatusCode(201, category);
            return StatusCode(StatusCodes.Status201Created, category);

        }

        [HttpPut]
        public IActionResult Update(Category category)
        {
            //category varsa update et yoksa yeni ekle

            var entity = db.Categories.Any(q => q.Id == category.Id);

            if (!entity)
            {
                var newCategory = new Category();
                newCategory.Name = category.Name;
                newCategory.Description = category.Description;

                db.Categories.Add(newCategory);
                db.SaveChanges();

                return StatusCode(201, newCategory);
            }
            else
            {
                category.UpdateDate = DateTime.Now;
                db.Categories.Update(category);
                db.SaveChanges();

                return Ok(category);
            }

         
        }

        [HttpPatch]
        public IActionResult Patch(Category category)
        {
            var entity = db.Categories.Any(q => q.Id == category.Id);

            if (entity)
            {
                db.Categories.Update(category);
                db.SaveChanges();
                return Ok(category);
            }
            else
            {
                return NotFound();
            }
        }
       
    }
}
