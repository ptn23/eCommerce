using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Library.eCommerce.Models;
using Library.eCommerce.Services;

namespace Maui.eCommerce.ViewModels
{
    public class ShoppingCartViewModel : INotifyPropertyChanged
    {
        private ProductServiceProxy inventoryService = ProductServiceProxy.Current;
        private ShoppingCartService cartService = ShoppingCartService.Current;

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (propertyName is null)
                throw new ArgumentNullException(nameof(propertyName));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ObservableCollection<Item?> Inventory
        {
            get
            {
                return new ObservableCollection<Item?>(inventoryService.Products);
            }
        }
        public string? Query { get; set; }
        public ObservableCollection<Item?> ShoppingCart
        {
            
           get
                {
                    var filteredList = cartService.CartItems.Where(p => p?.Product?.Name?.ToLower().Contains(Query?.ToLower() ?? string.Empty) ?? false);

                    filteredList = SelectedSort switch
                    {
                        SortOption.Name => filteredList.OrderBy(p => p?.Product?.Name),
                        SortOption.Price => filteredList.OrderBy(p => p?.Product?.Price),
                        _ => filteredList
                    };

                    return new ObservableCollection<Item?>(filteredList);
                }     
        }
        
        public void RefreshDisplayCart()
        {
            NotifyPropertyChanged(nameof(ShoppingCart));
            NotifyPropertyChanged(nameof(Inventory)); 
        }
        public Item? SelectedItem { get; set; }

        public void ReturnItem()
        {
            if (SelectedItem != null)
            {
                var updatedItem = cartService.Return(SelectedItem);
                var updatedInvItem = inventoryService.Return(updatedItem);
                if (updatedItem != null && updatedItem.Quantity >= 0)
                {
                    NotifyPropertyChanged(nameof(ShoppingCart));
                    NotifyPropertyChanged(nameof(Inventory)); 
                }
            }
        }

        private SortOption _selectedSort = SortOption.Name;
        public SortOption SelectedSort
        {
            get => _selectedSort;
            set
            {
                _selectedSort = value;
                NotifyPropertyChanged(nameof(ShoppingCart));
            }
        }



    }
}