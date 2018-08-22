using Microsoft.Data.Sqlite;
using MVVMFingertipsArt.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace MVVMFingertipsArt.Services
{
   public class SqliteGetdataService
    {


        public async static void MakeSureSqliteExsit()
        {
            var dbFile = await ApplicationData.Current.LocalFolder.TryGetItemAsync("mynew.db") as StorageFile;
            if (null == dbFile)

            {

                // first time ... copy the .db file from assets to local  folder

                var localFolder = ApplicationData.Current.LocalFolder;

                var originalDbFileUri = new Uri("ms-appx:///Assets/mynew.db");

                var originalDbFile = await StorageFile.GetFileFromApplicationUriAsync(originalDbFileUri);
                // var originalDbFile = await StorageFile.GetFileFromPathAsync("/Assets/mynew.db");


                if (null != originalDbFile)

                {

                    dbFile = await originalDbFile.CopyAsync(localFolder, "mynew.db", NameCollisionOption.ReplaceExisting);

                }

            }
          
        }

        public static ObservableCollection<GridViewDataTemplate> GetData()
        {
            ObservableCollection<GridViewDataTemplate> entries = new ObservableCollection<GridViewDataTemplate>();
   


            using (SqliteConnection db =
                new SqliteConnection("FileName=mynew.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("select * from name", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    entries.Add(
                        new GridViewDataTemplate() { Id=query.GetInt32(3) ,Name = query.GetString(0), Avatar = query.GetString(1), Age = query.GetString(4), Movie = query.GetString(5),
                            Pic = new ObservableCollection<Picture>() {
                                new Picture() { Pic1 = query.GetString(1), PicText = query.GetString(1)},
                            new Picture() { Pic1 = query.GetString(1), PicText = query.GetString(1)},
                            new Picture() { Pic1 = query.GetString(1), PicText = query.GetString(1)},
                            new Picture() { Pic1 = query.GetString(1), PicText = query.GetString(1)}} });
                }

                db.Close();
            }

            return entries;
        }

    }
}
