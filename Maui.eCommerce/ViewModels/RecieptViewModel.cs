using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.eCommerce.Models;
using Library.eCommerce.Services;

namespace Maui.eCommerce.ViewModels
{
    public class RecieptViewModel : ShoppingManagementViewModel
    {
        public List<Item> CartItems => ShoppingCartService.Current.CartItems;
        public double? taxAmount = TaxViewModel.Current.taxAmount;
        public double? amount
        {
            get
            {
                double? sum = 0;
                double? taxed = 0;
                foreach (var item in CartItems)
                    sum += item.Quantity * item.Price;
                if (taxAmount == null)
                {
                    taxed = sum * 7.5 / 100;
                }
                else
                {
                    taxed = sum * taxAmount / 100;
                }
                sum += taxed;
                return sum;
            }
        }
    }
}
