using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TreeOfLifeDB.Models
{
    public abstract class Transaction
    {
        public int TransactionID { get; set; }
        public DateTime Date { get; set; }
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }
        public string Notes { get; set; }
    }
}