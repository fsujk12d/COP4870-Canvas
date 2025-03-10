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
using MAUI.Janvas1.Views;

namespace MAUI.Janvas1.ViewModels
{
    internal class IStudentsViewModel :  INotifyPropertyChanged

    {
        private StudentService studentSvc;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Person> Students
        {
            get
            {
                return new ObservableCollection<Person>(studentSvc.Students
                    .ToList().Where(s => s?.Name?.ToUpper().Contains(Query?.ToUpper() ?? string.Empty) ?? false));
            }
        }

        public Person? SelectedPerson 
        {  
            get; set; 
        }

        public string? Query { get; set; }

        public IStudentsViewModel()
        {
            studentSvc = StudentService.Current;
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddStudent()
        {
            studentSvc.AddOrUpdate(new Person { Name = "Test Student" });
            NotifyPropertyChanged(nameof(Students));
        }

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Students));
        }

        public void Remove()
        {
            if (SelectedPerson == null) { return; }
            studentSvc.Remove(SelectedPerson);
            Refresh();
        }
    }
}
