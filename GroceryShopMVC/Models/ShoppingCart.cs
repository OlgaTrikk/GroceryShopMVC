using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroceryShopMVC.Models
{
	public class ShoppingCart
	{
		public Guid Id { get; set; }

		public double Sum { get; set; }

		public DateTime DateCreated { get; private set; }

		public virtual ICollection<Food> Items { get; set; }

		public ShoppingCart()
		{
			Id = Guid.NewGuid();
			Sum = 0;
			DateCreated = DateTime.Now;
			Items = new List<Food>();
		}

		public void AddToCart(Food food)
		{
			Items.Add(food);
			Sum += food.Price;
		}
	}
}