using Library.Janvas1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Janvas1.services
{
    public class SubmissionService
    {
        public IList<Submission> submissions;
        private static SubmissionService instance;
        private static object l = new object();
        private string? query = "";
        
        private int LastId
        {
            get
            {
                if (submissions.Count() == 0)
                {
                    return 1;
                }
                return submissions.Select(s => s.SubmissionId).Max();
            }
        }

        public static SubmissionService Current
        {
            get
            {
                lock (l)
                {
                    if (instance == null)
                    {
                        instance = new SubmissionService();
                    }
                }
                return instance;
            }
        }

        public IEnumerable<Submission> Submissions
        {
            get
            {
                return submissions.Where(s =>
                s.StudentName.Contains(query ?? string.Empty, StringComparison.CurrentCultureIgnoreCase)
                || s.CourseName.Contains(query ?? string.Empty, StringComparison.CurrentCultureIgnoreCase)
                || s.AssignmentName.Contains(query ?? string.Empty, StringComparison.CurrentCultureIgnoreCase)
                || s.SubmissionText.Contains(query ?? string.Empty, StringComparison.CurrentCultureIgnoreCase));
            }
        }

        public IEnumerable<Submission> Search(string query)
        {
            this.query = query;
            return Submissions;
        }

        public void AddOrUpdate(Submission sub)
        {
            if (sub.SubmissionId <= 0)
            {
                sub.SubmissionId = LastId + 1;
                submissions.Add(sub);
            }
        }

        public void Remove(Submission sub)
        {
            submissions.Remove(sub);
        }

        public Submission? GetById(int id)
        {
            return submissions.Where(s => s.SubmissionId == id).FirstOrDefault();
        }

        private SubmissionService()
        {
            submissions = new List<Submission>();
        }
    }
}
