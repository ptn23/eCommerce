using Library.eCommerce.Models;
using Library.eCommerce.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Maui.eCommerce.ViewModels
{
     public class ShoppingManagementViewModel : INotifyPropertyChanged
    {
        private ProductServiceProxy _invSvc = ProductServiceProxy.Current;
        private ShoppingCartService _cartSvc = ShoppingCartService.Current;
        public Item? SelectedItem { get; set; }

        public ObservableCollection<Item?> Inventory
        {
            get
            {
                return new ObservableCollection<Item?>(_invSvc.Products);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (propertyName is null)
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RefreshInventory()
        {
            NotifyPropertyChanged(nameof(Inventory));
        }
        public void AddProduct(Item? item)
        {
            var existingInvItem = _invSvc.GetById(item.Id);
            if (existingInvItem == null || existingInvItem.Quantity == 0)
            {
                return;
            }

            if (existingInvItem != null)
            {
                existingInvItem.Quantity--;
            }
            var existingItem = _cartSvc.CartItems.FirstOrDefault(i => i.Id == item.Id);
            if (existingItem == null)
            {
                var newItem = new Item(item);
                newItem.Quantity = 1;
                newItem.Price = item.Price;
                _cartSvc.CartItems.Add(newItem);
            }
            else
            {
                existingItem.Quantity++;
            }
            NotifyPropertyChanged(nameof(Inventory));
        }
    }
}