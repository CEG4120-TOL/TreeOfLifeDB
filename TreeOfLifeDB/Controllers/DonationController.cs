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
        public ActionResult Index(string searchString)
        {
            var donations = from d in db.Donations
                         select d;

            if (!String.IsNullOrEmpty(searchString))
            {
                donations = donations.Where(s => s.donationDonor.Name.Contains(searchString)
                    || s.donationCause.Name.Contains(searchString)
                    || s.donationEvent.Name.Contains(searchString));
            }
            return View(donations);
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
                    //set the foreign keys to populate table information
                    var donorName = (from g in db.Donors where g.TolAccountID == donation.donorID select g).First();
                    donation.donationDonor = donorName;
                    donorName.Balance += donation.Amount;
                    var causeName = (from g in db.Causes where g.TolAccountID == donation.causeID select g).First();
                    donation.donationCause = causeName;
                    causeName.Balance += donation.Amount;
                    var eventName = (from g in db.Events where g.TolAccountID == donation.eventID select g).First();
                    donation.donationEvent = eventName;
                    if (donation.donationEvent != null)
                    {
                        eventName.Balance += donation.Amount;
                    }
                    

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

            ViewBag.DonorID = new SelectList(donorQuery, "TolAccountID", "DropDownInfo", selectedDonor);
        }

        private void PopulateCauseList(object selectedCause = null)
        {
            var causeQuery = from d in db.Causes
                             orderby d.Name
                             select d;
            ViewBag.CauseID = new SelectList(causeQuery, "TolAccountID", "DropDownInfo", selectedCause);
        }

        private void PopulateEventList(object selectedEvent = null)
        {
            var eventQuery = from d in db.Events
                             orderby d.Name
                             select d;
            ViewBag.EventID = new SelectList(eventQuery, "TolAccountID", "DropDownInfo", selectedEvent);
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

            //set the foreign keys to populate table information
            var donorName = (from g in db.Donors where g.TolAccountID == donation.donorID select g).First();
            donation.donationDonor = donorName;
            donorName.Balance -= donation.Amount;
            var causeName = (from g in db.Causes where g.TolAccountID == donation.causeID select g).First();
            donation.donationCause = causeName;
            causeName.Balance -= donation.Amount;
            var eventName = (from g in db.Events where g.TolAccountID == donation.eventID select g).First();
            donation.donationEvent = eventName;
            if (donation.donationEvent != null)
            {
                eventName.Balance -= donation.Amount;
            }
            

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
