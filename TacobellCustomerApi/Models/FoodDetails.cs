using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TacobellCustomerApi.Models
{
    public partial class FoodDetails
    {
        public FoodDetails()
        {
            Feedback = new HashSet<Feedback>();
            Nutrition = new HashSet<Nutrition>();
            OrderDetails = new HashSet<OrderDetails>();
            PayementDetails = new HashSet<PayementDetails>();
        }

        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
        public string Imageurl { get; set; }
        public double? TotalPrice { get; set; }

        public virtual ICollection<Feedback> Feedback { get; set; }
        public virtual ICollection<Nutrition> Nutrition { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<PayementDetails> PayementDetails { get; set; }
    }
}
