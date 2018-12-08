using MVVMFingertipsArt.Helpers;
using MVVMFingertipsArt.Models;
using MVVMFingertipsArt.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace MVVMFingertipsArt.ViewModels
{
   public class ImageDetailViewModels:Observable
    {


        private static UIElement _image;
        private object _selectedImage;
      //  private ObservableCollection<GridViewDataTemplate> _source;
       // private ObservableCollection<Picture> _source;
        private Picture _source;
        public object SelectedImage
        {
            get => _selectedImage;
            set
            {
                Set(ref _selectedImage, value);
              ApplicationData.Current.LocalSettings.SaveString(DetailViewModels.ImageGallerySelectedIdKey, ((Pic)SelectedImage).Id.ToString());
            }
        }

        //public ObservableCollection<Picture> Source
        //{
        //    get => _source;
        //    set => Set(ref _source, value);
        //}
        public Picture Source
        {
            get => _source;
            set => Set(ref _source, value);
        }
        public ImageDetailViewModels()
        {
            // TODO WTS: Replace this with your actual data
           
            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            Int32 sampleImageId = (Int32)localSettings.Values["ID"];
            
            Source = null;
        }

        public void SetImage(UIElement image) => _image = image;

        public async Task InitializeAsync(Int32 sampleImageId, NavigationMode navigationMode)
        {
         
            if (!string.IsNullOrEmpty(sampleImageId.ToString()) && navigationMode == NavigationMode.New)
            {
                SelectedImage = Source.PicList.FirstOrDefault(i => i.Id == sampleImageId);
            }
            else
            {
               var selectedImageId = await ApplicationData.Current.LocalSettings.ReadAsync<string>(DetailViewModels.ImageGallerySelectedIdKey);
                if (!string.IsNullOrEmpty(selectedImageId))
                {
                    SelectedImage = Source.PicList.FirstOrDefault(i => i.Id.ToString() == selectedImageId);
                }
            }

            var animation = ConnectedAnimationService.GetForCurrentView().GetAnimation(DetailViewModels.ImageGalleryAnimationOpen);
            animation?.TryStart(_image);
        }

        public void SetAnimation()
        {
         ConnectedAnimationService.GetForCurrentView()?.PrepareToAnimate(DetailViewModels.ImageGalleryAnimationClose, _image);
        }
    }
}
