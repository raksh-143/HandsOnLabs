﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutstandingPerson
{
    internal abstract class Person
    {
        public string Name { get; set; }
        //public Person() { }
        public Person(string name)
        {
            Name = name;
        }
        public abstract bool IsOutstanding();
    }
}
