using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TreeOfLifeDB.Models
{
    public abstract class ToLAccount
    {
        public int TolAccountID { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        [Column(TypeName = "money")]
        public decimal Balance { get; set; }

        public string DropDownInfo
        {
            get
            {
                return Name +", ID: " + TolAccountID;
            }
        }
    }
}