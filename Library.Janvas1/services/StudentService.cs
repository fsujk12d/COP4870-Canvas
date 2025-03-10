using Library.Janvas1.Database;
using Library.Janvas1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Janvas1.services
{
    public class StudentService
    {
        public IList<Person> students;
        private static StudentService instance;
        private static object l = new object();
        private string? query = "";
        private int LastId { get
            {
                return students.Select(x => x.Id).Max();
            }
        }
        public static StudentService Current
        {
            get
            {
                lock (l)
                {
                    if (instance == null)
                    {
                        instance = new StudentService();
                    }
                }
                return instance;
            }
        }

        public IEnumerable<Person> Students
        {
            get
            {
                return students.Where(
                    c =>
                        c.Name.Contains(query ?? string.Empty, StringComparison.CurrentCultureIgnoreCase)
                        || c.Classification.Contains(query ?? string.Empty, StringComparison.CurrentCultureIgnoreCase)
                        || c.Code.Contains(query ?? string.Empty, StringComparison.CurrentCultureIgnoreCase));
            }
        }

        public IEnumerable<Person> Search(string query)
        {
            this.query = query;
            return Students;
        }

        public void AddOrUpdate(Person stu)
        {
            if (stu.Id <= 0)
            {
                stu.Id = LastId + 1;
                students.Add(stu);
            }
        }

        public void Remove(Person stu)
        {
            students.Remove(stu);
        }

        public Person? GetById(int id)
        {
            return students.Where(s => s.Id == id).FirstOrDefault();
        }

        private StudentService() {
            students = new List<Person>
            {
                new Person { Name = "John Doe", Id = 1 },
                new Person { Name = "Jane Doe", Id = 2 },
                new Person { Name = "Jimmy Doe", Id = 3 },
                new Person { Name = "Jerry Doe", Id = 4 },
                new Person { Name = "Jarnathan Doe", Id = 5 }
            };
        }
    }
    
}
