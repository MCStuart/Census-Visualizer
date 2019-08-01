using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace StateMigration.Context
{
    public class PopulationChange
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
                        .ThenInclude(moveState => moveState.StateIdFrom)
                    .ToList();
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
            // Current versions of Visual Studio offer incorrect code completion options and can cause correctexpressions to be flagged with syntax errors when using the ThenInclude method after a collection navigation property. This is a symptom of an IntelliSense bug tracked at https://github.com/dotnet/roslyn/issues/8237
            }
            
        }
    }
}