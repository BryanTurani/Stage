using ProveVarie.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProveVarie.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
    : base("DefaultConnection")
        { }

        public DbSet<Carnet> Carnets { get; set; }
        public DbSet<MealVoucher> MealVouchers { get; set; }
        public DbSet<CostCenter> CostCenters { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }


    }
}