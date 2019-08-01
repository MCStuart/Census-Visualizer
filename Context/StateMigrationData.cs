using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;
using StateMigration.Context;

namespace StateMigration
{
    public static class StateMigrationData
    {
        public static List<State> GetCategory()
        {
            //this sets up the db connection 
            using (var db = new StateMigrationContext())
            {
                //ToList() is a built-in method, and this is putting everything in the Category table into a list
                return db.State.ToList();
            }
        }

        public static int Create(string catName)
        {
            var db = new StateMigrationContext();
            var state = new State {Name = catName};
            db.State.Add(state);
            db.SaveChanges();
            return 1;
        }
    }
}
