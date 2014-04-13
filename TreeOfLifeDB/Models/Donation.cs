using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TreeOfLifeDB.Models
{
    public class Donation : Transaction
    {
        public int donorID { get; set; }
        public int causeID { get; set; }
        public int eventID { get; set; }

        public virtual Donor donationDonor { get; set; }
        public virtual Cause donationCause { get; set; }
        public virtual Event donationEvent { get; set; }
        [Display(Name = "Tax Deductable Amount")]
        [Column(TypeName = "money")]
        public decimal TaxDeductableAmount { get; set; }
    }
}