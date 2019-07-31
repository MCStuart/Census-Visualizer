using Microsoft.EntityFrameworkCore;
using StateMigration.Models;

namespace StateMigration.Data
{
    public class StateMigrationContext : DbContext
    {
        public StateMigrationContext(DbContextOptions<StateMigrationContext> options) : base(options)
        {
        }

        public DbSet<State> States { get; set; }
        public DbSet<StateMove> StateMoves { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<State>().ToTable("State");
            modelBuilder.Entity<StateMove>().ToTable("StateMove");
        }
    }
}