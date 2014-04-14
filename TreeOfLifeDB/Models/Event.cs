using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TreeOfLifeDB.Models
{
    public class Event : ToLAccount
    {
        [Display(Name = "Date (MM/dd/yyyy)")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public virtual ICollection<Donation> donations { get; set; }
        public string Location { get; set; }
    }
}