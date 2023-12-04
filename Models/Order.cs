using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<FoodItem> Items { get; set; }
        public string UserId { get; set; } // Foreign key to User
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount => Items.Sum(item => item.Price);
    }
}