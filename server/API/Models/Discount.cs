using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Discount
    {
        public Discount()
        {
            ProductEntities = new HashSet<ProductEntity>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public double? PercentDiscount { get; set; }
        public bool? Active { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? DeleteAt { get; set; }
        public DateTime? EndDay { get; set; }

        public virtual ICollection<ProductEntity> ProductEntities { get; set; }
    }
}
