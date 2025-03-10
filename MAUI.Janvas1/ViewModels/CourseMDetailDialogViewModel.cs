using Library.Janvas1.Models;
using Library.Janvas1.services;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.Janvas1.ViewModels
{
    public class CourseMDetailDialogViewModel
    {
        private Course? cou;

        public string Name
        {
            get
            {
                return cou?.Name ?? string.Empty;
            }
        }

        public string Description
        {
            get
            {
                return cou?.Description ?? string.Empty;
            }
        }

        public IList<Module> Modules
        {
            get
            {
                return ModuleService.Current.modList;
            }
        }

        public Module? SelectedModule { get; set; }

        public CourseMDetailDialogViewModel(int id = 0)
        {
            if (id == 0)
            {
                cou = new Course();
            }
            if (id > 0)
            {
                cou = CourseService.Current.GetById(id) ?? new Course();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Modules));
        }

        public void AddModuleToCourse()
        {
            if (SelectedModule != null)
            {
                cou?.Mods?.Add(SelectedModule);
            }
        }
    }
}
