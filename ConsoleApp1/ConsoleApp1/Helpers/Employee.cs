using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Helpers
{
    class Employee
    {
        public int Id { get; }
        public static int _id;
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public int Salary { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public RoleType RoleType { get; set; } 

        public Employee()
        {

        }
        public Employee(string name,string surname,DateTime birthdate,int salary,string username,string password,RoleType roleType):this()
        {
            Id = ++_id;
            Name = name;
            Surname = surname;
            BirthDate = birthdate;
            Salary = salary;
            Username = username;
            Password = password;
            RoleType = roleType;
        }
    }
    enum RoleType
    {
        ADMIN,
        STAFF
    }
}
