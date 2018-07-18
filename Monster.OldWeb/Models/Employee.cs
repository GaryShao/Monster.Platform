using Monster.OldWeb.Enums;
using System;

namespace Monster.OldWeb.Models
{
    public class Employee
    {
        public Employee(string id, string name, Gender gender, DateTime birthDate, string department)
        {
            Id = id;
            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Department = department;
        }

        public string Id { get; }
        public string Name { get; }
        public Gender Gender { get; }
        public DateTime BirthDate { get; }
        public string Department { get; }
    }
}