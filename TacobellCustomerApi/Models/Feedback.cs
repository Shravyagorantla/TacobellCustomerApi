using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TacobellCustomerApi.Models
{
    public partial class Feedback
    {
        public int FeedbackId { get; set; }
        public string FoodName { get; set; }
        public int? FoodId { get; set; }
        public string Feedback1 { get; set; }
        public string Rating { get; set; }

        public virtual FoodDetails Food { get; set; }
    }
}
