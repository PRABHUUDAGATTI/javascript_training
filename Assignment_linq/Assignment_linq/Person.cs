using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_linq
{
    public class Person
    {
        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName + " " + Age;
        }
    }
}
