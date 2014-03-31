using TreeOfLifeDB.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TreeOfLifeDB.Models;

namespace TreeOfLifeDB.DAL
{
    public class TreeOfLifeContext : DbContext
    {
        public TreeOfLifeContext()
            : base("TreeOfLifeContext")
        {
        }

        public DbSet<ToLAccount> Accounts { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Cause> Causes { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}