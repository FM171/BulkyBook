using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore;

//This file creates object context for conneciton string

namespace BulkyBookWeb.Data
{
    public class ApplicationDbContext :DbContext          // This is Constructor which is a method to create classes                  
    { 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }

        public DbSet<Category> Categories { get; set; } //This is creating table name and dataset
                                                       //The table name is Categories and the table will be based of fata in Category.cs
    }
}
