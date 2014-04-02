using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TreeOfLifeDB.Models
{
    public abstract class Transaction
    {
        public int TransactionID { get; set; }
        public DateTime Date = DateTime.Now;
        public decimal Amount { get; set; }
        public string Notes { get; set; }
    }
}