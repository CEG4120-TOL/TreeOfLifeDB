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
            //add dummy data here with a loop...
        }
    }
}