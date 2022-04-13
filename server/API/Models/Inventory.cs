using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Inventory
    {
        public Inventory()
        {
            ProductEntities = new HashSet<ProductEntity>();
        }

        public int Id { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeleteAt { get; set; }

        public virtual ICollection<ProductEntity> ProductEntities { get; set; }
    }
}
