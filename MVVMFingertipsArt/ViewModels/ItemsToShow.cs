using MVVMFingertipsArt.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace MVVMFingertipsArt.ViewModels
{
   public class ItemsToShow: ObservableCollection<HomeItemData>, ISupportIncrementalLoading
    {
        public int lastItem = 1;

        public bool HasMoreItems
        {
            get
            {
                if (lastItem > 100)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            //ProgressBar progressBar = BlankPage1.Blank.MyProperty;

            CoreDispatcher coreDispatcher = Window.Current.Dispatcher;

            return Task.Run(async () =>
            {
                await coreDispatcher.RunAsync(CoreDispatcherPriority.Normal,
                    () =>
                    {
                        //progressBar.IsIndeterminate = true;
                        //progressBar.Visibility = Visibility.Visible;
                    });

                //List<string> items = new List<string>();
                //for (int i = 0; i < 100; i++)
                //{
                //    items.Add(String.Format("Item {0}", i.ToString()));
                //    lastItem++;
                //    //if (lastItem == 10000)
                //    //{
                //    //    break;
                //    //}
                //}
                // List<Model.WallPaper> wallPapers = new List<Model.WallPaper>();
                //var res = await GetWallpaper.GetWallpaperMethod();
                //lastItem += res.Count;
                await coreDispatcher.RunAsync(CoreDispatcherPriority.Normal,
                  () =>
                  {


                      //foreach (var item in res)
                      //{
                      //    this.Add(item);
                      //}
                      //progressBar.Visibility = Visibility.Collapsed;
                      //progressBar.IsIndeterminate = false;
                  });

                return new LoadMoreItemsResult() { Count = count };
            }).AsAsyncOperation<LoadMoreItemsResult>();
        }
    }
}
