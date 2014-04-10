using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TreeOfLifeDB.Models
{
    public class Event : ToLAccount
    {
        [Display(Name = "Event Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public virtual ICollection<Donation> donations { get; set; }
        public string Location { get; set; }
    }
}