using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Janvas1.Models
{
    public class Person
    {
        public string? Name { get; set; }
        public string? Classification { get; set; }
        public string? Code { get; set; }
        public int Id { get; set; }
        public decimal Grades { get; set; }

        public Person()     //Default Constructor
        {

        }

        public override string ToString()
        {
            return $"{Name} ({Code}) - {Classification}";
        }
    }
}
