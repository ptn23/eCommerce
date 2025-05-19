using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.eCommerce.ViewModels
{
    public class SortOptionHelper
    {
        public static List<SortOption> GetValues => Enum.GetValues(typeof(SortOption)).Cast<SortOption>().ToList();
    }
}
