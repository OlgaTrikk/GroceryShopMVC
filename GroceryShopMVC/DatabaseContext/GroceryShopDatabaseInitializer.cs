using GroceryShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace GroceryShopMVC.DatabaseContext
{
	public class GroceryShopDatabaseInitializer : DropCreateDatabaseIfModelChanges<GroceryShopDbContext>
	{
		protected override void Seed(GroceryShopDbContext context)
		{
			context.Foods.AddOrUpdate(
				x => x.Name,
				new Food
				{
					Name = "apple",
					Price = 1
				},
				new Food
				{
					Name = "bread",
					Price = 0.8
				},
				new Food
				{
					Name = "milk",
					Price = 1.1
				},
				new Food
				{
					Name = "chocolate",
					Price = 2
				},
				new Food
				{
					Name = "potatoes",
					Price = 0.6
				}
				);
		}
	}
}