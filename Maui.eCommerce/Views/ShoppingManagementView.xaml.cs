using Library.eCommerce.Models;
using Maui.eCommerce.ViewModels;

namespace Maui.eCommerce.Views;

public partial class ShoppingManagementView : ContentPage
{
    public ShoppingManagementView()
    {
        InitializeComponent();
        BindingContext = new ShoppingManagementViewModel();
    }
    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
    private void ShoppingCartClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ShoppingCart");
    }

    private void ContentPage_NavigatedTo(object sender, EventArgs e)
    {
        (BindingContext as ShoppingManagementViewModel).RefreshInventory();
    }
    private void CheckedOutClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Receipt");
    }
    private void EditAmount(object sender, EventArgs e)
    {
        var button = sender as Button;
        var item = button?.CommandParameter as Item;
        (BindingContext as ShoppingManagementViewModel)?.AddProduct(item);
    }
}