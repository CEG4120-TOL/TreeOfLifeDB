﻿using System;
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
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        public string Name { get; set; }
        public string Notes { get; set; }
        [Column(TypeName = "money")]
        public decimal Balance { get; set; }
    }
}