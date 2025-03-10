using MAUI.Janvas1.ViewModels;

namespace MAUI.Janvas1.Dialogs;

[QueryProperty(nameof(PersonId), "personId")]
public partial class StudentDialog : ContentPage
{
	public StudentDialog()
	{
		InitializeComponent();
        BindingContext = new StudentDialogViewModel(0);

	}

    public int PersonId
    {
        get; set;
    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as StudentDialogViewModel)?.AddStudent();
        //Shell.Current.GoToAsync("//IStudents");
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//IStudents");
    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new StudentDialogViewModel(PersonId);
    }
    private void ContentPage_NavigatedFrom(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }
}