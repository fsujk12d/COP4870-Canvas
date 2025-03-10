using MAUI.Janvas1.ViewModels;

namespace MAUI.Janvas1.Views;

[QueryProperty(nameof(CourseId), "courseId")]
[QueryProperty(nameof(AssignmentId), "assignmentId")]
[QueryProperty(nameof(StudentId), "studentId")]
public partial class StudentDetailView : ContentPage
{
	public StudentDetailView()
	{
		InitializeComponent();
        BindingContext = new StudentDetailViewModel(0);
	}

    public int CourseId { get; set; }

    public int AssignmentId { get; set; }

    public int StudentId { get; set; }

    private void ViewCourseClicked(object sender, EventArgs e)
    {
        var idParam = (BindingContext as StudentDetailViewModel)?.SelectedCourse?.Id ?? 0;
        Shell.Current.GoToAsync($"//SCourse?courseId={idParam}");
    }

    private void SubmitClicked(object sender, EventArgs e)
    {
        var idParam = (BindingContext as StudentDetailViewModel)?.SelectedAssignment?.Id ?? 0;
        Shell.Current.GoToAsync($"//SSubmitAssignment?assignmentId={idParam}");
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//Students");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new StudentDetailViewModel(StudentId);
    }
}