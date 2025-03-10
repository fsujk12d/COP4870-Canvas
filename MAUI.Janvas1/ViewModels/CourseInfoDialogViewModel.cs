using Library.Janvas1.Models;
using Library.Janvas1.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.Janvas1.ViewModels
{
    public class CourseInfoDialogViewModel
    {
        public Course? cou;

        public string Name
        {
            get
            {
                return cou?.Name ?? string.Empty;
            }
        }

        public string Code
        {
            get
            {
                return cou?.Code ?? string.Empty;
            }
        }

        public string Description
        {
            get
            {
                return cou?.Description ?? string.Empty;
            }
        }

        public IList<Assignment> Assignments
        {
            get
            {
                return cou?.Assns ?? new List<Assignment>();                
            }
        }

        public IList<Module> Modules
        {
            get
            {
                return cou?.Mods ?? new List<Module>() ;
            }
        }

        public IList<Person> Roster
        {
            get
            {
                return cou?.Roster ?? new List<Person>() ;
            }
        }

        public CourseInfoDialogViewModel(int id = 0)
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
