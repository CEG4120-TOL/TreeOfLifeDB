using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TreeOfLifeDB.Models
{
    public class Donation : Transaction
    {
        public ICollection<Donor> Donors { get; set; }
        public ICollection<Cause> Causes { get; set; }
        public ICollection<Event> Events { get; set; }
        public decimal TaxDeductable { get; set; }
    }
}