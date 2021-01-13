using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace resturantwebApp.Models
{
    public class Attribute
    {
        int id;
        string name;

        public Attribute(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        public Attribute() { }



    }
}