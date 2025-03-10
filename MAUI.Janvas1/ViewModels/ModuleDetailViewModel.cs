using Library.Janvas1.Models;
using Library.Janvas1.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
//using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.Janvas1.ViewModels
{
    public class ModuleDetailViewModel : INotifyPropertyChanged
    {
        private Module? mod;

        public string Name
        {
            get
            {
                return mod?.Name ?? string.Empty;
            }
        }

        public string Description
        {
            get
            {
                return mod?.Description ?? string.Empty;
            }
        }

        public IList<ContentItem> ContentItems
        {
            get
            {
                return ContentItemService.Current.itemList;
            }
        }

        public ContentItem? SelectedContentItem { get; set; }

        public ModuleDetailViewModel(int id = 0)
        {
            if (id == 0)
            {
                mod = new Module();
            }
            if (id > 0)
            {
                mod = ModuleService.Current.GetById(id) ?? new Module();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(ContentItems));
        }

        public void AddContentItemToModule()
        {
            if (SelectedContentItem != null) 
            {
                mod?.ModContent?.Add(SelectedContentItem);
            }
        }
    }
}
