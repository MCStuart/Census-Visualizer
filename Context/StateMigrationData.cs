using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;
using StateMigration.Context;

namespace StateMigration
{
    public static class StateMigrationData
    {
        public static List<States> GetCategory()
        {
            //this sets up the db connection 
            using (var db = new StateMigrationContext())
            {
                //ToList() is a built-in method, and this is putting everything in the Category table into a list
                return db.States.ToList();
            }
        }

        public static int Create(string catName)
        {
            var db = new StateMigrationContext();
            var state = new States {Name = catName};
            db.States.Add(state);
            db.SaveChanges();
            return 1;
        }
    }
}
