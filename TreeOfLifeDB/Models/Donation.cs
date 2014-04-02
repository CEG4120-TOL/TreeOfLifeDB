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
        public string Type { get; set; }
        public string Status { get; set; }
        public decimal Gross { get; set; }
        public decimal Fee { get; set; }
        public decimal Net { get; set; }
    }
}