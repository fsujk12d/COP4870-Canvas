using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Janvas1.Models
{
    public class Submission
    {
        public string? StudentName { get; set; }
        public string? CourseName {  get; set; }
        public string? AssignmentName { get; set; }
        public string? SubmissionText { get; set; }
        public int SubmissionId { get; set; }
        public double? Grade { get; set; }
        public string? Comments { get; set; }

        public Submission() { }

        public override string ToString()
        {
            return $"{CourseName} - {AssignmentName} - {StudentName} - {SubmissionText} - {Grade}";
        }
    }
}
