using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TacobellCustomerApi.Models
{
    public partial class PayementDetails
    {
        public int PaymentId { get; set; }
        public int? FoodId { get; set; }
        public int? OrderId { get; set; }
        public int? RegisterId { get; set; }
        public string Paymentmode { get; set; }
        public int? Paymentstatus { get; set; }

        public virtual FoodDetails Food { get; set; }
        public virtual OrderDetails Order { get; set; }
        public virtual RegisterDetails Register { get; set; }
    }
}
