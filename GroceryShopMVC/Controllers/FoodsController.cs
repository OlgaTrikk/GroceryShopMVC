using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GroceryShopMVC.DatabaseContext;
using GroceryShopMVC.Models;

namespace GroceryShopMVC.Controllers
{
    public class FoodsController : Controller
    {
        private GroceryShopDbContext db = new GroceryShopDbContext();

        // GET: Foods
        public ActionResult Index()
        {
			List<Food> foods = db.Foods.OrderBy(x => x.Name).ToList();
			return View(foods);
        }

        // GET: Foods/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }

        public ActionResult AddToCart(Guid? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Food food = db.Foods.Find(id);
			if (food == null)
			{
				return HttpNotFound();
			}
			var shoppingCart = db.ShoppingCarts.OrderByDescending(x => x.DateCreated).FirstOrDefault();
			if (shoppingCart == null)
			{
				shoppingCart = db.ShoppingCarts.Add(new ShoppingCart());
			}
			shoppingCart.AddToCart(food);
			db.SaveChanges();
			//return RedirectToAction("Index", "ShoppingCarts");
			return RedirectToAction("Details", "ShoppingCarts", new { id = shoppingCart.Id });
		}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
