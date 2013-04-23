using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProiectIEP.Models;

namespace ProiectIEP.Controllers
{
    public class RestaurantController : Controller
    {
        private RestaurantContext db = new RestaurantContext();

        //
        // GET: /Restaurant/

        public ActionResult Index()
        {

            var restaurants = db.Restaurants.Include(r => r.User).Include(r => r.Cuisine);
            return View(restaurants.ToList());
        }

        // GET: /Restaurant/Search

        public ActionResult Search(string name, string cuisine, string city, string county, string country)
        {

            var restaurants = db.Restaurants.Include(r => r.User).Include(r => r.Cuisine);

                if (!string.IsNullOrEmpty(name))
                {
                    restaurants = (from x in restaurants
                             where x.RestName.ToLower().Contains(name.ToLower())
                             select x);
                }

                if (!string.IsNullOrEmpty(cuisine))
                {
                    restaurants = (from x in restaurants
                                   where x.Cuisine.CuisineName.ToLower().Contains(cuisine.ToLower())
                                   select x);
                }

                if (!string.IsNullOrEmpty(city))
                {
                    restaurants = (from x in restaurants
                                   where x.City.ToLower().Contains(city.ToLower())
                                   select x);
                }

                if (!string.IsNullOrEmpty(county))
                {
                    restaurants = (from x in restaurants
                                   where x.County.ToLower().Contains(county.ToLower())
                                   select x);
                }

                if (!string.IsNullOrEmpty(country))
                {
                    restaurants = (from x in restaurants
                                   where x.Country.ToLower().Contains(country.ToLower())
                                   select x);
                }
            
            return View(restaurants.ToList());
        }

        //
        // GET: /Restaurant/Details/5

        public ActionResult Details(int id = 0)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        //
        // GET: /Restaurant/Create

        public ActionResult Create()
        {

            ViewBag.CuisineId = new SelectList(db.Cuisines, "CusineId", "CuisineName");
            return View();
        }

        //
        // POST: /Restaurant/Create

        [HttpPost]
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                restaurant.UserId = (int)Session["userID"];
                db.Restaurants.Add(restaurant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CuisineId = new SelectList(db.Cuisines, "CusineId", "CuisineName", restaurant.CuisineId);
            return View(restaurant);
        }

        //
        // GET: /Restaurant/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }

            ViewBag.CuisineId = new SelectList(db.Cuisines, "CusineId", "CuisineName", restaurant.CuisineId);
            return View(restaurant);
        }

        //
        // POST: /Restaurant/Edit/5

        [HttpPost]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CuisineId = new SelectList(db.Cuisines, "CusineId", "CuisineName", restaurant.CuisineId);
            return View(restaurant);
        }

        //
        // GET: /Restaurant/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        //
        // POST: /Restaurant/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}