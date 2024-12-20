using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApi.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; }
        public string? Img { get; set; }
        public double price { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

    }
}
