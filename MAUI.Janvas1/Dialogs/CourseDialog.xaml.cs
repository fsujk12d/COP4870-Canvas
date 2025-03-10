using MAUI.Janvas1.ViewModels;

namespace MAUI.Janvas1.Dialogs;

[QueryProperty(nameof(CourseId), "courseId")]
public partial class CourseDialog : ContentPage
{
	public CourseDialog()
	{
		InitializeComponent();
		BindingContext = new CourseDialogViewModel(0);
	}

    public int CourseId 
    { 
        get; set; 
    }

    private void OkClicked(object sender, EventArgs e)
    {
		(BindingContext as CourseDialogViewModel)?.AddCourse();
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ICourses");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new CourseDialogViewModel(CourseId);
    }

    private void ContentPage_NavigatedFrom(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }
}