using MAUI.Janvas1.ViewModels;
using Library.Janvas1.services;
using Library.Janvas1.Models;

namespace MAUI.Janvas1.Views;

public partial class IAssignmentView : ContentPage
{
	public IAssignmentView()
	{
        InitializeComponent();
		BindingContext = new IAssignmentViewModel();
	}

    private void BackClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//Instructors");
    }

    private void AddClicked(object sender, EventArgs e)
    {
        //var idParam = SelectedAssignment?.Id ?? 0;
        Shell.Current.GoToAsync($"//IAssignmentDetails?assnID={0}");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as IAssignmentViewModel)?.Refresh();
    }

    private void RemoveClicked(object sender, EventArgs e)
    {
        (BindingContext as IAssignmentViewModel)?.Remove();

    }

    private void EditClicked(object sender, EventArgs e) 
    {
        var idParam = (BindingContext as IAssignmentViewModel)?.SelectedAssignment?.Id;
        if (idParam != null)
        {
            Shell.Current.GoToAsync($"//IAssignmentDetails?assnId={idParam}");
        }
    }

    private void SearchClicked(object sender, EventArgs e)
    {
        (BindingContext as IAssignmentViewModel)?.Refresh();
    }
}