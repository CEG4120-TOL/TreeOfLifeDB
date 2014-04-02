using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TreeOfLifeDB.Models
{
    public class Donor : ToLAccount
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Phone]
        public string Phone { get; set; }
    }
}