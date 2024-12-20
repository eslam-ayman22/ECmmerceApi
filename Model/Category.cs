using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EcommerceApi.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }


    }
}
