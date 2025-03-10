using Library.Janvas1.Models;
using Library.Janvas1.services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.Janvas1.ViewModels
{
    public class IContentItemsViewModel : INotifyPropertyChanged
    {
        private ContentItemService itemSvc;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<ContentItem> ContentItems
        {
            get
            {
                return new ObservableCollection<ContentItem>(itemSvc.ContentItems
                    .ToList().Where(i => i?.Name?.ToUpper().Contains(Query?.ToUpper() ?? string.Empty) ?? false));
            }
        }

        public ContentItem SelectedContentItem 
        { 
            get; set; 
        }

        public string? Query { get; set; }

        public IContentItemsViewModel()
        {
            itemSvc = ContentItemService.Current;
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddContentItem()
        {
            itemSvc.AddOrUpdate(new ContentItem { Name = "Test ContentItem" });
            NotifyPropertyChanged(nameof(ContentItems));
        }

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(ContentItems));
        }

        public void Remove()
        {
            if (SelectedContentItem == null) { return; }
            itemSvc.Remove(SelectedContentItem);
            Refresh();
        }


    }
}
