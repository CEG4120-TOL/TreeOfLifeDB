using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TreeOfLifeDB.Models
{
    public class Withdrawel : Transaction
    {
        public int? causeID { get; set; }
        public virtual Cause cause { get; set; }
    }
}