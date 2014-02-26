using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TreeOfLifeDB.Models;

namespace TreeOfLifeDB.Controllers
{
    public class DonatorsController : Controller
    {
        private TreeOfLifeDBContext db = new TreeOfLifeDBContext();

        // GET: /Donators/
        public ActionResult Index()
        {
            return View(db.Donators.ToList());
        }

        // GET: /Donators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donator donator = db.Donators.Find(id);
            if (donator == null)
            {
                return HttpNotFound();
            }
            return View(donator);
        }

        // GET: /Donators/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Donators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,FirstName,LastName,Address,Zip,State,Email,Phone,Event,Amount")] Donator donator)
        {
            if (ModelState.IsValid)
            {
                db.Donators.Add(donator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donator);
        }

        // GET: /Donators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donator donator = db.Donators.Find(id);
            if (donator == null)
            {
                return HttpNotFound();
            }
            return View(donator);
        }

        // POST: /Donators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,FirstName,LastName,Address,Zip,State,Email,Phone,Event,Amount")] Donator donator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donator);
        }

        // GET: /Donators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donator donator = db.Donators.Find(id);
            if (donator == null)
            {
                return HttpNotFound();
            }
            return View(donator);
        }

        // POST: /Donators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Donator donator = db.Donators.Find(id);
            db.Donators.Remove(donator);
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
