using Maui.eCommerce.ViewModels;

namespace Maui.eCommerce.Views;

public partial class ReceiptView : ContentPage
{
    public ReceiptView()
    {
        InitializeComponent();
        BindingContext = new RecieptViewModel();
    }
}