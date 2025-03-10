using Library.Janvas1.Models;
using Library.Janvas1.services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.Janvas1.ViewModels
{
    internal class ICourseViewModel : INotifyPropertyChanged
    {
        private CourseService courseSvc;
        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Course> Courses
        {
            get
            {
                return new ObservableCollection<Course>(courseSvc.Courses
                    .ToList().Where(c => c?.Name?.ToUpper().Contains(Query?.ToUpper() ?? string.Empty) ?? false));
            }
        }
        
        public Course? SelectedCourse 
        { 
            get; set; 
        }

        public string? Query { get; set; }
        public ICourseViewModel()
        {
            courseSvc = CourseService.Current;
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddCourse() 
        {
            courseSvc.AddOrUpdate(new Course { Name = "Test Course" });
            NotifyPropertyChanged(nameof(Courses));
        }

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Courses));
        }

        public void Remove()
        {
            if (SelectedCourse == null) { return; }
            courseSvc.Remove(SelectedCourse);
            Refresh();
        }
    }
}
