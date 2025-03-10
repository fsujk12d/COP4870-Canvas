using Library.Janvas1.Models;
using Library.Janvas1.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.Janvas1.ViewModels
{
    public class CourseSDetailDialogViewModel : INotifyPropertyChanged
    {
        private Course? cou;

        public string Name
        {
            get
            {
                return cou?.Name ?? string.Empty;
            }
        }

        public string Description
        {
            get
            {
                return cou?.Description ?? string.Empty;
            }
        }

        public IList<Person> Students
        {
            get
            {
                return StudentService.Current.students;
            }
        }

        public Person? SelectedStudent {  get; set; }

        public CourseSDetailDialogViewModel(int id = 0)
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

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Students));
        }

        public void AddStudentToCourse()
        {
            if (SelectedStudent != null)
            {
                cou?.Roster?.Add(SelectedStudent);
            }
        }
    }
}
