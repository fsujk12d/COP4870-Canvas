using MAUI.Janvas1.ViewModels;

namespace MAUI.Janvas1.Views;

public partial class ISubmissionView : ContentPage
{
	public ISubmissionView()
	{
		InitializeComponent();
        BindingContext = new ISubmissionViewModel();
	}

    private void GradeClicked(object sender, EventArgs e)
    {
        var idParam = (BindingContext as ISubmissionViewModel)?.SelectedSubmission?.SubmissionId ?? 0;
        Shell.Current.GoToAsync($"//GradeSubDialog?subId={idParam}");
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructors");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as ISubmissionViewModel)?.Refresh();
    }
}