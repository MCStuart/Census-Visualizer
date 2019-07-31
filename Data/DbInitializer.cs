using StateMigration.Models;
using System;
using System.Linq;

namespace StateMigration.Data
{
    public static class DbInitializer
    {
        public static void Initialize(StateMigrationContext context)
        {
            context.Database.EnsureCreated();

            if (context.States.Any())
            {
                return;   // DB has been seeded
            }

            var states = new State[]
            {
            new State{Name="Alabama"},
            new State{Name="Alaska"},
            new State{Name="Arizona"},
            new State{Name="Arkansas"}
            };
            foreach (State s in states)
            {
                context.States.Add(s);
            }
            context.SaveChanges();

            var stateMoves = new StateMove[]
            {
            new StateMove{StateToID=1, StateFromID=1, MoveNumber=0},    
            new StateMove{StateToID=1, StateFromID=2, MoveNumber=424},
            new StateMove{StateToID=1, StateFromID=3, MoveNumber=1513},
            new StateMove{StateToID=1, StateFromID=4, MoveNumber=517},
            new StateMove{StateToID=2, StateFromID=1, MoveNumber=942},
            new StateMove{StateToID=2, StateFromID=2, MoveNumber=0},
            new StateMove{StateToID=2, StateFromID=3, MoveNumber=1387},
            new StateMove{StateToID=2, StateFromID=4, MoveNumber=203},
            new StateMove{StateToID=3, StateFromID=1, MoveNumber=1337},
            new StateMove{StateToID=3, StateFromID=2, MoveNumber=2255},
            new StateMove{StateToID=3, StateFromID=3, MoveNumber=0},
            new StateMove{StateToID=3, StateFromID=4, MoveNumber=1763},
            new StateMove{StateToID=4, StateFromID=1, MoveNumber=574},
            new StateMove{StateToID=4, StateFromID=2, MoveNumber=241},
            new StateMove{StateToID=4, StateFromID=3, MoveNumber=1060},
            new StateMove{StateToID=4, StateFromID=4, MoveNumber=0}
            };
            foreach (StateMove m in stateMoves)
            {
                context.StateMoves.Add(m);
            }
            context.SaveChanges();
        }
    }
}