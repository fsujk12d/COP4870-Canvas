using MAUI.Janvas1.ViewModels;

namespace MAUI.Janvas1.Dialogs;

[QueryProperty(nameof(AssignmentId), "assnId")]
public partial class AssignmentDialog : ContentPage
{
	public AssignmentDialog()
	{
		InitializeComponent();
		BindingContext = new AssignmentDialogViewModel(0);
	}

    public int AssignmentId 
    { 
        get; set; 
    }

    private void BackClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//IAssignments");
    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as AssignmentDialogViewModel)?.AddAssignment();
        //Shell.Current.GoToAsync("//IAssignments");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
		BindingContext = new AssignmentDialogViewModel(AssignmentId);
    }

    private void ContentPage_NavigatedFrom(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }
}