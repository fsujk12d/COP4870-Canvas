using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Janvas1.Models
{
    public class Module
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public IList<ContentItem>? ModContent { get; set; }
        public int Id { get; set; }

        public Module() {       //Default Constructor
            ModContent = new List<ContentItem>();
        }

        public override string ToString()
        {
            string? ret;
            ret = Name + " - " + Description + ": ";
            if (ModContent != null)
            {
                foreach (var x in ModContent)
                {
                    ret = ret + x.ToString() + "; ";
                }
            }
            
            return ret;
        }
    }
}
