using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public Category Category { get; set; }
    }
}
