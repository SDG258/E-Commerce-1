using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class ShoppingSession
    {
        public ShoppingSession()
        {
            CartItems = new HashSet<CartItem>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public double? Total { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
