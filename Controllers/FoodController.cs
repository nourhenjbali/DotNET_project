using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvcp.Data;

namespace mvcp.Controllers
{
    [Route("[controller]")]
    public class FoodController : Controller
    {
        private readonly ApplicationDbContext _db; 
        
        public FoodController(ApplicationDbContext db) // constractor
        {
            _db =db ; 
        }

       

        public IActionResult Index()
        {
            var foodItems = _db.FoodItems.ToList();
            return View(foodItems);
        }

        
    }
}