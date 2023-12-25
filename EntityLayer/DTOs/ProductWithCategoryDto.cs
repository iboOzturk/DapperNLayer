using EntityLayer.Concrete;

namespace EntityLayer.DTOs
{
    public class ProductWithCategoryDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public Category Category { get; set; }
    }
}
