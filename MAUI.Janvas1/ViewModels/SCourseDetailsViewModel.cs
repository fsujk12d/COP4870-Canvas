using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Janvas1.Models;
using Library.Janvas1.services;

namespace MAUI.Janvas1.ViewModels
{
    public class SCourseDetailsViewModel
    {
        private Course? cou;

        public string CourseName
        {
            get
            {
                return cou?.Name ?? string.Empty;
            }
        }

        public string CourseCode
        {
            get
            {
                return cou?.Code ?? string.Empty;
            }
        }

        public string CourseDescription
        {
            get
            {
                return cou?.Description ?? string.Empty;
            }
        }

        public IList<Module> Modules
        {
            get
            {
                return cou?.Mods;
            }
        }

        public IList<Assignment> Assignments
        {
            get
            {
                return cou?.Assns;
            }
        }

        public IList<Person> Roster
        {
            get
            {
                return cou?.Roster;
            }
        }

        public SCourseDetailsViewModel(int id = 0)
        {
            if (id == 0)
            {
                cou = new Course();
            }
            if (id > 0)
            {
                cou = CourseService.Current.GetById(id) ?? new Course();
            }
        }
    }
}
