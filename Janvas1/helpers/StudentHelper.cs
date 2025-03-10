using Library.Janvas1.Models;
using Library.Janvas1.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janvas1.helpers
{
    public class StudentHelper
    {
        private StudentService studentSvc = StudentService.Current;
        private CourseService courseSvc = CourseService.Current;
        
        public void AddStudent()
        {
            Console.WriteLine("Name: ");
            var name = Console.ReadLine();

            Console.WriteLine("ID: ");
            var id = Console.ReadLine();

            Console.WriteLine("Classification: ");
            var classification = Console.ReadLine();

            Console.WriteLine("GPA: ");
            var gpastr = Console.ReadLine();
            decimal gpadbl = decimal.Parse(gpastr ?? "0");

            Person theStudent;
            theStudent = new Person { Name = name, /*Id = id,*/ Classification = classification, Grades = gpadbl };

            studentSvc.Add(theStudent);
        }

        public bool PrintStudents()
        {
            if (studentSvc.Students != null)
            {
                studentSvc.students.ToList().ForEach(Console.WriteLine);
                return true;
            }
            else
            {
                Console.WriteLine("No students to print.");
                return false;
            }
        }

        public void SearchForStudent()
        {
            string? query;
            Console.WriteLine("Enter a student name or classification: ");
            query = Console.ReadLine();
            var studentResults = studentSvc.Search(query);
            foreach (Person s in studentResults)
            {
                Console.WriteLine($"{s.Name} ({s.Id}), {s.Classification}, {s.Grades} GPA");
            }
        }

        public void UpdateAStudent()
        {
            Console.WriteLine("Which student to update? (select the index)");
            string? stuChoice = Console.ReadLine();
            int stuChoiceInt = int.Parse(stuChoice ?? "0");

            Console.WriteLine("Are you updating the student's name? (Y/N)");
            string? yesno = Console.ReadLine();
            if (yesno == "Y" || yesno == "y")
            {
                Console.WriteLine("Enter new student name:");
                string? newname = Console.ReadLine();
                studentSvc.students[stuChoiceInt].Name = newname;
            }

            Console.WriteLine("Are you updating the student's ID? (Y/N)");
            yesno = Console.ReadLine();
            if (yesno == "Y" || yesno == "y")
            {
                Console.WriteLine("Enter new student ID:");
                string? newid = Console.ReadLine();
                //studentSvc.students[stuChoiceInt].Id = newid;
            }

            Console.WriteLine("Are you updating the student's classification? (Y/N)");
            yesno = Console.ReadLine();
            if (yesno == "Y" || yesno == "y")
            {
                Console.WriteLine("Enter new student classification:");
                string? newclass = Console.ReadLine();
                studentSvc.students[stuChoiceInt].Classification = newclass;
            }

            Console.WriteLine("Are you updating the student's GPA? (Y/N)");
            yesno = Console.ReadLine();
            if (yesno == "Y" || yesno == "y")
            {
                Console.WriteLine("Enter new student GPA:");
                string? newgpa = Console.ReadLine();
                decimal _newgpa = decimal.Parse(newgpa);
                studentSvc.students[stuChoiceInt].Grades = _newgpa;
            }
        }

        public void ListAllCoursesAStudentIsIn()
        {
            Console.WriteLine("Which student? (Select the index) ");
            string? studentChoice = Console.ReadLine();
            int stuChoiceInt = int.Parse(studentChoice ?? "0");
            Person temp = studentSvc.students[stuChoiceInt];
            IList<Course> tempCourseList = new List<Course>();
            foreach (Course c in courseSvc.courseList)
            {
                if (c.Roster.Contains(temp))
                {
                    tempCourseList.Add(c);
                }
            }
            foreach (Course c in tempCourseList)
            {
                Console.WriteLine($"{c.Name} ({c.Code})");
            }
        }
    }


}
