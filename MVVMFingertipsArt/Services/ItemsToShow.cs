using MVVMFingertipsArt.Models;
using MVVMFingertipsArt.Views;
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

namespace MVVMFingertipsArt.Services
{
    public class ItemsToShow : ObservableCollection<Models.HomeItemData>, ISupportIncrementalLoading
    {
        public int lastItem = 1;
        public int index = 1;
        public int totalCount = 2;
        public bool HasMoreItems
        {
            get
            {
                if (lastItem > totalCount)
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
            //ProgressRing progressBar = HomePage.Blank.MyProperty;

            CoreDispatcher coreDispatcher = Window.Current.Dispatcher;

            return Task.Run(async () =>
            {
                var res = await DbDataService.GetHomeDataListAsync(index, 9);
                index++;
                //totalCount = res.ItemCount;
                //var homeItemdatas = new ObservableCollection<HomeItemData>();

                ////this.Add();
                //lastItem += res.Count;
                //await coreDispatcher.RunAsync(CoreDispatcherPriority.Normal,
                //  () =>
                //  {
                //      foreach (var item in res)
                //      {
                //          this.Add(new HomeItemData(item));
                //      }
                //      progressBar.Visibility = Visibility.Collapsed;
                //      progressBar.IsActive = false;
                //  });

                return new LoadMoreItemsResult() { Count = count };
            }).AsAsyncOperation<LoadMoreItemsResult>();
        }
    }
}
