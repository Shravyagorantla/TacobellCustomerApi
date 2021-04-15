using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TacobellCustomerApi.Models
{
    public partial class Nutrition
    {
        public int NuytritionId { get; set; }
        public int? FoodId { get; set; }
        public int? WeightInGrams { get; set; }
        public double? Protein { get; set; }
        public int? Calories { get; set; }
        public double? Totalsugar { get; set; }
        public double? Sodium { get; set; }
        public string Grain { get; set; }
        public string FruitorVegetable { get; set; }
        public string Dairy { get; set; }
        public string ProteinClassification { get; set; }

        public virtual FoodDetails Food { get; set; }
    }
}
