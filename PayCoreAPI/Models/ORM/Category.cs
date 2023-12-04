using System.ComponentModel.DataAnnotations;

namespace PayCoreAPI.Models.ORM
{
    public class Category : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

    }
}
