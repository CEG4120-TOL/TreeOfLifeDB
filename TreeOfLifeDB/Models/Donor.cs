using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TreeOfLifeDB.Models
{

    public enum State
    {
        AK, AL, AR, AZ, CA, CO, CT, DC, DE, FL, GA, HI, IA, ID, IL, IN, KS, KY, LA, MA, MD, ME, MI, MN, MO, MS, MT, NC, ND, NE, NH, NJ, NM, NV, NY, OH, OK, OR, PA, RI, SC, SD, TN, TX, UT, VA, VT, WA, WI, WV, WY
    }

    public class Donor : ToLAccount
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        [Phone]
        public string Phone { get; set; }
        public virtual ICollection<Donation> donations { get; set; }
    }
}