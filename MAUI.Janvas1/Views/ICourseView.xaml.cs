using MAUI.Janvas1.ViewModels;

namespace MAUI.Janvas1.Views;

public partial class ICourseView : ContentPage
{
    public ICourseView()
    {
        InitializeComponent();
        BindingContext = new ICourseViewModel();
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructors");
    }

    private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//ICourseDetails?courseId={0}");
    }

    private void EditClicked(object sender, EventArgs e)
    {
        var idParam = (BindingContext as ICourseViewModel)?.SelectedCourse?.Id;
        if (idParam != null)
        {
            Shell.Current.GoToAsync($"//ICourseDetails?courseId={idParam}");
        }
    }

    private void RemoveClicked(object sender, EventArgs e)
    {
        (BindingContext as ICourseViewModel)?.Remove();
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as ICourseViewModel)?.Refresh();
    }

    private void SearchClicked(object sender, EventArgs e)
    {
        (BindingContext as ICourseViewModel)?.Refresh();
    }

    private void AddStuToCourseClicked(object sender, EventArgs e)
    {
        var idParam = (BindingContext as ICourseViewModel)?.SelectedCourse?.Id;
        if (idParam != null)
        {
            Shell.Current.GoToAsync($"//CourseSContent?courseId={idParam}");
        }
    }

    private void AddAssnToCourseClicked(object sender, EventArgs e)
    {
        var idParam = (BindingContext as ICourseViewModel)?.SelectedCourse?.Id;
        if (idParam != null)
        {
            Shell.Current.GoToAsync($"//CourseAContent?courseId={idParam}");
        }
    }

    private void AddModToCourseClicked(object sender, EventArgs e)
    {
        var idParam = (BindingContext as ICourseViewModel)?.SelectedCourse?.Id;
        if (idParam != null)
        {
            Shell.Current.GoToAsync($"//CourseMContent?courseId={idParam}");
        }
    }

    private void ViewInfoClicked(object sender, EventArgs e)
    {
        var idParam = (BindingContext as ICourseViewModel)?.SelectedCourse?.Id;
        if (idParam != null)
        {
            Shell.Current.GoToAsync($"//ICourseInfo?courseId={idParam}");
        }
    }
}