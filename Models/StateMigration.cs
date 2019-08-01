using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace StateMigration.Context
{
    public class StateMigration
    {
        public static void Run()
        {
            //Loads all data
            using (var context = new StateMigrationContext())
            {
                var states = context.States.ToList();
            }
            //Load single entity (by matching Id)
            using (var context = new StateMigrationContext())
            {
                var states = context.States
                    .Single(s => s.Id == 1);
            }
            //Filters results by name
            using (var context = new StateMigrationContext())
            {
                var states = context.States
                    .Where(s => s.Name.Contains("Oregon"))
                    .ToList();
            }
            //You can use the '.Include' method to specify related data to be included in query results.
            using (var context = new StateMigrationContext())
            {
                var movedState = context.MoveState
                    .Include(moveState => moveState.NumberMoved)
                    .ToList();
            }
            //Include related data from multiple relationships in one query
            using (var context = new StateMigrationContext())
            {
                var states = context.States
                    .Include(state => state.Id)
                    .Include(state => state.Name)
                    .ToList();
            }
            //Include multiple levels of related data using '.ThenInclude' method. You can chain multiple '.ThenInclude' calls
            using (var context = new StateMigrationContext())
            {
                var states = context.States
                    .Include(state => state.Name)
                        // .ThenInclude(moveState => moveState.StateIdFrom)
                    .ToList();
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
            // Current versions of Visual Studio offer incorrect code completion options and can cause correctexpressions to be flagged with syntax errors when using the ThenInclude method after a collection navigation property. This is a symptom of an IntelliSense bug tracked at https://github.com/dotnet/roslyn/issues/8237
            }


            //Use DbSet.Add method to add new entity class instances. Inserted into the DB on '.SaveChanges()' call
            using (var context = new StateMigrationContext())
            {
                var state = new States { Name = "State of Emergency" };
                context.States.Add(state);
                context.SaveChanges();
            }
            
            
            //EF will automatically detect changes made to existing entity's tracked by the context.
            //Simply modify the values assigned to properties and then call SaveChanges
            using (var context = new StateMigrationContext())
            {
                var state = context.States.First();
                state.Name = "State of Denial";
                context.SaveChanges();
            }
            
            
            //DbSet.Remove method to delete instances of entity classes.
            //If the entity already exists in the DB, it will be deleted with '.SaveChanges()' If not saved to DB yet, then it will be removed from the context and no longer inserted on  '.SaveChanges()'
            using (var context = new StateMigrationContext())
            {
                var state =  context.States.First();
                context.States.Remove(state);
                context.SaveChanges();
            }
            // 
            // 
            //You can combine multiple Add/Update/Remove operations into a single call to '.SaveChanges()'
            //
            using (var context = new StateMigrationContext())
            {
                // seeding DB 
                context.States.Add(new States { Name = "Laytonville" });
                context.States.Add(new States { Name = "Asheville" });
            }

            using (var context = new StateMigrationContext())
            {
                //add
                context.States.Add(new States { Name = "State of Ruin" });
                context.States.Add(new States { Name = "State of Despair" });

                //update
                var firstState = context.States.First();
                firstState.Name = "";

                //remove
                var lastState = context.States.Last();
                context.States.Remove(lastState);

                context.SaveChanges();
            }
        }
    }
}