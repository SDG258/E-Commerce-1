using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class ProductEntity
    {
        public ProductEntity()
        {
            CartItems = new HashSet<CartItem>();
            OrderItems = new HashSet<OrderItem>();
            ProductValues = new HashSet<ProductValue>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public int? InventoryId { get; set; }
        public double? Price { get; set; }
        public int? DiscountId { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeleteAt { get; set; }

        public virtual Category Category { get; set; }
        public virtual Discount Discount { get; set; }
        public virtual Inventory Inventory { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<ProductValue> ProductValues { get; set; }
    }
}
