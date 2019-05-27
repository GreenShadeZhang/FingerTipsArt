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
    public class DetailViewModels : Observable
    {


        public HomeItemData Data { set; get; }

        private static UIElement _image;


        public  int Id { get; set; }
        public const string ImageGallerySelectedIdKey = "ImageGallerySelectedIdKey";
        public const string ImageGalleryAnimationOpen = "ImageGallery_AnimationOpen";
        public const string ImageGalleryAnimationClose = "ImageGallery_AnimationClose";

        private OrigamiDetail _source=null;
        private ICommand _itemSelectedCommand;
        private GridView _imagesGridView;
        public ObservableCollection<OrigamiDetail> So { get; set; }
        public OrigamiDetail Source
        {
            get => _source;
            set => Set(ref _source, value);
        }

        public void SetImage(UIElement image) => _image = image;
        public ICommand ItemSelectedCommand => _itemSelectedCommand ?? (_itemSelectedCommand = new RelayCommand<ItemClickEventArgs>(OnsItemSelected));

        public DetailViewModels()
        {
            // TODO WTS: Replace this with your actual data
         
            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
          Int32  sampleImageId = (Int32)localSettings.Values["ID"];
            _source = GetDbData.GetOrigamiData(sampleImageId);
           // Source = null;
        }

        public void Initialize(GridView imagesGridView)
        {
            _imagesGridView = imagesGridView;
        }


        public void InitializeId(int id)
        {
            Id = id;
        }
        public async Task LoadAnimationAsync()
        {     
            var selectedImageId = await ApplicationData.Current.LocalSettings.ReadAsync<string>(ImageGallerySelectedIdKey);
            if (!string.IsNullOrEmpty(selectedImageId))
            {
                var animation = ConnectedAnimationService.GetForCurrentView().GetAnimation(ImageGalleryAnimationClose);
                if (animation != null)
                {
                    var item = _imagesGridView.Items.Where(i => ((Pic)i).Id .ToString()== selectedImageId);
                    _imagesGridView.ScrollIntoView(item);
                    await _imagesGridView.TryStartConnectedAnimationAsync(animation, item, "ItemThumbnail");
                }

                //ApplicationData.Current.LocalSettings.SaveString(ImageGallerySelectedIdKey, string.Empty);
            }
        }
     

        private void OnsItemSelected(ItemClickEventArgs args)
        {
            var selected = args.ClickedItem as Pic;
          
             //imagesGridView.PrepareConnectedAnimation(ImageGalleryAnimationOpen, selected, "ItemThumbnail");
            ShellPage.RootFrame.Navigate(typeof(ImageDetailPage),selected.Id, new DrillInNavigationTransitionInfo());
        }

       



    }
}
