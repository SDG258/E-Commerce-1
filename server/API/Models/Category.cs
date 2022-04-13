using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Category
    {
        public Category()
        {
            ProductEntities = new HashSet<ProductEntity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual ICollection<ProductEntity> ProductEntities { get; set; }
    }
}
