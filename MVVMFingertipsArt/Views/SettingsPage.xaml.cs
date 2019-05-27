using System;

using MVVMFingertipsArt.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Microsoft.Advertising.WinRT.UI;
namespace MVVMFingertipsArt.Views
{
    // TODO WTS: Change the URL for your privacy policy in the Resource File, currently set to https://YourPrivacyUrlGoesHere
    public sealed partial class SettingsPage : Page
    {
       private InterstitialAd interstitialAd;
        public SettingsViewModel ViewModel { get; } = new SettingsViewModel();

        public SettingsPage()
        {
            InitializeComponent();
            //Instantiate the interstitial video ad
           interstitialAd = new InterstitialAd();

            // Attach event handlers
            interstitialAd.ErrorOccurred += OnAdError;
            interstitialAd.AdReady += OnAdReady;
            interstitialAd.Cancelled += OnAdCancelled;
            interstitialAd.Completed += OnAdCompleted;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.Initialize();
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            interstitialAd.RequestAd(AdType.Video, "9nvqf4c9m5bd", "1100049404");
        }

        //This is an event handler for the interstitial ad. It is triggered when the interstitial ad is ready to play.
        private void OnAdReady(object sender, object e)
        {
            // The ad is ready to show; show it.
            interstitialAd.Show();
        }

        // This is an event handler for the interstitial ad. It is triggered when the interstitial ad is cancelled.
        private void OnAdCancelled(object sender, object e)
        {
            //rootPage.NotifyUser("Ad cancelled", NotifyType.StatusMessage);
        }

        // This is an event handler for the interstitial ad. It is triggered when the interstitial ad has completed playback.
        private void OnAdCompleted(object sender, object e)
        {
            // rootPage.NotifyUser("Ad completed", NotifyType.StatusMessage);
        }

        // This is an error handler for the interstitial ad.
        private void OnAdError(object sender, AdErrorEventArgs e)
        {
            // rootPage.NotifyUser($"An error occurred. {e.ErrorCode}: {e.ErrorMessage}", NotifyType.ErrorMessage);
        }
    }
}
