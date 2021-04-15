using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TacobellCustomerApi.Models;
using TacobellCustomerApi.Repository;

namespace TacobellCustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        //private readonly tacobellContext _context;

        private readonly ICustomerrepo _context;
        private IQueryable<OrderDetails> order;

        public object ViewData { get; private set; }

        public CustomerController(ICustomerrepo context)
        {
            _context = context;
        }

        //[HttpGet("GetFoodDetails")]
        //public async Task<ActionResult<IEnumerable<FoodDetails>>> GetFoodDetails()
        //{
        //    return await _context.FoodDetails.ToListAsync();
        //}

        [HttpGet]
        public IEnumerable<FoodDetails> GetFoodDetails()
        {

            return _context.getfooddetails();
        }


        //[HttpGet("GetNutritionDetails")]
        //public IEnumerable<Nutrition> GetNutritionDetails()
        //{

        //    return _context.getnutritiondetails();
        //}

        [HttpGet("GetNutritionDetails")]
        public IEnumerable<FoodandNutrition> GetNutritionDetails()
        {
            return _context.getnutritiondetails();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFoodDetails(FoodDetails foodDetails,int id)
        {
            if (id != foodDetails.FoodId)
            {
                return BadRequest();
            }

            //_context.Entry(foodDetails).State = EntityState.Modified;

            try
            {
                await _context.UpdateQuantity(foodDetails, id);
            }
            catch (Exception err)
            {
                var errormessage=err.Message;
            }

            return NoContent();
        }
        /*[HttpGet("Getorderperid")]
        public IQueryable<object> Getorderperid()
        {
            return _context.getorderperid();

        }*/




        //// GET: api/OrderDetails
        //[HttpGet("GetOrderDetails")]
        //public async Task<ActionResult<IEnumerable<OrderDetails>>> GetOrderDetails()
        //{
        //    return await _context.OrderDetails.ToListAsync();
        //}


        [HttpGet("IsAlreadyOrdered/{foodId},{regId}")]

        public OrderDetails IsAlreadyOrdered(int foodId, int regId)
        {
            OrderDetails od = _context.IsAlreadyOrdered(foodId, regId);
            return od;
        }
        [HttpPost]
        public async Task<ActionResult<OrderDetails>> PostOrderDetails(OrderDetails orderDetails)
        {
            
            OrderDetails od = await _context.AddOrderDetails(orderDetails);
            return Ok(od);
           
        }

        //private bool OrderDetailsExists(int id)
        //{
        //    return _context.OrderDetails.Any(e => e.OrderId == id);
        //}



        



    }
}
