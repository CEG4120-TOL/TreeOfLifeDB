using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TreeOfLifeDB.Models
{
    public class Cause : ToLAccount
    {
        public string Description { get; set; }
        [Column(TypeName = "money")]
        public decimal Goal { get; set; }
        public virtual ICollection<Donation> Donations { get; set; }
        public virtual ICollection<Withdrawel> Withdrawels { get; set; }
    }
}