using Library.Janvas1.Models;
using Library.Janvas1.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.Janvas1.ViewModels
{
    public class ContentItemDialogViewModel
    {
        private ContentItem? item;

        public string Name
        {
            get
            {
                return item?.Name ?? string.Empty;
            }
            set
            {
                if (item == null)
                {
                    item = new ContentItem();
                }
                item.Name = value;
            }
        }

        public string Description
        {
            get
            {
                return item?.Description ?? string.Empty;
            }
            set
            {
                if (item == null)
                {
                    item = new ContentItem();
                }
                item.Description = value;
            }
        }

        public string Path
        {
            get
            {
                return item?.Path ?? string.Empty;
            }
            set
            {
                if (item == null)
                {
                    item = new ContentItem();
                }
                item.Path = value;
            }
        }

        public int Id { get; set; }

        public ContentItemDialogViewModel(int id = 0)
        {
            if (id == 0)
            {
                item = new ContentItem();
            }
            if (id > 0)
            {
                item = ContentItemService.Current.GetById(id) ?? new ContentItem();
            }
        }

        //public void LoadById(int id) { blah}

        public void AddContentItem()
        {
            if (item != null)
            {
                ContentItemService.Current.AddOrUpdate(item);
                Shell.Current.GoToAsync("//IContentItems");
            }
        }
    }
}
