using System;
using Microsoft.EntityFrameworkCore;
using StateMigrations.Domain.StateMigrations;

namespace StateMigrations.Data
{
    public class StateMigrationsContext : DbContext
    {
        public StateMigrationsContext()
        {

        }
        // Entities
        public DbSet<State> States { get; set; }
        public DbSet<StateToState> StateToStates { get; set; }
    }
}
