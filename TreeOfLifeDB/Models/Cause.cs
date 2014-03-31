using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TreeOfLifeDB.Models
{
    public class Cause : ToLAccount
    {
        public string Description { get; set; }
        public decimal Balance { get; set; }
        public decimal Goal { get; set; }
    }
}