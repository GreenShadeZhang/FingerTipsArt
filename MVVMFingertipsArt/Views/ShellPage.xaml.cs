using System;
using System.Threading.Tasks;
using MVVMFingertipsArt.Helpers;
using MVVMFingertipsArt.Services;
using MVVMFingertipsArt.ViewModels;

using Windows.Foundation.Metadata;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace MVVMFingertipsArt.Views
{
    // TODO WTS: Change the icons and titles for all NavigationViewItems in ShellPage.xaml.
    public sealed partial class ShellPage : Page
    {
        public static ShellPage current;
        public static Frame RootFrame = null;
        RootFrameNavigationHelper _navHelper;
        public ShellPage()
        {
            InitializeComponent();
            current = this;
            RootFrame = ContentFrame;
            _navHelper = new RootFrameNavigationHelper(ContentFrame, NavShell);
        }

        //private void OnBackgroundImageOpened(object sender, RoutedEventArgs e) =>
        //BackgroundImage.Visibility = Visibility.Visible;


        private void NavShell_ItemInvoked(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked == true)
            {
                ContentFrame.Navigate(typeof(SettingsPage), null, new DrillInNavigationTransitionInfo());
                // NavView_Navigate("settings", args.RecommendedNavigationTransitionInfo);
            }
            else if (args.InvokedItemContainer != null)
            {
                var navItemTag = args.InvokedItemContainer.Tag.ToString();

                if (navItemTag == "HomePage")
                {
                    ContentFrame.Navigate(typeof(HomePage), null, new DrillInNavigationTransitionInfo());
                }
                else if (navItemTag == "Favorite")
                {
                    ContentFrame.Navigate(typeof(FavoritesPage), null, new DrillInNavigationTransitionInfo());
                }
                else if (navItemTag == "BingPic")
                {
                    ContentFrame.Navigate(typeof(BingWallPaper), null, new DrillInNavigationTransitionInfo());
                }
            }
        }


        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            switch (e.SourcePageType)
            {
                case Type c when e.SourcePageType == typeof(HomePage):
                    ((Microsoft.UI.Xaml.Controls.NavigationViewItem)NavShell.MenuItems[0]).IsSelected = true;
                    break;
                case Type c when e.SourcePageType == typeof(BingWallPaper):
                    ((Microsoft.UI.Xaml.Controls.NavigationViewItem)NavShell.MenuItems[1]).IsSelected = true;
                    break;
                    //case Type c when e.SourcePageType == typeof(MasterDetailPage2):
                    //    ((NavigationViewItem)NavView.MenuItems[2]).IsSelected = true;
                    //    break;
                    //case Type c when e.SourcePageType == typeof(MainPage):
                    //    ((NavigationViewItem)NavView.MenuItems[3]).IsSelected = true;
                    //    break;

            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {           
            ContentFrame.Navigate(typeof(HomePage));
        }
    }
}
