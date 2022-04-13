using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class PaymentDetail
    {
        public PaymentDetail()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public bool? Status { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
