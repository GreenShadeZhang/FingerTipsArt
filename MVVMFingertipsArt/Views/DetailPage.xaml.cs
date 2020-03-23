using DataModels.Model;
using MVVMFingertipsArt.Helpers;
using MVVMFingertipsArt.Models;
using MVVMFingertipsArt.Services;
using MVVMFingertipsArt.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Windows.Input;
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
    public sealed partial class DetailPage : Page, INotifyPropertyChanged
    {
        public DetailPage()
        {
            this.InitializeComponent();
        }
        public OrigamiDetail OrigamiDetail { set; get; }
        private bool _isFav = false;
        public bool IsFav
        {
            get
            {
                return _isFav;
            }
            set
            {
                if (_isFav != value)
                {
                    _isFav = value;
                    NotifyPropertyChanged("IsFav");
                }
            }
        }
        public string favLabel;
        public string FavLabel
        {
            get
            {
                return IsFav ? "UnFavLabel".GetLocalized() : "FavLabel".GetLocalized();
            }
            set
            {
                if (favLabel != value)
                {
                    favLabel = value;
                    NotifyPropertyChanged("FavLabel");
                }
            }
        }
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            int sampleImageId = (int)e.Parameter;
            OrigamiDetail = DbDataService.GetOrigamiData(sampleImageId);
            _isFav = DbDataService.FavExists(sampleImageId);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShellPage.RootFrame.Navigate(typeof(PlayerPage), OrigamiDetail.MovieUrl);
        }

        private async void FavBtn_Click(object sender, RoutedEventArgs e)
        {
            await DbDataService.FavoriteOrigamiAsync(OrigamiDetail.OrigamiId);
        }



        private ICommand _switchFavCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand SwitchFavCommand
        {
            get
            {
                if (_switchFavCommand == null)
                {
                    _switchFavCommand = new RelayCommand<object>(
                       async (param) =>
                        {
                            await FavOrNotFavAsync((int)param, IsFav);
                            IsFav = !IsFav;
                            FavLabel = "a";
                        });
                }

                return _switchFavCommand;
            }
        }

        public async Task FavOrNotFavAsync(int id, bool flag)
        {
            if (flag)
            {
                var UnFavLabel = "UnFavLabel".GetLocalized();
                InAppNotification.Show(UnFavLabel, 3000);
                DbDataService.FavoriteOrigamiRemove(id);
            }
            else
            {
                var FavLabel = "FavLabel".GetLocalized();
                InAppNotification.Show(FavLabel, 3000);
                await DbDataService.FavoriteOrigamiAsync(id);
            }
        }
    }
}
