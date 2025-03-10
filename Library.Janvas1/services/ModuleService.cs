using Library.Janvas1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Janvas1.services
{
    public class ModuleService
    {
        public IList<Module> modList;
        private static ModuleService instance;
        private static object l = new object();
        private string? query = "";
        private int LastId { get
            {
                return modList.Select(m => m.Id).Max();
            }
        }
        public static ModuleService Current
        {
            get
            {
                lock (l)
                {
                    if (instance == null)
                    {
                        instance = new ModuleService();
                    }
                }
                return instance;
            }
        }
        public IEnumerable<Module> Modules
        {
            get 
            {
                return modList.Where(c => c.Name.Contains(query ?? string.Empty, StringComparison.CurrentCultureIgnoreCase) ||
                                        c.Description.Contains(query ?? string.Empty, StringComparison.CurrentCultureIgnoreCase));
            }
        }

        public IEnumerable<Module> Search(string query)
        {
            this.query = query;
            return Modules;
        }

        public void AddOrUpdate(Module mod)
        {
            if (mod.Id <= 0)
            {
                mod.Id = LastId + 1;
                modList.Add(mod);
            }
        }

        public void Remove(Module mod)
        {
            modList.Remove(mod);
        }

        public Module? GetById(int id)
        {
            return modList.Where(m => m.Id == id).FirstOrDefault();
        }

        public void AddContentToModule()
        {

        }

        private ModuleService()
        {
            modList = new List<Module> { 
                new Module { Name = "Test Mod 1", Id = 1 },
                new Module { Name = "Test Mod 2", Id = 2 }
            };
        }
    }
}
