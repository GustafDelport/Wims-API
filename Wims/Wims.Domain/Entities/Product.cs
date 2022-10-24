using Wims.Domain.Interfaces;

namespace Wims.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double SellingPrice { get; set; }
        public double CostPrice { get; set; }
        public int QtyInStock { get; set; }
        public int MinThreshold { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
