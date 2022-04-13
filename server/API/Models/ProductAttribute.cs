using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class ProductAttribute
    {
        public ProductAttribute()
        {
            ProductValues = new HashSet<ProductValue>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProductValue> ProductValues { get; set; }
    }
}
