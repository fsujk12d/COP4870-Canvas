using MAUI.Janvas1.ViewModels;

namespace MAUI.Janvas1.Views;

public partial class InstructorsView : ContentPage
{
	public InstructorsView()
	{
        InitializeComponent();
	}

    private void BackClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//MainPage");
    }

    private void CoursesClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ICourses");
    }

    private void AssignmentsClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//IAssignments");
    }

    private void StudentsClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//IStudents");
    }

    private void ModulesClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//IModules");
    }

    private void ContentClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//IContentItems");
    }

    private void GradeClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ISubmissions");
    }
}