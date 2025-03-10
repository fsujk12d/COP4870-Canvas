using MAUI.Janvas1.ViewModels;

namespace MAUI.Janvas1.Dialogs;

[QueryProperty(nameof(ContentItemId), "itemId")]
public partial class ContentItemDialog : ContentPage
{
	public ContentItemDialog()
	{
		InitializeComponent();
        BindingContext = new ContentItemDialogViewModel(0);
	}

    public int ContentItemId 
    { 
        get; set; 
    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as ContentItemDialogViewModel)?.AddContentItem();
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//IContentItems");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ContentItemDialogViewModel(ContentItemId);
    }

    private void ContentPage_NavigatedFrom(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }
}