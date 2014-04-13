using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TreeOfLifeDB.Models;
using TreeOfLifeDB.DAL;
using System.Data.Entity.Infrastructure;

namespace TreeOfLifeDB.Controllers
{
    public class DonationController : Controller
    {
        private TreeOfLifeContext db = new TreeOfLifeContext();

        // GET: /Donation/
        public ActionResult Index(int? SelectedDonor)
        {
            var donors = db.Donors.OrderBy(q => q.Name).ToList();
            
            ViewBag.SelectedDonor = new SelectList(donors, "TolAccountID", "Name", SelectedDonor);
            int donorTOLID = SelectedDonor.GetValueOrDefault();

            IQueryable<Donation> donations = db.Donations
                .Where(c => !SelectedDonor.HasValue || c.donorID == donorTOLID)
                .OrderBy(d => d.TransactionID)
                .Include(d => d.donationDonor);

            var sql = donations.ToString();

            return View(donations.ToList());
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

        // GET: /Donation/Create
        public ActionResult Create()
        {
            PopulateDonorList();
            PopulateCauseList();
            PopulateEventList();
            return View();
        }

        // POST: /Donation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransactionID,Date,Amount,Notes,donorID,causeID,eventID,TaxDeductableAmount")] Donation donation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Transactions.Add(donation);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateDonorList(donation.donorID);
            PopulateCauseList(donation.causeID);
            PopulateEventList(donation.eventID);
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
            PopulateDonorList(donation.donorID);
            PopulateCauseList(donation.causeID);
            PopulateEventList(donation.eventID);
            return View(donation);
        }

        // POST: /Donation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="TransactionID,Date,Amount,Notes,donorID,causeID,eventID,TaxDeductableAmount")] Donation donation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(donation).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateDonorList(donation.donorID);
            PopulateCauseList(donation.causeID);
            PopulateEventList(donation.eventID);
            return View(donation);
        }

        private void PopulateDonorList(object selectedDonor = null)
        {
            var donorQuery = from d in db.Donors
                             orderby d.Name
                             select d;
            ViewBag.DonorID = new SelectList(donorQuery, "TolAccountID", "Name", selectedDonor);

        }

        private void PopulateCauseList(object selectedCause = null)
        {
            var causeQuery = from d in db.Causes
                             orderby d.Name
                             select d;
            ViewBag.CauseID = new SelectList(causeQuery, "TolAccountID", "Name", selectedCause);
        }

        private void PopulateEventList(object selectedEvent = null)
        {
            var eventQuery = from d in db.Events
                             orderby d.Name
                             select d;
            ViewBag.EventID = new SelectList(eventQuery, "TolAccountID", "Name", selectedEvent);
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
