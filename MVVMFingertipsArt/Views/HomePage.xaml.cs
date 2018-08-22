using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using MVVMFingertipsArt.Models;
using MVVMFingertipsArt.Services;
using MVVMFingertipsArt.ViewModels;
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
        public HomeViewModel ViewModel { get; } = new HomeViewModel();
        private static int _persistedItemIndex = -1;
        public HomePage()
        {
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
            InitializeComponent();
            ViewModel.Initialize(HomeGrid);

        }


        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if(e.NavigationMode==NavigationMode.Back)
            {
                await ViewModel.LoadAnimationAsync();
                //ConnectedAnimation animation = ConnectedAnimationService.GetForCurrentView().GetAnimation("ca2");
                //if (animation != null)
                //{
                //    //   animation.Configuration = new DirectConnectedAnimationConfiguration();
                //    await collection.TryStartConnectedAnimationAsync(animation, _storeditem, "connectedElement");
                //}
            }
        }

        private void HomeGrid_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
        {
            args.ItemContainer.Loaded += ItemContainer_Loaded;
        }

        private void ItemContainer_Loaded(object sender, RoutedEventArgs e)
        {
           //var itemsPanel = (ItemsStackPanel)this.HomeGrid.ItemsPanelRoot;
          //  var itemsPanel = this.HomeGrid.ItemsPanelRoot;
            var itemContainer = (GridViewItem)sender;

            var itemIndex = this.HomeGrid.IndexFromContainer(itemContainer);

            var relativeIndex = itemIndex;//itemsPanel.FirstVisibleIndex;

            var uc = itemContainer.ContentTemplateRoot ;

            if (itemIndex != _persistedItemIndex && itemIndex >= 0) // && itemIndex >= itemsPanel.FirstVisibleIndex && itemIndex <= itemsPanel.LastVisibleIndex)
            {
                var itemVisual = ElementCompositionPreview.GetElementVisual(uc);
                ElementCompositionPreview.SetIsTranslationEnabled(uc, true);

                var easingFunction = Window.Current.Compositor.CreateCubicBezierEasingFunction(new Vector2(0.1f, 0.9f), new Vector2(0.2f, 1f));

                // Create KeyFrameAnimations
                var offsetAnimation = Window.Current.Compositor.CreateScalarKeyFrameAnimation();
                offsetAnimation.InsertKeyFrame(0f, 100);
                offsetAnimation.InsertKeyFrame(1f, 0, easingFunction);
                offsetAnimation.Target = "Translation.X";
                offsetAnimation.DelayBehavior = AnimationDelayBehavior.SetInitialValueBeforeDelay;
                offsetAnimation.Duration = TimeSpan.FromMilliseconds(300);
                offsetAnimation.DelayTime = TimeSpan.FromMilliseconds(relativeIndex * 100);

                var fadeAnimation = Window.Current.Compositor.CreateScalarKeyFrameAnimation();
                fadeAnimation.InsertExpressionKeyFrame(0f, "0");
                fadeAnimation.InsertExpressionKeyFrame(1f, "1");
                fadeAnimation.DelayBehavior = AnimationDelayBehavior.SetInitialValueBeforeDelay;
                fadeAnimation.Duration = TimeSpan.FromMilliseconds(300);
                fadeAnimation.DelayTime = TimeSpan.FromMilliseconds(relativeIndex * 100);

                // Start animations
                itemVisual.StartAnimation("Translation.X", offsetAnimation);
                itemVisual.StartAnimation("Opacity", fadeAnimation);
            }
            else
            {
              //  Debug.WriteLine("Skipping");
            }

            itemContainer.Loaded -= this.ItemContainer_Loaded;
        }
    }
}
