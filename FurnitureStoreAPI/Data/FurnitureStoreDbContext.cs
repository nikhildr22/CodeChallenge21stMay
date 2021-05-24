using FurnitureStoreAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureStoreAPI.Data
{
    public class FurnitureStoreDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Furniture> Furnitures { get; set; }
        public DbSet<CustomerFurniture> CustomerFurnitures { get; set; }

        public FurnitureStoreDbContext(DbContextOptions<FurnitureStoreDbContext> options):base(options)
        {

        }

        
    }
}
