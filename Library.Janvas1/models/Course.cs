using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Janvas1.Models
{
    public class Course
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Id { get; set; }
        public List<Person>? Roster { get; set; }
        public List<Assignment>? Assns { get; set; }
        public List<Module>? Mods { get; set; }

        public Course() {       //Default Constructor
            Roster = new List<Person>();
            Assns = new List<Assignment>();
            Mods = new List<Module>();
        }

        public void AddStudent(Person stu)
        {
            Roster.Add(stu);
        }

        public override string ToString()
        {
            string ret = Name + " (" + Code + ") - " + Description + " ";

            //if (Roster?.Count() != 0)
            //{
            //    ret += "| ROSTER: ";
            //    foreach (Person p in Roster)
            //    {
            //        ret = ret + p.ToString() + ". ";
            //    }
            //}

            //if (Assns?.Count() != 0)
            //{
            //    ret += "| ASSIGNMENTS: ";
            //    foreach (Assignment a in Assns)
            //    {
            //        ret = ret + a.ToString() + ". ";
            //    }
            //}

            //if (Mods?.Count() != 0)
            //{
            //    ret += "| MODULES: ";
            //    foreach (Module m in Mods)
            //    {
            //        ret = ret + m.ToString() + ". ";
            //    }
            //}

            return ret;
        }

    }
}
