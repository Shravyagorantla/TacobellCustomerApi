using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TacobellCustomerApi.Models
{
    public partial class OrderDetails
    {
        public OrderDetails()
        {
            PayementDetails = new HashSet<PayementDetails>();
        }

        public int OrderId { get; set; }
        public int? FoodId { get; set; }
        public int? RegisterId { get; set; }
        public string Address { get; set; }
        public string OrderStatus { get; set; }
       /* public DateTime Date { get; set; }*/

        public virtual FoodDetails Food { get; set; }
        public virtual RegisterDetails Register { get; set; }
        public virtual ICollection<PayementDetails> PayementDetails { get; set; }
    }
}
