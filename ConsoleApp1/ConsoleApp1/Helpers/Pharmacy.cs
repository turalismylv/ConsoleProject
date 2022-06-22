using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Helpers
{
    class Pharmacy
    {
        public int Id { get; }
        public static int _id;
        public string Name { get; set; }
        
        public int MinSalary { get; set; }
        public int Budget { get; set; }
        public string  Location { get; set; }
        public List<Employee> employees;
        public List<Drug> drugs;

        public Pharmacy(string name,int minsalary,int budget,string location)
        {
            Id = ++_id;
            Name = name;
            MinSalary = minsalary;
            Budget = budget;
            Location = location;
            employees = new List<Employee>();
            drugs = new List<Drug>();

        }
    }
}
