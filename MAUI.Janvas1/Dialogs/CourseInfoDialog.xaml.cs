
using MAUI.Janvas1.ViewModels;

namespace MAUI.Janvas1.Dialogs;

public partial class CourseInfoDialog : ContentPage
{
	public CourseInfoDialog()
	{
		InitializeComponent();
		BindingContext = new CourseInfoDialogViewModel(0);

    }

    public int CourseId { get; set; }

    private void BackClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//ICourses");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
		BindingContext = new CourseInfoDialogViewModel(CourseId);

    }

    private void ContentPage_NavigatedFrom(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }
}