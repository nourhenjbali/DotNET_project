using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvcp.Data;
using mvcp.Models ;
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
    [HttpGet] // Explicitly specifying the HTTP method
    public IActionResult Index()
    {
        var foodItems = _db.FoodItems.ToList();
        return View(foodItems);
    }

    [HttpGet("Create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("Create")] // Explicit route for the Create action
    public IActionResult Create(FoodItem foodItem)
        {
            if (ModelState.IsValid)
            {
                _db.FoodItems.Add(foodItem);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(foodItem);
        }
    [HttpGet("Edit/{id}")]
        public IActionResult Edit(int id)
    {
        var foodItem = _db.FoodItems.Find(id);
        if (foodItem == null)
        {
            return NotFound();
        }
        return View(foodItem);
    }
    [HttpPost("Edit/{id}")]
    public IActionResult Edit(int id, FoodItem updatedFoodItem)
    {
        var existingFoodItem = _db.FoodItems.Find(id);
        if (existingFoodItem == null)
        {
            return NotFound();
        }

        existingFoodItem.Name = updatedFoodItem.Name;
        existingFoodItem.Description = updatedFoodItem.Description;
        existingFoodItem.Price = updatedFoodItem.Price;

        _db.SaveChanges();
        return RedirectToAction("Index");
    }
         
        
    }
}