using MAUI.Janvas1.ViewModels;

namespace MAUI.Janvas1.Views;

public partial class IModulesView : ContentPage
{
	public IModulesView()
	{
		InitializeComponent();
        BindingContext = new IModulesViewModel();
	}

    private void AddClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync($"//IModuleDetails?modId={0}");
    }

    private void RemoveClicked(object sender, EventArgs e)
    {
        (BindingContext as IModulesViewModel)?.Remove();
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructors");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as IModulesViewModel)?.Refresh();
    }

    private void EditClicked(object sender, EventArgs e)
    {
        var idParam = (BindingContext as IModulesViewModel)?.SelectedModule?.Id;
        if (idParam != null)
        {
            Shell.Current.GoToAsync($"//IModuleDetails?modId={idParam}");
        }
    }

    private void SearchClicked(object sender, EventArgs e)
    {
        (BindingContext as IModulesViewModel)?.Refresh();
    }

    private void AddContentClicked(object sender, EventArgs e)
    {
        var idParam = (BindingContext as IModulesViewModel)?.SelectedModule?.Id;
        if (idParam != null)
        {
            Shell.Current.GoToAsync($"//ModContent?modId={idParam}");
        }
    }
}