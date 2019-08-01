using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace StateMigration.Context
{

    public class StateMigrationContext : DbContext
    {

        public DbSet<State> State { get; set; }
        public DbSet<MoveState> MoveState { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseMySQL("server=localhost;database=StateMigration;user=root;password=root;port=8889;");
		}
    }

    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class MoveState
    {
        public int Id { get; set; }
        public int StateIdTo { get; set; }
        public int StateIdFrom { get; set; }
        public int NumberMoved { get; set; }
    }
}