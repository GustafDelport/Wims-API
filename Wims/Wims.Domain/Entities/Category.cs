using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wims.Domain.Interfaces;

namespace Wims.Domain.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int MinThreshold { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
