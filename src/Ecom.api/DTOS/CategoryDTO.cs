using System.ComponentModel.DataAnnotations;

namespace Ecom.api.DTOS
{
    public class CategoryDTO
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class ListingCategoryDTO : CategoryDTO
    {
        public int id { get; set; }
    }
}
