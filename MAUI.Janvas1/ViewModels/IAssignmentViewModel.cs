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
    public class IAssignmentViewModel : INotifyPropertyChanged
    {
        private AssignmentService assignmentSvc;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Assignment> Assignments
        {
            get
            {
                return new ObservableCollection<Assignment>(assignmentSvc.Assignments
                    .ToList().Where(a => a?.Name?.ToUpper().Contains(Query?.ToUpper() ?? string.Empty) ?? false));
            }
        }

        public Assignment? SelectedAssignment
        {
            get; set;
        }

        public string? Query { get; set; }

        public IAssignmentViewModel()
        {
            assignmentSvc = AssignmentService.Current;
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddAssignment()
        {
            assignmentSvc.AddOrUpdate(new Assignment { Name = "Test Assignment" });
            NotifyPropertyChanged(nameof(Assignments));
        }

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Assignments));
        }

        public void Remove()
        {
            if (SelectedAssignment == null) { return; }
            assignmentSvc.Remove(SelectedAssignment);
            Refresh();
        }
    }
}
