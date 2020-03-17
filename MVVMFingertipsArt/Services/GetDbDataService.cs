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
using System.Collections.ObjectModel;

namespace MVVMFingertipsArt.Services
{
    public class GetDbDataService
    {
        public static string Path { get; set; }
        /// <summary>
        /// 语言区域
        /// </summary>
        public static string Lan { get; set; } = "en-us";
        public static OrigamiDetail GetOrigamiData(int id)
        {
            Origami origami = null;
            using (var db = new OrigamiContext())
            {
                //这里是传绝对路径给的数据上下文
                db.DbFilePath = Path;
                origami = db.origamis.Where(os => os.OrigamiId == id).FirstOrDefault();
            }
            return new OrigamiDetail(origami);
        }

        public static List<HomeItemData> GetHomeData()
        {
            var homeItemdatas = new List<HomeItemData>();
            using (var db = new OrigamiContext())
            {
                //这里是传绝对路径给的数据上下文
                db.DbFilePath = Path;
                foreach (var item in db.origamis)
                {
                    homeItemdatas.Add(new HomeItemData(item));
                }
                return homeItemdatas;
            }

        }
        public async static Task<List<Origami>> GetHomeDataListAsync(int pageIndex = 1, int pageSize = 9)
        {

            using (var db = new OrigamiContext())
            {
                //这里是传绝对路径给的数据上下文
                db.DbFilePath = Path;
                var blogs = await db.origamis.Where(o => o.Language == Lan).OrderByDescending(c => c.Name).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
                return blogs;
            }
        }

        public async static Task MakeSureSqliteExsitAsync()
        {
            try
            {
                var dbFile = await ApplicationData.Current.LocalFolder.TryGetItemAsync("mynew.db") as StorageFile;
                if (null == dbFile || SystemInformation.IsFirstRun || SystemInformation.IsAppUpdated)
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
                Path = dbFile.Path;
                using (var db = new OrigamiContext())
                {
                    //这里是传绝对路径给的数据上下文
                    db.DbFilePath = Path;
                    db.Database.Migrate();

                }
            }
            catch (Exception ex)
            {

            }

        }
    }
}
