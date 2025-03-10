using MAUI.Janvas1.ViewModels;

namespace MAUI.Janvas1.Dialogs;

[QueryProperty(nameof(CourseId), "courseId")]
public partial class SCourseDetails : ContentPage
{
	public SCourseDetails()
	{
		InitializeComponent();
		BindingContext = new SCourseDetailsViewModel();
	}

	public int CourseId { get; set; }

	private void BackClicked(object sender, EventArgs e)
	{

		Shell.Current.GoToAsync("//Students");
	}

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new SCourseDetailsViewModel(CourseId);
    }
}