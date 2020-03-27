using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.Helpers;
using MVVMFingertipsArt.Models;
using MVVMFingertipsArt.Services;
using MVVMFingertipsArt.ViewModels;
using Windows.Globalization;
using Windows.Storage;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace MVVMFingertipsArt.Views
{
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
            InitializeComponent();
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                HomeRing.IsActive = true;
                var res = await DbDataService.GetHomeDataListAsync(0, 100);
                var homeItemdatas = new ObservableCollection<HomeItemData>();
                foreach (var item in res)
                {
                    homeItemdatas.Add(new HomeItemData(item));
                }
                HomeGrid.ItemsSource = homeItemdatas;
                HomeRing.IsActive = false;
            }
            catch (Exception ex)
            {

            }
        }
        private void HomeGrid_ItemClick(object sender, ItemClickEventArgs e)
        {
            var gridView = e.ClickedItem as HomeItemData;
            ShellPage.RootFrame.Navigate(typeof(DetailPage), gridView.OrigamiId, new DrillInNavigationTransitionInfo());
        }
    }
}
