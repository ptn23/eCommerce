using Maui.eCommerce.ViewModels;

namespace Maui.eCommerce.Views;

public partial class TaxView : ContentPage
{
	public TaxView()
	{
		InitializeComponent();
		BindingContext = TaxViewModel.Current;
        TaxViewModel.Current.LoadTax();
    }
	public void ConfirmClicked(object sender, EventArgs e)
	{
        TaxViewModel.Current.SaveTax();
        Shell.Current.GoToAsync("//MainPage");
    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as TaxViewModel)?.RefreshTax();
    }
}