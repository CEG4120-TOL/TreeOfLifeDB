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

namespace TreeOfLifeDB.Controllers
{
    public class WithdrawelController : Controller
    {
        private TreeOfLifeContext db = new TreeOfLifeContext();

        // GET: /Withdrawel/
        public ActionResult Index(string searchString)
        {
            var withdrawels = from d in db.Withdrawels
                            select d;

            if (!String.IsNullOrEmpty(searchString))
            {
                withdrawels = withdrawels.Where(s => s.cause.Name.Contains(searchString)
                    || s.Notes.Contains(searchString));
            }
            return View(withdrawels);
        }

        // GET: /Withdrawel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Withdrawel withdrawel = db.Withdrawels.Find(id);
            if (withdrawel == null)
            {
                return HttpNotFound();
            }
            return View(withdrawel);
        }

        private void PopulateCauseList(object selectedCause = null)
        {
            var causeQuery = from d in db.Causes
                             orderby d.Name
                             select d;
            ViewBag.CauseID = new SelectList(causeQuery, "TolAccountID", "Name", selectedCause);
        }

        // GET: /Withdrawel/Create
        public ActionResult Create()
        {
            PopulateCauseList();
            return View();
        }

        // POST: /Withdrawel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TransactionID,Date,Amount,Notes,causeID")] Withdrawel withdrawel)
        {
            if (ModelState.IsValid)
            {

                var causeName = (from g in db.Causes where g.TolAccountID == withdrawel.causeID select g).First();
                withdrawel.cause = causeName;
                causeName.Balance -= withdrawel.Amount;

                db.Transactions.Add(withdrawel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(withdrawel);
        }

        // GET: /Withdrawel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Withdrawel withdrawel = db.Withdrawels.Find(id);
            if (withdrawel == null)
            {
                return HttpNotFound();
            }
            return View(withdrawel);
        }

        // POST: /Withdrawel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="TransactionID,Date,Amount,Notes,causeID")] Withdrawel withdrawel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(withdrawel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(withdrawel);
        }

        // GET: /Withdrawel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Withdrawel withdrawel = db.Withdrawels.Find(id);
            if (withdrawel == null)
            {
                return HttpNotFound();
            }
            return View(withdrawel);
        }

        // POST: /Withdrawel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Withdrawel withdrawel = db.Withdrawels.Find(id);

            var causeName = (from g in db.Causes where g.TolAccountID == withdrawel.causeID select g).First();
            withdrawel.cause = causeName;
            causeName.Balance += withdrawel.Amount;
            
            db.Transactions.Remove(withdrawel);
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
