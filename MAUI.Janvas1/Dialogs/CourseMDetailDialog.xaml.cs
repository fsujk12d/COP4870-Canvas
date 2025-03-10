using MAUI.Janvas1.ViewModels;

namespace MAUI.Janvas1.Dialogs;

[QueryProperty(nameof(CourseId), "courseId")]
public partial class CourseMDetailDialog : ContentPage
{
	public CourseMDetailDialog()
	{
		InitializeComponent();
        BindingContext = new CourseMDetailDialogViewModel(0);
	}

    public int CourseId { get; set; }

    private void AddClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseMDetailDialogViewModel)?.AddModuleToCourse();
        Shell.Current.GoToAsync("//ICourses");
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ICourses");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new CourseMDetailDialogViewModel(CourseId);
    }
}