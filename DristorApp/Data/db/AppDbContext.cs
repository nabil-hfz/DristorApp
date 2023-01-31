﻿using System;
using System.Configuration;
using DristorApp.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static NuGet.Packaging.PackagingConstants;

namespace DristorApp.Data.db
{
	public class AppDbContext : IdentityDbContext<User, Role, int>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) :
			base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            //optionsBuilder.UseSqlServer(@"Stringul de Conexiune");
            base.OnConfiguring(optionsBuilder);

			optionsBuilder.EnableSensitiveDataLogging();
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			//builder
			//	.Entity<OrderStatusUpdate>()
			//	.HasOne(e => e.Order)
			//	.WithMany(e => e.OrderStatusUpdates)
			//	.OnDelete(DeleteBehavior.Cascade);


			//builder
			//	.Entity<OrderItem>()
			//	.HasOne(oi => oi.Coupon)
			//	.WithMany(c => c.OrderItem)
			//	.OnDelete(DeleteBehavior.SetNull);
		}

		public DbSet<Ingredient> Ingredients {set; get;}

        public DbSet<Product> Products { set; get; }

        public DbSet<ProductVariant> ProductVariants { set; get; }

        public DbSet<Token> Tokens { set; get; }

		public DbSet<Address> Addresses { set; get; }

        public DbSet<Order> Orders { set; get; }

        public DbSet<OrderStatusUpdate> OrderStatusUpdates { set; get; }

        public DbSet<OrderItem> OrderItems { set; get; }

        public DbSet<CartItem> CartItems { set; get; }

        public DbSet<Coupon> Coupons { set; get; }

        public DbSet<User> SysUser { set; get; }

        public DbSet<Role> Roles { set; get; }

    }
}


// Install-Package Microsoft.AspNetCore.Identity.EntityFrameworkCore

