using MAUI.Janvas1.ViewModels;

namespace MAUI.Janvas1.Dialogs;

[QueryProperty(nameof(CourseId), "courseId")]
public partial class CourseSDetailDialog : ContentPage
{
	public CourseSDetailDialog()
	{
		InitializeComponent();
        BindingContext = new CourseSDetailDialogViewModel(0);
	}

    public int CourseId { get; set; }

    private void AddClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseSDetailDialogViewModel)?.AddStudentToCourse();
        Shell.Current.GoToAsync("//ICourses");
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ICourses");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new CourseSDetailDialogViewModel(CourseId);
    }
}