﻿using MVVMFingertipsArt.Helpers;
using MVVMFingertipsArt.Models;
using MVVMFingertipsArt.Services;
using MVVMFingertipsArt.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace MVVMFingertipsArt.ViewModels
{
    public class HomeViewModel : Observable
    {
        public HomeViewModel()
        {
        }
        HomeItemData gridView;
        private GridView _imagesGridView;
        public void Initialize(GridView imagesGridView)
        {
            _imagesGridView = imagesGridView;
        }
        //private List<HomeItemData> _gridViewDataTemplates = GetDbData.GetHomeData();
        private ObservableCollection<HomeItemData> _gridViewDataTemplates = new ItemsToShow();
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

        //public string LogoSource
        //{
        //    get
        //    {
        //        return ThemeSelectorService.GetLogoSource();
        //    }
        //}


        private string _logoSource = ThemeSelectorService.GetLogoSource();
        public string LogoSource
        {
            get { return _logoSource; }

            set { Set(ref _logoSource, value); }
        }

        private ObservableCollection<HomeItemData> _gridViewDataTemplates2 = null;

        public ObservableCollection<HomeItemData> Data2
        {
            get
            {
                return _gridViewDataTemplates2;
            }
            set
            {
                Set(ref _gridViewDataTemplates2, value);
            }
        }

        public async Task LoadAnimationAsync()
        {

           // var selectedImageId = await ApplicationData.Current.LocalSettings.ReadAsync<string>(ImageGallerySelectedIdKey);
           // if (!string.IsNullOrEmpty(selectedImageId))
            {
                ConnectedAnimation animation = ConnectedAnimationService.GetForCurrentView().GetAnimation("ca2");
                if (animation != null)
                {
                    //var item = _imagesGridView.Items.FirstOrDefault(i => ((Pic)i).Id.ToString() == selectedImageId);
                    //_imagesGridView.ScrollIntoView(item);
                    //_imagesGridView.ScrollIntoView(gridView);
                    await _imagesGridView.TryStartConnectedAnimationAsync(animation,gridView, "av");
                }

                //ApplicationData.Current.LocalSettings.SaveString(ImageGallerySelectedIdKey, string.Empty);
            }
        }
        public void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
         gridView = e.ClickedItem as HomeItemData;
             Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values["ID"] = gridView.OrigamiId;
            //  ApplicationData.Current.LocalSettings.SaveString("ID", gridView.Id.ToString());
              //var animation = _imagesGridView.PrepareConnectedAnimation("ca1", gridView, "av");
            ShellPage.RootFrame.Navigate(typeof(DetailPage),null, new DrillInNavigationTransitionInfo());
       
        }

 

    }
}
