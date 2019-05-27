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
using Windows.UI.Xaml.Hosting;
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
    public sealed partial class DetailPage : Page
    {
        public DetailViewModels ViewModel { get; } = new DetailViewModels();
        public DetailPage()
        {
            this.InitializeComponent();
          //  this.NavigationCacheMode = NavigationCacheMode.Enabled;
            ViewModel.Initialize(gridView);


        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ConnectedAnimation imageAnimation = ConnectedAnimationService.GetForCurrentView().GetAnimation("ca1");
            if (imageAnimation != null)
            {
                  CreateImplicitAnimations();
                imageAnimation.Completed += ImageAnimation_Completed;
                imageAnimation.TryStart(HereElement, new UIElement[] { HeroDetailsElement });

            }
            if (e.NavigationMode == NavigationMode.Back)
            {
                await ViewModel.LoadAnimationAsync();
            }

        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            if (e.NavigationMode == NavigationMode.Back)
            {
                ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("ca2", HereElement);
            }
         
        }
        // Choreographed animations:
        Windows.UI.Composition.Compositor _compositor = null;
        void FetchCompositor()
        {
            if (_compositor == null)
                _compositor = ElementCompositionPreview.GetElementVisual(this).Compositor;
        }

        void CreateImplicitAnimations()
        {
            FetchCompositor();
            // moreInfoPanel.Visibility = Visibility.Collapsed;
           gridView.Visibility = Visibility.Collapsed;
            // Animate the header background scale when it first shows.
            var scaleHeaderAnimation = _compositor.CreateScalarKeyFrameAnimation();
            scaleHeaderAnimation.InsertKeyFrame(0, .5f);
            scaleHeaderAnimation.InsertKeyFrame(1, 1f);
            scaleHeaderAnimation.Duration = TimeSpan.FromSeconds(.25);
            scaleHeaderAnimation.Target = "Scale.Y";

           // ElementCompositionPreview.SetImplicitShowAnimation((TextBlock)gridView.Header, scaleHeaderAnimation);

            // Animate the "more info" panel when it first shows.
            var fadeMoreInfoPanel = _compositor.CreateScalarKeyFrameAnimation();
            fadeMoreInfoPanel.InsertKeyFrame(0, 0f);
            fadeMoreInfoPanel.InsertKeyFrame(1, 1f);
            fadeMoreInfoPanel.Duration = TimeSpan.FromSeconds(.5);
            fadeMoreInfoPanel.Target = "Opacity";

            ElementCompositionPreview.SetImplicitShowAnimation(gridView, fadeMoreInfoPanel);
        }
        // Toggle the panel to visible after the connected animation completes. 
        private void ImageAnimation_Completed(ConnectedAnimation sender, object args)
        {
            gridView.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShellPage.RootFrame.Navigate(typeof(PlayerPage),ViewModel.Source.MovieUrl);
        }

    }
}
