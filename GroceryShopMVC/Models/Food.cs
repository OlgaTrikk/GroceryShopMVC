using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroceryShopMVC.Models
{
	public class Food
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public double Price { get; set; }

		public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }

		public Food()
		{
			Id = Guid.NewGuid();	
		}
	}
}