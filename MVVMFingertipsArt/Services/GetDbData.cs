using DataModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVVMFingertipsArt.Models;
using Windows.Storage;
using Microsoft.Toolkit.Uwp.Helpers;
namespace MVVMFingertipsArt.Services
{
   public class GetDbData
    {
        public static  OrigamiDetail GetOrigamiData(int id)
        {
            Origami origami = null;
            using (var db = new OrigamiContext())
            {
            origami=db.origamis.Where(os=>os.OrigamiId==id).FirstOrDefault();
            }
            return new OrigamiDetail(origami);
        }

        public static List<HomeItemData> GetHomeData()
        {
            var homeItemdatas = new List<HomeItemData>();
            using (var db = new OrigamiContext())
            {

                foreach (var item in db.origamis)
                {
                    homeItemdatas.Add(new HomeItemData(item));
                }
                return homeItemdatas;
            }

        }


        public async static void MakeSureSqliteExsit()
        {
            var dbFile = await ApplicationData.Current.LocalFolder.TryGetItemAsync("mynew.db") as StorageFile;
            if (null == dbFile||SystemInformation.IsFirstRun)
            {

                // first time ... copy the .db file from assets to local  folder

                var localFolder = ApplicationData.Current.LocalFolder;

                var originalDbFileUri = new Uri("ms-appx:///Assets/blogging.db");

                var originalDbFile = await StorageFile.GetFileFromApplicationUriAsync(originalDbFileUri);
                // var originalDbFile = await StorageFile.GetFileFromPathAsync("/Assets/mynew.db");


                if (null != originalDbFile)

                {

                    dbFile = await originalDbFile.CopyAsync(localFolder, "mynew.db", NameCollisionOption.ReplaceExisting);

                }

            }
            else if(null!=dbFile&&SystemInformation.IsAppUpdated)
            {
                // first time ... copy the .db file from assets to local  folder

                var localFolder = ApplicationData.Current.LocalFolder;

                var originalDbFileUri = new Uri("ms-appx:///Assets/blogging.db");

                var originalDbFile = await StorageFile.GetFileFromApplicationUriAsync(originalDbFileUri);
                // var originalDbFile = await StorageFile.GetFileFromPathAsync("/Assets/mynew.db");
                if (null != originalDbFile)
                {
                    dbFile = await originalDbFile.CopyAsync(localFolder, "mynew.db", NameCollisionOption.ReplaceExisting);
                }
            }


        }

    }
}
