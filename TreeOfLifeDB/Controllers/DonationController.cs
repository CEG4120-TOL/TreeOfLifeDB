﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TreeOfLifeDB.Models;
using TreeOfLifeDB.DAL;

namespace TreeOfLifeDB.Controllers
{
    public class DonationController : Controller
    {
        private TreeOfLifeContext db = new TreeOfLifeContext();

        // GET: /Donation/
        public ActionResult Index()
        {
            return View(db.Donations.ToList());
        }

        // GET: /Donation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = db.Donations.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            return View(donation);
        }


        public ActionResult SelectDonor(string searchString, string dropString)
        {
            var AccountLst = new List<string>();

            var AccountQry = from d in db.Donors
                             orderby d.Name
                             select d.Name;

            AccountLst.AddRange(AccountQry.Distinct());
            ViewBag.dropString = new SelectList(AccountLst);

            var donors = from d in db.Donors
                         select d;

            if (!String.IsNullOrEmpty(searchString))
            {
                donors = donors.Where(s => s.Name.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(dropString))
            {
                donors = donors.Where(x => x.Name == dropString);
            }

            //make this like others searches...
            return View();

        }

        // POST: /Donatio/SelectDonor
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SelectDonor([Bind(Include = "ToLAccountID")] Donor donor)
        {
            if (ModelState.IsValid)
            {
                //return the donor
                return RedirectToAction("Create");
            }

            return View(donor);
        }*/



        // GET: /Donation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Donation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TransactionID,Date,Amount,Notes,TaxDeductable")] Donation donation)
        {
            if (ModelState.IsValid)
            {
                db.Transactions.Add(donation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donation);
        }

        // GET: /Donation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = db.Donations.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            return View(donation);
        }

        // POST: /Donation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="TransactionID,Date,Amount,Notes,TaxDeductable")] Donation donation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donation);
        }

        // GET: /Donation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = db.Donations.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            return View(donation);
        }

        // POST: /Donation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Donation donation = db.Donations.Find(id);
            db.Transactions.Remove(donation);
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
