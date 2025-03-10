using MAUI.Janvas1.ViewModels;

namespace MAUI.Janvas1.Dialogs;

[QueryProperty(nameof(CourseId), "courseId")]
public partial class CourseADetailDialog : ContentPage
{
	public CourseADetailDialog()
	{
		InitializeComponent();
        BindingContext = new CourseADetailDialogViewModel(0);
	}

    public int CourseId { get; set; }

    private void AddClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseADetailDialogViewModel)?.AddAssnToCourse();
        Shell.Current.GoToAsync("//ICourses");
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ICourses");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new CourseADetailDialogViewModel(CourseId);
    }
}