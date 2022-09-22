using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIProject.Models;

namespace APIProject.Data
{
    public class FoodContext : DbContext
    {
        public FoodContext (DbContextOptions<FoodContext> options)
            : base(options)
        {
        }


        public DbSet<APIProject.Models.UserList>? UserList { get; set; }


        public DbSet<APIProject.Models.Food>? Food { get; set; }


        public DbSet<APIProject.Models.Cart>? Cart { get; set; }
        public DbSet<APIProject.Models.OrderDetails>? OrderDetails { get; set; }
        public DbSet<APIProject.Models.OrderMaster>? OrderMaster { get; set; }
        public DbSet<APIProject.Models.NewOrder>? NewOrder { get; set; }


    }
}
