using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PersonDataApp
{
    public enum UserStatus
    {
        Active,
        Inactive,
        Banned
    }
    internal class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public UserStatus Status { get; set; }

        public Person(string firstName, string lastName, int age, float height, float weight)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Height = height;
            Weight = weight;
            Status = UserStatus.Active;
        }

    }
}


