using Library.Janvas1.Models;
using Library.Janvas1.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janvas1.helpers
{
    public class CourseHelper
    {
        private CourseService courseSvc = CourseService.Current;
        private StudentService studentSvc = StudentService.Current;
        public void AddCourse()
        {
            Console.WriteLine("Course Name:");
            var name = Console.ReadLine();

            Console.WriteLine("Description:");
            var description = Console.ReadLine();

            Console.WriteLine("Code:");
            var code = Console.ReadLine();

            Course theCourse = new Course { Name = name, Code = code, Description = description };

            courseSvc.Add(theCourse);
        }

        public void AddStudentToCourse()
        {
            Console.WriteLine("Which student will be added? (Select the index) ");
            string? studentChoice = Console.ReadLine();
            int stuChoiceInt = int.Parse(studentChoice ?? "0");
            if (PrintCourses())
            {
                Console.WriteLine("Which course? (Select the Index)");
                string? courseChoice = Console.ReadLine();
                int courseChoiceInt = int.Parse(courseChoice ?? "0");
                courseSvc.courseList[courseChoiceInt].Roster.Add(studentSvc.students[stuChoiceInt]);
            }
        }

        public bool PrintCourses()
        {
            if (courseSvc.courseList != null)
            {
                courseSvc.courseList.ToList().ForEach(Console.WriteLine);
                return true;
            }
            else
            {
                Console.WriteLine("No courses to print.");
                return false;
            }
        }

        public void RemoveStudentFromCourse()
        {
            
            Console.WriteLine("Which Course? (Select the Index)");
            string? courseChoice = Console.ReadLine();
            int courseChoiceInt = int.Parse(courseChoice ?? "0");
            if (PrintCourseStudents(courseSvc.courseList[courseChoiceInt]))
            {
                Console.WriteLine("Which Student? (Select the Index)");
                string? studentChoice = Console.ReadLine();
                int stuChoiceInt = int.Parse(studentChoice ?? "0");
                courseSvc.courseList[courseChoiceInt].Roster.Remove(courseSvc.courseList[courseChoiceInt].Roster[stuChoiceInt]);
            }
            
        }

        public bool PrintCourseStudents(Course course)
        {
            if (course.Roster != null)
            {
                foreach (Person stu in course.Roster)
                {
                    Console.WriteLine($"{course.Roster.IndexOf(stu)}) {stu.Name} - {stu.Classification}");
                }
                return true;
            }
            else
            {
                Console.WriteLine("No students to remove");
                return false;
            }
        }

        public void SearchForCourse()
        {
            Console.WriteLine("Enter a course name, description, or code: ");
            string? query = Console.ReadLine();
            var courseResults = courseSvc.Search(query);
            foreach (Course c in courseResults)
            {
                Console.WriteLine($"{c.Name} ({c.Code}): {c.Description}");
            }
        }

        public void UpdateACourse()
        {
            Console.WriteLine("Which course to update? (Select the index)");
            string? courseChoice = Console.ReadLine();
            int courseChoiceInt = int.Parse(courseChoice ?? "0");

            Console.WriteLine("Are you updating the course name? (Y/N)");
            string? yesno = Console.ReadLine();
            if (yesno == "Y" || yesno == "y")
            {
                Console.WriteLine("Enter new course name:");
                string? newname = Console.ReadLine();
                courseSvc.courseList[courseChoiceInt].Name = newname;
            }

            Console.WriteLine("Are you updating the course code? (Y/N)");
            yesno = Console.ReadLine();
            if (yesno == "Y" || yesno == "y")
            {
                Console.WriteLine("Enter new course code:");
                string? newcode = Console.ReadLine();
                courseSvc.courseList[courseChoiceInt].Code = newcode;
            }

            Console.WriteLine("Are you updating the course description? (Y/N)");
            yesno = Console.ReadLine();
            if (yesno == "Y" || yesno == "y")
            {
                Console.WriteLine("Enter new course description:");
                string? newdesc = Console.ReadLine();
                courseSvc.courseList[courseChoiceInt].Description = newdesc;
            }
        }
        public void PrintCourseRoster()
        {
            Console.WriteLine("Which course?");
            string? input = Console.ReadLine();
            int inputInt = int.Parse(input);
            for (int i = 0; i < courseSvc.courseList[inputInt].Roster.Count; i++)
            {
                Console.WriteLine($"{i}) {courseSvc.courseList[inputInt].Roster[i].Name} - {courseSvc.courseList[inputInt].Roster[i].Id} - {courseSvc.courseList[inputInt].Roster[i].Classification} - {courseSvc.courseList[inputInt].Roster[i].Grades} GPA");
            }
        }



    }
}
