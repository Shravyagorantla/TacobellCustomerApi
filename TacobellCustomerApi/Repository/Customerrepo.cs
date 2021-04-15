using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TacobellCustomerApi.Models;

namespace TacobellCustomerApi.Repository
{
    public class Customerrepo : ICustomerrepo
    {
        private readonly TacobellProjectContext _context;
        public Customerrepo()
        {

        }
        public Customerrepo(TacobellProjectContext context)
        {
            _context = context;
        }
        public IEnumerable<FoodDetails> getfooddetails()
        {

            return _context.FoodDetails.ToList();
        }
        public IEnumerable<OrderDetails> getOrdereddetails()
        {

            return _context.OrderDetails.ToList();
        }

        public IEnumerable<FoodandNutrition> getnutritiondetails()
        {

            List<FoodDetails> foods = _context.FoodDetails.ToList();
            List<FoodandNutrition> foodandNutritions = new List<FoodandNutrition>();
            foreach (var item in _context.Nutrition)
            {
                FoodDetails foodDetail = new FoodDetails();
                foodDetail = foods.FirstOrDefault(f => f.FoodId == item.FoodId);
                if (foodDetail != null)
                {
                    foodandNutritions.Add(new FoodandNutrition
                    {
                        NutritionId = item.NuytritionId,
                        FoodName = foodDetail.FoodName,
                        WeightInGrams = item.WeightInGrams,
                        Protein = item.Protein,
                        Calories = item.Calories,
                        Totalsugar = item.Totalsugar,
                        Sodium = item.Sodium,
                        Grain = item.Grain,
                        FruitorVegetable = item.FruitorVegetable,
                        Dairy = item.Dairy,
                        ProteinClassification = item.ProteinClassification
                    });
                }
            }
            return foodandNutritions;
        }

        public async Task<OrderDetails> AddOrderDetails(OrderDetails item)
        {
            OrderDetails fr = null;
            if (item == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                fr = new OrderDetails() {OrderId= item.OrderId, FoodId = item.FoodId, RegisterId = item.RegisterId, Address = item.Address, OrderStatus = item.OrderStatus };
                int id = _context.OrderDetails.Max(x => x.OrderId);
                fr.OrderId = id + 1;

               
                await _context.OrderDetails.AddAsync(fr);
                await _context.SaveChangesAsync();
            }
            return fr;



        }
        public async Task<FoodDetails> UpdateQuantity(FoodDetails item, int id)
        {
            FoodDetails fr = await _context.FoodDetails.FindAsync(id);
            fr.Quantity = item.Quantity;
            fr.Price = item.Price;
            fr.TotalPrice = fr.Price * fr.Quantity;
            await _context.SaveChangesAsync();

            return fr;
        }

        public OrderDetails IsAlreadyOrdered(int foodId, int regId)
        {
            OrderDetails orderDetails = _context.OrderDetails.FirstOrDefault(or => or.FoodId == foodId && or.RegisterId == regId);
            return orderDetails;
        }


    }
}

       
      











        






