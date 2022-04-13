using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class User
    {
        public User()
        {
            OrderDetails = new HashSet<OrderDetail>();
            ShoppingSessions = new HashSet<ShoppingSession>();
            UserAddresses = new HashSet<UserAddress>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime? CreateAt { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ShoppingSession> ShoppingSessions { get; set; }
        public virtual ICollection<UserAddress> UserAddresses { get; set; }
    }
}
