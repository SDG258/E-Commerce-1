using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class CartItem
    {
        public int Id { get; set; }
        public int? SessionId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual ProductEntity Product { get; set; }
        public virtual ShoppingSession Session { get; set; }
    }
}
