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
    public class AssignmentDialogViewModel : INotifyPropertyChanged
    {
        private Assignment? assn;

        public string Name { 
            get 
            {
                return assn?.Name ?? string.Empty;
            }
            set
            {
                if (assn == null)
                {
                    assn = new Assignment();
                }
                assn.Name = value;
            }
        }

        public string Description
        {
            get
            {
                return assn?.Description ?? string.Empty;
            }
            set
            {
                if (assn == null)
                {
                    assn = new Assignment();
                }
                assn.Description = value;
            }
        }

        public int TotalAvailablePoints
        {
            get
            {
                return assn?.TotalAvailablePoints ?? 0;
            }
            set
            {
                if (assn == null)
                {
                    assn = new Assignment();
                }
                assn.TotalAvailablePoints = value;
            }
        }

        public int Id { get; set; }

        public AssignmentDialogViewModel(int id = 0)
        {
            if (id == 0)
            {
                assn = new Assignment();
            }
            if (id > 0)
            {
                assn = AssignmentService.Current.GetById(id) ?? new Assignment();
            }
        }

        //public void LoadById(int id)
        //{
        //    //stuff
        //}

        public void AddAssignment()
        {
            if (assn != null)
            {
                AssignmentService.Current.AddOrUpdate(assn);
            }
            Shell.Current.GoToAsync("//IAssignments");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
