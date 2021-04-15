using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TacobellCustomerApi.Models
{
    public partial class RegisterDetails
    {
        public RegisterDetails()
        {
            OrderDetails = new HashSet<OrderDetails>();
            PayementDetails = new HashSet<PayementDetails>();
        }

        public int RegisterId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<PayementDetails> PayementDetails { get; set; }
    }
}
