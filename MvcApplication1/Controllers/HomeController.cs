using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProiectIEP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Titlu schimbat";
            ViewBag.RightContentTitle = "Latest Restaurants";
            ViewBag.RightContentContent = "<ul><li>1</li><li>2</li><li>3</li><li>4</li><li>5</li></ul><a class=\"yellow-button\"><span>See Menu</span></a>";
            return View();
        }

    }
}
