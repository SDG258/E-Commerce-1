using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class ProductValue
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? AttributeId { get; set; }
        public string AttributeValue { get; set; }

        public virtual ProductAttribute Attribute { get; set; }
        public virtual ProductEntity Product { get; set; }
    }
}
