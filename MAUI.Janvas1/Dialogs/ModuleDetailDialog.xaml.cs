using MAUI.Janvas1.ViewModels;

namespace MAUI.Janvas1.Dialogs;

[QueryProperty(nameof(ModuleId), "modId")]
public partial class ModuleDetailDialog : ContentPage
{
	public ModuleDetailDialog()
	{
		InitializeComponent();
		BindingContext = new ModuleDetailViewModel(0);
	}

    public int ModuleId { get; set; }

    private void AddClicked(object sender, EventArgs e)
    {
        (BindingContext as ModuleDetailViewModel)?.AddContentItemToModule();
        Shell.Current.GoToAsync("//IModules");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ModuleDetailViewModel(ModuleId);
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//IModules");
    }
}