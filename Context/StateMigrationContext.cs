using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace StateMigration.Context
{
    public class StateMigrationContext : DbContext
    {
        public DbSet<States> States { get; set; }
        public DbSet<MoveState> MoveState { get; set; }

        private StateMigrationContext Create(string basePath, string environmentName)
        {
        var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
        .SetBasePath(basePath)
        .AddJsonFile("appsettings.json")
        .AddJsonFile($"appsettings.{environmentName}.json", true)
        .AddEnvironmentVariables();

        var config = builder.Build();

        var connstr = config.GetConnectionString("(default)");

        if (String.IsNullOrWhiteSpace(connstr) == true)
        {
        throw new InvalidOperationException(
        "Could not find a connection string named '(default)'.");
        }
        else
        {
        return Create(connstr);
        }
    }
    public class States
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
