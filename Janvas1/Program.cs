using System;
using System.Security.Cryptography.X509Certificates;
using Janvas1.helpers;

/* COP4870 Assignment 1
 *  Name: Jason Kenyon
 *  FSUID: jk12d    CS Account: kenyon
 *  Description: This is the Console Version of the semester-long project to build our own version of Canvas. Mine is called Janvas. There are a few minor issues 
 *  and features to be added as the semester goes along. Full documentation will be added in a later version.
 */

namespace Janvas1
{
    internal class Program
    { 
        static void Main(string[] args)
        {
            var courseHlpr = new CourseHelper();
            var studentHlpr = new StudentHelper();
            var assignmentHlpr = new AssignmentHelper();

            Console.WriteLine("Welcome to Janvas\n");
            PrintMenu();

            Console.WriteLine("What would you like to do?");
            string? choice = Console.ReadLine();
            while (choice != "69")
            {
                switch (choice)
                {
                    //create course
                    case "1":   
                        courseHlpr.AddCourse();
                        break;
                    //create student
                    case "2":   
                        studentHlpr.AddStudent();
                        break;
                    //add student to course
                    case "3":
                        if (studentHlpr.PrintStudents())
                        {
                            courseHlpr.AddStudentToCourse();
                        }
                        break;
                    //remove a student
                    case "4":
                        if (studentHlpr.PrintStudents())
                        {
                            courseHlpr.RemoveStudentFromCourse();
                        }
                        break;
                    //list all courses
                    case "5":   
                        courseHlpr.PrintCourses();
                        break;
                    //search for course
                    case "6":
                        courseHlpr.SearchForCourse();
                        break;
                    //list all students
                    case "7":   
                        studentHlpr.PrintStudents();
                        break;
                    //search for a student
                    case "8":
                        studentHlpr.SearchForStudent();
                        break;
                    //list all courses a student is taking
                    case "9":
                        if (studentHlpr.PrintStudents())
                        {
                            studentHlpr.ListAllCoursesAStudentIsIn();           ///!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        }
                        break;
                    //update a course
                    case "10":
                        if (courseHlpr.PrintCourses())
                        {
                            courseHlpr.UpdateACourse();
                        }
                        break;
                    //update a student
                    case "11":
                        if (studentHlpr.PrintStudents())
                        {
                            studentHlpr.UpdateAStudent();
                        }
                        break;
                    //create assignment
                    case "12":
                        assignmentHlpr.AddAssignment();
                        break;

                    //list all assignments
                    case "13":
                        assignmentHlpr.PrintAssignments();
                        break;

                    //add assignment to a course
                    case "14":
                        if (courseHlpr.PrintCourses())
                        {
                            assignmentHlpr.AddAssignmentToCourse();                ///!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        }
                        break;
                    //print the menu again
                    case "99":
                        PrintMenu();
                        break;
                    
                    //print course roster
                    case "33":
                        if (courseHlpr.PrintCourses())
                        {
                            courseHlpr.PrintCourseRoster();
                        }
                        break;

                    default:    //dummy
                        
                        break;

                }
                Console.WriteLine("What's next? ");
                choice = Console.ReadLine();
            }
            Console.WriteLine("Jank You");

        }

        public static void PrintMenu()
        {
            Console.WriteLine("--- MENU ---\n");
            Console.WriteLine("1. Create a course");
            Console.WriteLine("2. Create a student");
            Console.WriteLine("3. Add a student to a course");
            Console.WriteLine("4. Remove a student from a course");
            Console.WriteLine("5. List all courses");
            Console.WriteLine("6. Search for a course");
            Console.WriteLine("7. List all students");
            Console.WriteLine("8. Search for a student");
            Console.WriteLine("9. List all courses a student is taking");
            Console.WriteLine("10. Update a course");
            Console.WriteLine("11. Update a student");
            Console.WriteLine("12. Create an assignment");
            Console.WriteLine("13. List all assignments");
            Console.WriteLine("14. Add an assignment to a course");
            Console.WriteLine("99. Print menu again");
            Console.WriteLine("69. Exit Janvas");
        }

        

        

    }
}
