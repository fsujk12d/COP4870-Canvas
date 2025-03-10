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
    internal class CourseDialogViewModel : INotifyPropertyChanged
    {
        private Course? cou;

        public string Name
        {
            get
            {
                return cou?.Name ?? string.Empty;
            }
            set
            {
                if (cou == null)
                {
                    cou = new Course();
                }
                cou.Name = value;
            }
        }

        public string Code
        {
            get
            {
                return cou?.Code ?? string.Empty;
            }
            set
            {
                if (cou == null)
                {
                    cou = new Course();
                }
                cou.Code = value;
            }
        }

        public string Description
        {
            get
            {
                return cou?.Description ?? string.Empty;
            }
            set
            {
                if (cou == null)
                {
                    cou = new Course();
                }
                cou.Description = value;
            }
        }

        public int Id { get; set; }

        public CourseDialogViewModel(int id = 0)
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

        //public void LoadById(int id)
        //{
        //    //stuff
        //}

        public void AddCourse()
        {
            if (cou != null)
            {
                CourseService.Current.AddOrUpdate(cou);
            }
            Shell.Current.GoToAsync("//ICourses");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
