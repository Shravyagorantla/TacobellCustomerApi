using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TacobellCustomerApi.Models;

namespace TacobellCustomerApi.Repository
{
    public interface ICustomerrepo
    {
       

        public IEnumerable<FoodDetails> getfooddetails();
        public IEnumerable<OrderDetails> getOrdereddetails();
        Task<FoodDetails> UpdateQuantity(FoodDetails item, int id);

        public IEnumerable<FoodandNutrition> getnutritiondetails();

        public OrderDetails IsAlreadyOrdered(int foodId, int regId);


        Task<OrderDetails> AddOrderDetails(OrderDetails orderDetails);
        



    }
}
