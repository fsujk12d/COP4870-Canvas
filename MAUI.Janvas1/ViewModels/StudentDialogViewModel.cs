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
    public class StudentDialogViewModel : INotifyPropertyChanged
    {
        private Person? stu;

        public string Name
        {
            get
            {
                return stu?.Name ?? string.Empty;
            }
            set
            {
                if (stu == null)
                {
                    stu = new Person();
                }
                stu.Name = value;
            }
        }

        public string Classification
        {
            get
            {
                return stu?.Classification ?? string.Empty;
            }
            set
            {
                if (stu == null)
                {
                    stu = new Person();
                }
                stu.Classification = value;
            }
        }

        public string Code
        {
            get
            {
                return stu?.Code ?? string.Empty;
            }
            set
            {
                if (stu == null)
                {
                    stu = new Person();
                }
                stu.Code = value;
            }
        }

        public decimal Grades
        {
            get
            {
                return stu?.Grades ?? decimal.Zero ;
            }
            set
            {
                if (stu == null)
                {
                    stu = new Person();
                }
                stu.Grades = value;
            }
        }

        public int Id { get; set; }

        public StudentDialogViewModel(int id = 0)
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

        public void LoadById(int id)
        {
            if (id == 0) { return; }
            var person = StudentService.Current.GetById(id);
            if (person != null)
            {
                Name = person.Name;
                Id = person.Id;
                Classification = person.Classification;
            }

            NotifyPropertyChanged(nameof(Name));
            NotifyPropertyChanged(nameof(Classification));
        }

        public void AddStudent()
        {
            if (stu != null)
            {
                StudentService.Current.AddOrUpdate(stu);
            }
            
            
            /*if (Id <= 0)
            {
                StudentService.Current.AddOrUpdate(new Person { Name = Name, Classification = Classification });
            } else
            {
                var refToUpdate = StudentService.Current.GetById(Id);
                refToUpdate.Name = Name;
                refToUpdate.Classification = Classification;
                refToUpdate.Grades = Grades;
                refToUpdate.Code = Code;
            }*/
            Shell.Current.GoToAsync("//IStudents");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
