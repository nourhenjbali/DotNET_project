using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace mvcp.Data
{
    // This is the constructor for the ApplicationDbContext class 
    // The DbContext is a part of Entity Framework Core, and it represents a session with the database
    public class ApplicationDbContext : DbContext 
    {
    // to pass the argent option to the class we use the word base 
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
       {

       }
    }
}