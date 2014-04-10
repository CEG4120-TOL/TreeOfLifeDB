using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TreeOfLifeDB.Models
{
    public class Donation : Transaction
    {
        public virtual Donor donationDonor { get; set; }
        public virtual Cause donationCause { get; set; }
        public virtual Event donationEvent { get; set; }
        [Column(TypeName = "money")]
        public decimal TaxDeductableAmount { get; set; }
    }
}