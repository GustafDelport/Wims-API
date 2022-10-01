using Wims.Domain.Entities;
using Wims.Domain.Interfaces;

namespace Wims.Domain.DTOs
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double SellingPrice { get; set; }
        public double CostPrice { get; set; }
        public int QtyInStock { get; set; }
        public CategoryDTO Category { get; set; }
    }
}
