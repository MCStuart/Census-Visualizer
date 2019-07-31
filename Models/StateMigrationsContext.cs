using System;
using Microsoft.EntityFrameworkCore;
using StateMigrations.Domain.StateMigrations;

namespace StateMigrations.Data
{
    //Define a context class that will inherit DbContext that will be bridge from your entity/domain classes and your database.
    public class StateMigrationsContext : DbContext
    {
        //Define a parameterless constructor that will initialize itself.
        //It will have dbCOntextOptions type which will configure your Database context, then initialize your class using it.
        public StateMigrationsContext(DbContextOptions options) : base(options) { }
        //Each table will be type of DbSet for each property and contain a generic type of your entity class.
        //Then the property being name of the table.
        public DbSet<StateMigration> StateMigrations { get; set; }
    }
}
