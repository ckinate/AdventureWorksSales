using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdventureWorksSales.Web.Models;

namespace AdventureWorksSales.Web.Controllers
{
    public class ProductCategoriesController : Controller
    {
        private AdventureWorksSalesEntities1 db = new AdventureWorksSalesEntities1();

        // GET: ProductCategories
        public ActionResult Index()
        {
            return View(db.ProductCategories.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            
            ProductCategory productCategory = db.ProductCategories.SingleOrDefault(d=>d.ProductCategoryID == id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            return View(productCategory);
        }

        // GET: ProductCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductCategoryID,Name,rowguid,ModifiedDate")] ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                db.ProductCategories.Add(productCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productCategory);
        }

        // GET: ProductCategories/Edit/5
        public ActionResult Edit(int? id)
        {
           
            ProductCategory productCategory = db.ProductCategories.SingleOrDefault(m=>m.ProductCategoryID == id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            return View(productCategory);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductCategoryID,Name,rowguid,ModifiedDate")] ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productCategory);
        }

        // GET: ProductCategories/Delete/5
        public ActionResult Delete(int? id)
        {
          
            ProductCategory productCategory = db.ProductCategories.SingleOrDefault(x=>x.ProductCategoryID==id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            return View(productCategory);
        }

        // POST: ProductCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            ProductCategory productCategory = db.ProductCategories.SingleOrDefault(m=>m.ProductCategoryID == id);
            db.ProductCategories.Remove(productCategory);
            db.SaveChanges();
            return RedirectToAction("Index");
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
