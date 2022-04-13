using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class OrderDetail
    {
        public OrderDetail()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public double? Total { get; set; }
        public DateTime? CreateAt { get; set; }
        public int? PaymentId { get; set; }

        public virtual PaymentDetail Payment { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
