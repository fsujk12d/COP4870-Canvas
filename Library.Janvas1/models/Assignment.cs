using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Janvas1.Models
{
    public class Assignment
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int TotalAvailablePoints { get; set; }
        public DateOnly Date { get; set; }

        public int Id { get; set; }

        public Assignment()     //Default Constructor
        {
            //
        }

        public override string ToString()
        {
            return $"{Name} ({TotalAvailablePoints} pts) - {Description}";
        }
    }
}
