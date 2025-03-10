using MAUI.Janvas1.ViewModels;
using Library.Janvas1.services;
using Library.Janvas1.Models;

namespace MAUI.Janvas1.Views;

public partial class IStudentsView : ContentPage
{
    public IStudentsView()
    {
        InitializeComponent();
        BindingContext = new IStudentsViewModel();
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructors");
    }

    private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//IStudentDetails?personId={0}");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as IStudentsViewModel)?.Refresh();
    }

    private void RemoveClicked(object sender, EventArgs e)
    {
        (BindingContext as IStudentsViewModel)?.Remove();
    }

    private void EditClicked(object sender, EventArgs e)
    {
        var idParam = (BindingContext as IStudentsViewModel)?.SelectedPerson?.Id;
        if (idParam != null )
        {
            Shell.Current.GoToAsync($"//IStudentDetails?personId={idParam}");
        }
    }//Selected Client setup is in the 2/14 lecture

    private void SearchClicked(object sender, EventArgs e)
    {
        (BindingContext as IStudentsViewModel)?.Refresh();
    }
}