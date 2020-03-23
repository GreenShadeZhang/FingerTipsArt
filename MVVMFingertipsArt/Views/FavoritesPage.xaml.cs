using MVVMFingertipsArt.Models;
using MVVMFingertipsArt.Services;
using MVVMFingertipsArt.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace MVVMFingertipsArt.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class FavoritesPage : Page
    {
        private ObservableCollection<FavoriteData> GridViewDataTemplates = new ObservableCollection<FavoriteData>();
        public FavoritesViewModel ViewModel { get; } = new FavoritesViewModel();
        public FavoritesPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            GridViewDataTemplates = DbDataService.FavoriteOrigamiList();

        }

        private void HomeGrid_ItemClick(object sender, ItemClickEventArgs e)
        {
            var gridView = e.ClickedItem as FavoriteData;
            ShellPage.RootFrame.Navigate(typeof(DetailPage), gridView.OrigamiId, new DrillInNavigationTransitionInfo());
        }

        private void UnfaveButton_Click(object sender, RoutedEventArgs e)
        {
            
            FavoriteData episodePointer = (FavoriteData)(sender as Button).DataContext;
            GridViewDataTemplates.Remove(episodePointer);
            DbDataService.FavoriteOrigamiRemove(episodePointer.FavId);
        }

        private void SwipeUnfavorite_Invoked(SwipeItem sender, SwipeItemInvokedEventArgs args)
        {
            if (args.SwipeControl.DataContext is FavoriteData target)
            {
                GridViewDataTemplates.Remove(target);
                DbDataService.FavoriteOrigamiRemove(target.FavId);
            }
        }
    }
}
