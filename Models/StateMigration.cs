using Microsoft.EntityFrameworkCore;
using StateMigrations.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StateMigrations.Domain.StateMigrations
{
    //Have all your domain classes extend the entity class.
    //Entity classes are a abstract class that has characteristics that all domain models have or will inherit.
    public class StateMigration : Entity
    {
        //Define your constructor for creating and updating from database
        //Will use it to convert a view model to a domain model in our services to use as a argument to our repository to create new data.
        public StateMigration(string stateFrom, string stateTo, int movedFrom, int movedTo, int movementNet)
        {
            StateFrom = stateFrom;
            StateTo = stateTo;
            MovedFrom = movedFrom;
            MovedTo = movedTo;
            MovementNet = movementNet;
        }
        //Your StateMigrations Table will have a column with a id(inherited from the entity class) with a type of integer
        public string StateFrom { get; set; }
        public string StateTo { get; set; }
        public int MovedFrom { get; set; }
        public int MovedTo { get; set; }
        public int MovementNet { get; set; }
    }
}
