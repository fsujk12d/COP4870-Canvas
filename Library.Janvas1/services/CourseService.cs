using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Janvas1.Models;

namespace Library.Janvas1.services
{
    public class CourseService
    {
        public IList<Course> courseList;
        private static CourseService instance;
        private static object l = new object();
        private string? query = "";
        private int LastId {  get
            {
                return courseList.Select(c => c.Id).Max();
            }
        }
        public static CourseService Current
        {
            get
            {
                lock (l)
                {
                    if (instance == null)
                    {
                        instance = new CourseService();
                    }
                }
                return instance;
            }
        }

        public IEnumerable<Course> Courses
        {
            get {
                return courseList.Where(
                    c => c.Name.Contains(query ?? string.Empty, StringComparison.CurrentCultureIgnoreCase)
                        || c.Code.Contains(query ?? string.Empty, StringComparison.CurrentCultureIgnoreCase)
                        || c.Description.Contains(query ?? string.Empty, StringComparison.CurrentCultureIgnoreCase));
            }
        }

        public IEnumerable<Course> Search(string query)
        {
            this.query = query;
            return Courses;
        }

        public void AddOrUpdate(Course cou)
        {
            if (cou.Id <= 0)
            {
                cou.Id = LastId + 1;
                courseList.Add(cou);
            }
        }

        public void Remove(Course cou)
        {
            courseList.Remove(cou);
        }

        public Course? GetById(int id)
        {
            return courseList.Where(c => c.Id == id).FirstOrDefault();
        }

        private CourseService()
        {
            courseList = new List<Course>
            {
                new Course { Name = "FullStack in C#", Id = 1},
                new Course { Name = "Data Structures 2", Id = 2}
            };
        }
    }
}
