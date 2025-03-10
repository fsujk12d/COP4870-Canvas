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
    public class ISubmissionViewModel : INotifyPropertyChanged
    {
        private SubmissionService subSvc;

        public event PropertyChangedEventHandler? PropertyChanged;

        public IList<Submission> Submissions
        {
            get
            {
                return subSvc.submissions;
            }
        }

        public Submission? SelectedSubmission { get; set; }

        public ISubmissionViewModel()
        {
            subSvc = SubmissionService.Current;
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Submissions));
        }
    }
}
