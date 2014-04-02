using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TreeOfLifeDB.Models
{
    public class Withdrawel : Transaction
    {
        public ICollection<Cause> Causes { get; set; }
    }
}