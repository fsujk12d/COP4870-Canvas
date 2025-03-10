using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Janvas1.Models;

namespace Library.Janvas1.services
{
    public class AssignmentService
    {
        public IList<Assignment> assnList;
        private static AssignmentService instance;
        private static object l = new object();
        private string? query = "";
        private int LastId { get
            {
                return assnList.Select(x => x.Id).Max();
            } }
        public static AssignmentService Current
        {
            get
            {
                lock (l)
                {
                    if (instance == null)
                    {
                        instance = new AssignmentService();
                    }
                }
                return instance;
            }
        }

        public IEnumerable<Assignment> Assignments
        {
            get
            {
                return assnList.Where(
                    c => c.Name.Contains(query ?? string.Empty, StringComparison.CurrentCultureIgnoreCase)
                        || c.Description.Contains(query ?? string.Empty, StringComparison.CurrentCultureIgnoreCase));
            }
        }

        public IEnumerable<Assignment> Search(string query)
        {
            this.query = query;
            return Assignments;
        }

        public void AddOrUpdate (Assignment assn)
        {
            if (assn.Id <= 0)
            {
                assn.Id = LastId + 1;
                assnList.Add(assn);
            }
        }

        public void Remove(Assignment assn)
        {
            assnList.Remove(assn);
        }

        public Assignment? GetById(int id)
        {
            return assnList.Where(a => a.Id == id).FirstOrDefault();
        }
        private AssignmentService()
        {
            assnList = new List<Assignment>
            {
                new Assignment { Name = "Make Canvas", Id = 1},
                new Assignment { Name = "Watch Brooklyn 99", Id = 2}
            };
        }

        //public Assignment Update(Assignment assn)
        //{

        //}
    }
}
