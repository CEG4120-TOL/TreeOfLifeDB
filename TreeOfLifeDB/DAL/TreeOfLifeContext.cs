using TreeOfLifeDB.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TreeOfLifeDB.DAL
{
    public class TreeOfLifeContext : DbContext
    {
        public TreeOfLifeContext()
            : base("TreeOfLifeContext")
        {
        }

        public DbSet<ToLAccount> ToLAccounts { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Cause> Causes { get; set; }
        public DbSet<Event> Events { get; set; }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Withdrawel> Withdrawels { get; set; }
        public DbSet<Donation> Donations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}