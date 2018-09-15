using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFingertipsArt.Services
{
    public class SqliteInsertDataService
    {
        public static string InsertDataById(Int32 Id)
        {
            // Picture entries = null;
            //  string DbName = "mynew.db";
            //     base.OnNavigatedTo(e);
            // var DbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, DbName);



            using (SqliteConnection db =
                new SqliteConnection("FileName=mynew.db"))
            {
                db.Open();

                SqliteParameter sqliteParameter = new SqliteParameter("@ID", SqliteType.Integer);
                sqliteParameter.Value = Id;
                SqliteCommand selectCommand = db.CreateCommand();
                selectCommand.CommandText = "insert into favorites select * from PicDetail where uuid=@ID";
                //SqliteCommand selectCommand = new SqliteCommand
                //    ("select * from PicDetail where uuid="+Id, db);
                selectCommand.Parameters.Add(sqliteParameter);
                selectCommand.ExecuteNonQuery();

                return "插入成功";
               // SqliteDataReader query = selectCommand.ExecuteReader();
            }
        }
    }
}
