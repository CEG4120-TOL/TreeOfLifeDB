using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TreeOfLifeDB.Models
{
    public class Withdrawel : Transaction
    {
        public virtual Cause cause { get; set; }
    }
}