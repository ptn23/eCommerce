using Library.eCommerce.Models;
using Library.eCommerce.Services;
using Spring2025_Samples.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Maui.eCommerce.ViewModels
{
    public class InventoryManagementViewModel : INotifyPropertyChanged
    {
        private ProductServiceProxy _svc = ProductServiceProxy.Current;

        public Item? SelectedProduct { get; set; }
        public string? Query { get; set; }

        private SortOption _selectedSort = SortOption.Name;
        public SortOption SelectedSort
        {
            get => _selectedSort;
            set
            {
                _selectedSort = value;
                NotifyPropertyChanged();
                RefreshProductList();
            }
        }

        public ObservableCollection<Item?> Products
        {
            get
            {
                var filteredList = _svc.Products
                    .Where(p => p?.Product?.Name?.ToLower().Contains(Query?.ToLower() ?? string.Empty) ?? false);

                filteredList = SelectedSort switch
                {
                    SortOption.Name => filteredList.OrderBy(p => p?.Product?.Name),
                    SortOption.Price => filteredList.OrderBy(p => p?.Product?.Price),
                    _ => filteredList
                };

                return new ObservableCollection<Item?>(filteredList);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RefreshProductList()
        {
            NotifyPropertyChanged(nameof(Products));
        }

        public Item? Delete()
        {
            var item = _svc.Delete(SelectedProduct?.Id ?? 0);
            RefreshProductList();
            return item;
        }

        public void AddProduct(Item? item)
        {
            if (item != null)
            {
                item.Quantity++;
                NotifyPropertyChanged(nameof(_svc));
                RefreshProductList();
            }
        }
    }
}