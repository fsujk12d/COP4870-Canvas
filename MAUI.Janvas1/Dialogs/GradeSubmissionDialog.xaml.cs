using MAUI.Janvas1.ViewModels;

namespace MAUI.Janvas1.Dialogs;

[QueryProperty(nameof(SubmissionID), "subId")]
public partial class GradeSubmissionDialog : ContentPage
{
	public GradeSubmissionDialog()
	{
		InitializeComponent();
        BindingContext = new GradeSubmissionDialogViewModel(0);
	}

    public int SubmissionID { get; set; }

    private void GradeClicked(object sender, EventArgs e)
    {
        (BindingContext as GradeSubmissionDialogViewModel)?.AssignGrade();
        Shell.Current.GoToAsync("//ISubmissions");

    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ISubmissions");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new GradeSubmissionDialogViewModel(SubmissionID);

    }

    private void ContentPage_NavigatedFrom(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }
}