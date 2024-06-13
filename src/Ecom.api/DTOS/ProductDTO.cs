using Ecom.core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Ecom.api.DTOS
{
    public class BaseProduct{
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Range(1,9999,ErrorMessage ="Price Must limited by {0} and {1}")]
        [RegularExpression(@"[0-9]*\.?[0-9]", ErrorMessage ="{0} must be Number !")]
        public decimal Price { get; set; }

    }
    public class ProductDTO : BaseProduct
    {
        public int Id { get; set; }
        // Navigation Property : 
        public string CategoryName { get; set; }

    }
    public class CreateProductDTO :BaseProduct
    {
        // Navigation Property : 
        public int CategoryId { get; set; }
        public IFormFile Image { get; set; }
    }
}
