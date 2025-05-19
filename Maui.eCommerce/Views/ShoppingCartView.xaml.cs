using Maui.eCommerce.ViewModels;

namespace Maui.eCommerce.Views;

public partial class ShoppingCartView : ContentPage
{
	public ShoppingCartView()
	{
		InitializeComponent();
		BindingContext = new ShoppingCartViewModel();
	}
    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ShoppingManagement");
    }
    private void CheckedOutClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Receipt");
    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as ShoppingCartViewModel)?.RefreshDisplayCart();
    }
    private void ReturnItemClicked(object sender, EventArgs e)
    {
        (BindingContext as ShoppingCartViewModel).ReturnItem();
    }
}