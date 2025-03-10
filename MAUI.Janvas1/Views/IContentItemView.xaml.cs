using MAUI.Janvas1.ViewModels;

namespace MAUI.Janvas1.Views;

public partial class IContentItemView : ContentPage
{
	public IContentItemView()
	{
		InitializeComponent();
        BindingContext = new IContentItemsViewModel();
	}

    private void SearchClicked(object sender, EventArgs e)
    {
        (BindingContext as IContentItemsViewModel)?.Refresh();
    }

    private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//IContentItemDetails?itemId={0}");
    }

    private void EditClicked(object sender, EventArgs e)
    {
        var idParam = (BindingContext as IContentItemsViewModel)?.SelectedContentItem?.Id;
        if (idParam != null)
        {
            Shell.Current.GoToAsync($"//IContentItemDetails?itemId={idParam}");
        }
    }

    private void RemoveClicked(object sender, EventArgs e)
    {
        (BindingContext as IContentItemsViewModel)?.Remove();
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructors");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as IContentItemsViewModel)?.Refresh();
    }
}