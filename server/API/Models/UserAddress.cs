using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class UserAddress
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string AddresssLine { get; set; }
        public string Wards { get; set; }
        public string District { get; set; }
        public string City { get; set; }

        public virtual User User { get; set; }
    }
}
