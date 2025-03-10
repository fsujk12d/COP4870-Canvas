using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Janvas1.Models;
using Library.Janvas1.services;

namespace MAUI.Janvas1.ViewModels
{
    public class StudentSubmitDialogViewModel
    {
        
        private Submission? sub;

        public string StudentName
        {
            get
            {
                return sub?.StudentName ?? string.Empty;
            }
            set
            {
                if (sub == null)
                {
                    sub = new Submission();
                }
                sub.StudentName = value;
            }
        }

        public string CourseName
        {
            get
            {
                return sub?.CourseName ?? string.Empty;
            }
            set
            {
                if (sub == null)
                {
                    sub = new Submission();
                }
                sub.CourseName = value;
            }
        }

        public string AssignmentName
        {
            get
            {
                return sub?.AssignmentName ?? string.Empty;
            }
            set
            {
                if (sub == null)
                {
                    sub = new Submission();
                }
                sub.AssignmentName = value;
            }
        }

        public string SubmissionText
        {
            get
            {
                return sub?.SubmissionText ?? string.Empty;
            }
            set
            {
                if (sub == null)
                {
                    sub = new Submission();
                }
                sub.SubmissionText = value;
            }
        }

        public int Id {  get; set; }

        public StudentSubmitDialogViewModel(int id = 0)
        {
            if (id == 0)
            {
                sub = new Submission();
            }
            if (id > 0)
            {
                sub = SubmissionService.Current.GetById(id) ?? new Submission();
            }
        }

        public void SubmitAssignment()
        {
            if (sub != null)
            {
                SubmissionService.Current.AddOrUpdate(sub);
            }
            Shell.Current.GoToAsync("//Students");
        }

    }
}
