using Library.Janvas1.Models;
using Library.Janvas1.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janvas1.helpers
{
    public class AssignmentHelper
    {
        private AssignmentService assnSvc = AssignmentService.Current;
        private CourseService courseSvc = CourseService.Current;    

        public void AddAssignment()
        {
            Console.WriteLine("Enter assignment name:");
            string? name = Console.ReadLine();

            Console.WriteLine("Enter assignment description:");
            string? description = Console.ReadLine();

            Console.WriteLine("Enter total points:");
            string? pointsstr = Console.ReadLine();
            int points = int.Parse(pointsstr ?? "0");

            Console.WriteLine("Enter date assigned:");
            string? datestr = Console.ReadLine();
            DateOnly date = DateOnly.Parse(datestr ?? "0");

            Assignment theAssn = new Assignment { Name = name, Description = description, TotalAvailablePoints = points, Date = date };

            assnSvc.Add(theAssn);
        }

        public bool PrintAssignments()
        {
            if (assnSvc.assnList != null)
            {
                assnSvc.assnList.ToList().ForEach(Console.WriteLine);
                return true;
            }
            else
            {
                Console.WriteLine("No assignments to print.");
                return false;
            }

        }
        public void AddAssignmentToCourse()
        {
            Console.WriteLine("Which course will receive the assignment? (select the index)");
            string? courseChoiceStr = Console.ReadLine();
            int courseChoiceInt = int.Parse(courseChoiceStr ?? "0");

            if (PrintAssignments())
            {
                Console.WriteLine("Which assignment will be added?");
                string? assnChoiceStr = Console.ReadLine();
                int assnChoiceInt = int.Parse(assnChoiceStr ?? "0");

                courseSvc.courseList[courseChoiceInt].Assns.Add(assnSvc.assnList[assnChoiceInt]);
            }
        }
    }
}
