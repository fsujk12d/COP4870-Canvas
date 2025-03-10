using Library.Janvas1.Models;
using Library.Janvas1.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.Janvas1.ViewModels
{
    public class ModuleDialogViewModel : INotifyPropertyChanged
    {
        private Module? mod;

        public string Name
        {
            get
            {
                return mod?.Name ?? string.Empty;
            }
            set
            {
                if (mod == null)
                {
                    mod = new Module();
                }
                mod.Name = value;
            }
        }

        public string Description
        {
            get
            {
                return mod?.Description ?? string.Empty;
            }
            set
            {
                if (mod == null)
                {
                    mod = new Module();
                }
                mod.Description = value;
            }
        }

        public int Id {  get; set; }

        public ModuleDialogViewModel(int id = 0) 
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

        //public void LoadById(int id)
        //{
        //    //stuff
        //}

        public void AddModule()
        {
            if (mod != null)
            {
                ModuleService.Current.AddOrUpdate(mod);
            }
            Shell.Current.GoToAsync("//IModules");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
