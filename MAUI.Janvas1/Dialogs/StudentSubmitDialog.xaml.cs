using MAUI.Janvas1.ViewModels;

namespace MAUI.Janvas1.Dialogs;

public partial class StudentSubmitDialog : ContentPage
{
	public StudentSubmitDialog()
	{
		InitializeComponent();
        BindingContext = new StudentSubmitDialogViewModel(0);
	}

    private void AddClicked(object sender, EventArgs e)
    {
        (BindingContext as StudentSubmitDialogViewModel)?.SubmitAssignment();
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Students");
    }
}