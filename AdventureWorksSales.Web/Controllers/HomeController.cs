using AdventureWorksSales.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdventureWorksSales.Web.Controllers
{
    public class HomeController : Controller
    {
        private AdventureWorksSalesEntities1 db = new AdventureWorksSalesEntities1();
        public ActionResult Index()
        {
            //var query = from s in db.SalesOrders join p in db.Products on s.ProductID equals p.ProductID where p.Name.Contains("Front Brakes")
            //            select new {s.LineTotal };
            //var TotalFrontBrake = query.Sum();

            var homeVM = new HomeViewModel
            {
                TotalOrders = db.SalesOrders.Sum(x => x.OrderQty),

                HighestLineTotal = (int)(db.SalesOrders.Max(m => m.LineTotal)),
                FrontBrakeSales = (int)(db.SalesOrders.Where(p => p.ProductID == 948).Sum(m => m.LineTotal))


            };


            return View(homeVM);
        }

    }
}