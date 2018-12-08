using MVVMFingertipsArt.Services;
using MVVMFingertipsArt.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace MVVMFingertipsArt.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class ImageDetailPage : Page
    {
        public ImageDetailViewModels ViewModel { get; } = new ImageDetailViewModels();
        public ImageDetailPage()
        {
            this.InitializeComponent();
        ViewModel.SetImage(previewImage);
         
        }
        private void OnShowFlipViewCompleted(object sender, object e) => flipView.Focus(FocusState.Programmatic);
        protected async  override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        await  ViewModel.InitializeAsync((Int32)e.Parameter, e.NavigationMode);
            showFlipView.Begin();
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            if (e.NavigationMode == NavigationMode.Back)
            {
                previewImage.Visibility = Visibility.Visible;
                ViewModel.SetAnimation();
            }
        }
        private void OnPageKeyDown(object sender, KeyRoutedEventArgs e)
        {
            //if (e.Key == VirtualKey.Escape && NavigationService.CanGoBack)
            //{
            //    NavigationService.GoBack();
            //    e.Handled = true;
            //}
        }
    }
}
