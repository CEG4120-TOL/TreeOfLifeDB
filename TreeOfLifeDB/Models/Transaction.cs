using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TreeOfLifeDB.Models
{
    public abstract class Transaction
    {
        public int TransactionID { get; set; }
        [Display(Name = "Date (MM/dd/yyyy)")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }
        public string Notes { get; set; }
    }
}