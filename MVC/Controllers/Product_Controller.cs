using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class Product_Controller : Controller
    {
        private StoreEntities db = new StoreEntities();

        // GET: Product_
        public ActionResult Index()
        {
            return View(db.Product_.ToList());
        }

        // GET: Product_/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_ product_ = db.Product_.Find(id);
            if (product_ == null)
            {
                return HttpNotFound();
            }
            return View(product_);
        }

        // GET: Product_/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProductName,Price")] Product_ product_)
        {
            if (ModelState.IsValid)
            {
                db.Product_.Add(product_);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product_);
        }

        // GET: Product_/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_ product_ = db.Product_.Find(id);
            if (product_ == null)
            {
                return HttpNotFound();
            }
            return View(product_);
        }

        // POST: Product_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProductName,Price")] Product_ product_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product_);
        }

        // GET: Product_/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_ product_ = db.Product_.Find(id);
            if (product_ == null)
            {
                return HttpNotFound();
            }
            return View(product_);
        }

        // POST: Product_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product_ product_ = db.Product_.Find(id);
            db.Product_.Remove(product_);
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
