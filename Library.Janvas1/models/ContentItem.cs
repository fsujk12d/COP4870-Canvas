using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Janvas1.Models
{
    public class ContentItem 
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Path { get; set; } //????
        public int Id { get; set; }

        public ContentItem() {      //Default Constructor
            //
        }

        public override string ToString()
        {
            return $"{Name} - {Description} ({Path})";
        }
    }
}
