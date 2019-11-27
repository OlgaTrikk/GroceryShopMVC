using GroceryShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace GroceryShopMVC.DatabaseContext
{
	public class GroceryShopDbContext : DbContext
	{
		public DbSet<Food> Foods {get; set;}

		public DbSet<ShoppingCart> ShoppingCarts { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}