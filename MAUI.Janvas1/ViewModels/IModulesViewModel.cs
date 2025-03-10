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
    internal class IModulesViewModel : INotifyPropertyChanged
    {
        private ModuleService modSvc;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Module> Modules
        {
            get
            {
                return new ObservableCollection<Module>(modSvc.Modules
                    .ToList().Where(m => m?.Name?.ToUpper().Contains(Query?.ToUpper() ?? string.Empty) ?? false));
            }
        }

        public Module? SelectedModule 
        { 
            get; set; 
        }

        public string? Query { get; set; }

        public IModulesViewModel()
        {
            modSvc = ModuleService.Current;
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddModule()
        {
            modSvc.AddOrUpdate(new Module { Name = "Test Mod" });
            NotifyPropertyChanged(nameof(Modules));
        }

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Modules));
        }

        public void Remove()
        {
            if (SelectedModule ==  null) { return; }
            modSvc.Remove(SelectedModule);
            Refresh();
        }
    }
}
