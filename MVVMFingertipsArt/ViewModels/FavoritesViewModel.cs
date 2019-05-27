using MVVMFingertipsArt.Helpers;
using MVVMFingertipsArt.Models;
using MVVMFingertipsArt.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFingertipsArt.ViewModels
{
   public class FavoritesViewModel : Observable
    {
        private ObservableCollection<HomeItemData> _gridViewDataTemplates =null;

        public ObservableCollection<HomeItemData> Data
        {
            get
            {
                return _gridViewDataTemplates;
            }
            set
            {
                Set(ref _gridViewDataTemplates, value);
            }
        }
    }
}
