using MVVMFingertipsArt.Helpers;
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
        GridViewDataTemplate gridView;
        private GridView _imagesGridView;
        public void Initialize(GridView imagesGridView)
        {
            _imagesGridView = imagesGridView;
        }
        private ObservableCollection<GridViewDataTemplate> _gridViewDataTemplates = SqliteGetdataService.GetData();

        public ObservableCollection<GridViewDataTemplate> Data
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


        private ObservableCollection<GridViewDataTemplate> _gridViewDataTemplates2 = SqliteGetdataService.GetData();

        public ObservableCollection<GridViewDataTemplate> Data2
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
         gridView = e.ClickedItem as GridViewDataTemplate;
            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values["ID"] = gridView.Id;
            //  ApplicationData.Current.LocalSettings.SaveString("ID", gridView.Id.ToString());
              var animation = _imagesGridView.PrepareConnectedAnimation("ca1", gridView, "av");
            NavigationService.Frame.Navigate(typeof(DetailPage));
       
        }

 

    }
}
