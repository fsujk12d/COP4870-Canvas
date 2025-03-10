using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Janvas1.Models;

namespace Library.Janvas1.services
{
    public class ContentItemService
    {
        public IList<ContentItem> itemList;
        private static ContentItemService instance;
        private static object l = new object();
        private string? query = "";
        private int LastId { get
            {
                return itemList.Select(x => x.Id).Max();
            } }

        public static ContentItemService Current
        {
            get
            {
                lock (l)
                {
                    if (instance == null)
                    {
                        instance = new ContentItemService();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<ContentItem> ContentItems
        {
            get
            {
                return itemList.Where(
                    i => i.Name.Contains(query ?? string.Empty, StringComparison.CurrentCultureIgnoreCase)
                        || i.Description.Contains(query ?? string.Empty, StringComparison.CurrentCultureIgnoreCase));
            }
        }

        public IEnumerable<ContentItem> Search(string query)
        {
            this.query = query;
            return ContentItems;
        }

        public void AddOrUpdate(ContentItem item)
        {
            if (item.Id <= 0)
            {
                item.Id = LastId + 1;
                itemList.Add(item);
            }
        }

        public void Remove(ContentItem item)
        {
            itemList.Remove(item);
        }

        public ContentItem? GetById(int id)
        {
            return itemList.Where(i => i.Id == id).FirstOrDefault();
        }

        private ContentItemService()
        {
            itemList = new List<ContentItem>
            {
                new ContentItem {Name = "Test Item 1", Description = "poopy", Id = 1},
                new ContentItem {Name = "Test Item 222", Description = "peepee", Id=2}
            };
        }


        

    }
}
