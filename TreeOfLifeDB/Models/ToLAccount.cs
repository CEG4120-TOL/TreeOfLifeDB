﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TreeOfLifeDB.Models
{
    public abstract class ToLAccount
    {
        public int ID { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public decimal Total { get; set; }
    }
}