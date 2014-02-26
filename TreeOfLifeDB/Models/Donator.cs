using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace TreeOfLifeDB.Models
{
    public class Donator
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Event { get; set; }
        public decimal Amount { get; set; }
    }

    public class TreeOfLifeDBContext : DbContext
    {
        public DbSet<Donator> Donators { get; set; }
    }
}