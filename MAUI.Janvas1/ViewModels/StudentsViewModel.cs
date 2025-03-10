using Library.Janvas1.Models;
using Library.Janvas1.services;
using System.Collections.ObjectModel;

namespace MAUI.Janvas1.ViewModels
{
    internal class StudentsViewModel
    {


        private StudentService studentSvc;

        public IList<Person> Students
        {
            get
            {
                return studentSvc.students;
            }
        }
        public Person? SelectedStudent { get; set; }

        public StudentsViewModel()
        {
            studentSvc = StudentService.Current;
        }
    }
}
