using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spring2025_Samples.Models;

namespace Maui.eCommerce.ViewModels
{
    public class TaxViewModel : INotifyPropertyChanged
    {

        private static TaxViewModel? instance;
        public static TaxViewModel Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new TaxViewModel();
                }

                return instance;
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

        public void RefreshTax()
        {
            NotifyPropertyChanged(nameof(taxAmount));
        }

        
        public double? taxAmount{ set; get; }
        public void SaveTax()
        {
          
            if (taxAmount.HasValue)
            {
                Preferences.Set("Tax", taxAmount.Value);
            }
        }

        public void LoadTax()
        {
            taxAmount = Preferences.Get("Tax", 7.5);
        }
    }
}
