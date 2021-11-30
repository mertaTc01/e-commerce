using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Data
{

    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ) : base(options)
        {

        }
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BuyerBasket>().HasKey(am => new
            {
                am.BuyerId,
                am.ProductId
            });

            modelBuilder.Entity<BuyerBasket>().HasOne(m => m.Buyer).WithMany(am => am.BuyerBaskets).HasForeignKey(m => m.BuyerId);

            modelBuilder.Entity<BuyerBasket>().HasOne(m => m.Product).WithMany(am => am.BuyerBaskets).HasForeignKey(m => m.ProductId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<BuyerBasket> BuyerBaskets { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Product> Products { get; set; }

    }

}