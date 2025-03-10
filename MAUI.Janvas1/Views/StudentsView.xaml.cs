using MAUI.Janvas1.ViewModels;

namespace MAUI.Janvas1.Views;

[QueryProperty(nameof(StudentId), "studetnId")]
public partial class StudentsView : ContentPage
{
	public StudentsView()
	{
		InitializeComponent();
		BindingContext = new StudentsViewModel();
	}
    
    public int StudentId { get; set; }

    private void BackClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//MainPage");
    }

    private void LoginClicked(object sender, EventArgs e)
    {
        var idParam = (BindingContext as StudentsViewModel)?.SelectedStudent?.Id;
        Shell.Current.GoToAsync($"//StudentLogin?studentId={idParam}");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new StudentsViewModel();
    }
}