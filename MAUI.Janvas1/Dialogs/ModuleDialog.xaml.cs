using MAUI.Janvas1.ViewModels;

namespace MAUI.Janvas1.Dialogs;

[QueryProperty(nameof(ModuleId), "modId")]
public partial class ModuleDialog : ContentPage
{
	public ModuleDialog()
	{
		InitializeComponent();
        BindingContext = new ModuleDialogViewModel(0);
	}

    public int ModuleId 
    { 
        get; set; 
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ModuleDialogViewModel(ModuleId);

    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//IModules");
    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as ModuleDialogViewModel)?.AddModule();
        //Shell.Current.GoToAsync("//IModules");
    }

    private void ContentPage_NavigatedFrom(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }
}