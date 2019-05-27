using MVVMFingertipsArt.Models;
using MVVMFingertipsArt.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace MVVMFingertipsArt.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class BingWallPaper : Page
    {
        public BingWallPaper()
        {
            this.InitializeComponent();
        }
        private WallpapersDetail wallpapers;
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            Pro.Visibility = Visibility.Visible;
            Pro.IsActive = true;
            WallpaperService wallpaperService = new WallpaperService();
            WallpapersData wallpapersData = await wallpaperService.GetWallparper(0, 9);
            //此集合为GridView的source
            ObservableCollection<WallpapersDetail> picModels = new ObservableCollection<WallpapersDetail>();
            //通过重新组装成集合给GridView
            foreach (var item in wallpapersData.images)
            {
                picModels.Add(new WallpapersDetail()
                {
                    Title = item.copyright,
                    Source = "https://www.bing.com" + item.url,
                    FileName = item.enddate

                });
            }
            Gv.ItemsSource = picModels;
            Pro.Visibility = Visibility.Collapsed;
            Pro.IsActive = false;
            base.OnNavigatedTo(e);

        }

        private void MenuFlyout_Opening(object sender, object e)
        {
            var a = sender as MenuFlyout;
            var b = a.Target as GridViewItem;
            wallpapers = b.Content as WallpapersDetail;

        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Pro.Visibility = Visibility.Visible;
                Pro.IsActive = true;
                Uri uri2 = new Uri(wallpapers.Source);
                var httpClientPicData = new HttpClient();
                var adc = await httpClientPicData.GetBufferAsync(uri2);
                StorageFolder destinationFolder = await KnownFolders.PicturesLibrary.CreateFolderAsync("FingertipsArt", CreationCollisionOption.OpenIfExists);
                var destinationFile = await destinationFolder.CreateFileAsync(wallpapers.FileName + ".jpg", CreationCollisionOption.ReplaceExisting);
                await FileIO.WriteBufferAsync(destinationFile, adc);
                ExampleInAppNotification.Show("保存" + wallpapers.FileName + ".jpg" + "成功", 2000);
                Pro.Visibility = Visibility.Collapsed;
                Pro.IsActive = false;
                //MessageDialog messageDialog = new MessageDialog("图片已保存到图库", "恭喜你");
                //await messageDialog.ShowAsync();
            }
            catch
            {
                ExampleInAppNotification.Show("保存出错，请检查网络。", 3000);
                //MessageDialog messageDialog = new MessageDialog("保存出错", "抱歉");
                //await messageDialog.ShowAsync();
            }

        }
    }
}
