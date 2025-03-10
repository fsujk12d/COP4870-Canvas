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
    public class StudentDetailViewModel : INotifyPropertyChanged
    {
        private Person? stu;

        public string StudentName
        {
            get
            {
                return stu?.Name ?? string.Empty;
            }
        }

        public string StudentCode
        {
            get
            {
                return stu?.Code ?? string.Empty;
            }
        }

        public string StudentClassification
        {
            get
            {
                return stu?.Classification ?? string.Empty;
            }
        }

        public IList<Course> CourseEnrollment
        {
            get
            {
                IList<Course> courses = new List<Course>();
                foreach (Course c in CourseService.Current.courseList)
                {
                    if (c.Roster.Contains(stu))
                    {
                        courses.Add(c);
                    }
                }
                return courses;
            }
        }

        public Course? SelectedCourse 
        { 
            get; 
            set; 
        }

        public IList<Assignment> Assignments
        {
            get
            {
                IList<Assignment> asns = new List<Assignment>();
                foreach (Course c in CourseService.Current.courseList)
                {
                    if (c.Roster.Contains(stu))
                    {
                        foreach (Assignment a in c.Assns)
                        {
                            asns.Add(a);
                        }
                    }
                }
                return asns;
            }
        }

        public Assignment? SelectedAssignment {  get; set; }

        public StudentDetailViewModel(int id = 0)
        {
            if (id == 0)
            {
                stu = new Person();
            }
            if (id > 0)
            {
                stu = StudentService.Current.GetById(id) ?? new Person();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(CourseEnrollment));
            NotifyPropertyChanged(nameof(Assignments));
        }


    }
}
