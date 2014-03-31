using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TreeOfLifeDB.Models;

namespace TreeOfLifeDB.DAL
{
    public class DBInit : System.Data.Entity.DropCreateDatabaseIfModelChanges<TreeOfLifeContext>
    {

        protected override void Seed(TreeOfLifeContext context)
        {
            var donors = new List<Donor>
            {
            new Donor{ Name="Joe",
                Category="Person",
                Email="joe@place.com",
                Phone="937-555-1234",
                Address="123 Fake St",
                City="Springfield",
                State="OH",
                Zip="45505",
                Total= Decimal.Parse("500.00"),
                Notes="I am fake!"
            }    
            };

            donors.ForEach(s => context.Donors.Add(s));
            context.SaveChanges();

            var causes = new List<Cause>
            {
            new Cause{
                Name="ES Wall",
                Category="Fund",
                Total= Decimal.Parse("500.00"),
                Notes="I am fake!",
                //dont need
                Balance = Decimal.Parse("500.00"),
                Goal = Decimal.Parse("1500.00"),
                Description="East Side Wall"

            }  
            };

            causes.ForEach(s => context.Causes.Add(s));
            context.SaveChanges();

            var events = new List<Event>
            {
            new Event{
                Name="Bake Sale",
                Category="Memorial Day",
                Total= Decimal.Parse("500.00"),
                Notes="I am fake!",
                Date=DateTime.Parse("27-06-2013"),
                Location="Church"
            }  
            };

            events.ForEach(s => context.Events.Add(s));
            context.SaveChanges();

        }
    }
}