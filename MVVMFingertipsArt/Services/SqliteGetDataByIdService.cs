using Microsoft.Data.Sqlite;
using MVVMFingertipsArt.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFingertipsArt.Services
{
   public class SqliteGetDataByIdService
    {
        public static ObservableCollection<Picture> GetDataById1(string Id)
        {
            ObservableCollection<Picture> entries = new ObservableCollection<Picture>();
            //  string DbName = "mynew.db";
            //     base.OnNavigatedTo(e);
            // var DbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, DbName);



            using (SqliteConnection db =
                new SqliteConnection("FileName=mynew.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("select * from PicDetail", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    entries.Add(
                    
                        new Picture()
                        {
                        Id = query.GetInt32(0),
                        Name = query.GetString(1),
                        Pic1 = query.GetString(2),
                        Pic2 = query.GetString(3),
                        Pic3 = query.GetString(4),
                        Pic4 = query.GetString(5),
                        Pic5 = query.GetString(6),
                        Pic6 = query.GetString(7),
                        Movie = query.GetString(10)
                        

                    });
                        

                       
                    
                   
                }

                db.Close();
            }

            return entries;
        }


        public static Picture GetDataById(Int32 Id)
        {
            Picture entries=null;
            //  string DbName = "mynew.db";
            //     base.OnNavigatedTo(e);
            // var DbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, DbName);



            using (SqliteConnection db =
                new SqliteConnection("FileName=mynew.db"))
            {
                db.Open();

                SqliteParameter sqliteParameter = new SqliteParameter("@ID",SqliteType.Integer);
                sqliteParameter.Value = Id;
                SqliteCommand selectCommand = db.CreateCommand();
                selectCommand.CommandText = "select * from PicDetail where uuid=@ID";
                //SqliteCommand selectCommand = new SqliteCommand
                //    ("select * from PicDetail where uuid="+Id, db);
                selectCommand.Parameters.Add(sqliteParameter);
                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    entries =
                     new Picture() { Id = query.GetInt32(0),
                         Name = query.GetString(1),
                         Pic1 = query.GetString(2),
                         Pic2 = query.GetString(3),
                         Pic3 = query.GetString(4),
                         Pic4 = query.GetString(5),
                         Pic5 = query.GetString(6),
                         Pic6 = query.GetString(7),
                         Movie = query.GetString(10),
                         PicList = new ObservableCollection<Pic>()
                         {
                             //query.GetString(2),
                             //   query.GetString(3),
                             //      query.GetString(4),
                             //         query.GetString(5),
                             //            query.GetString(6),
                             //               query.GetString(7),
                             //                  query.GetString(8),
                             //                     query.GetString(9),
                                                 
                            new Pic()
                            {
                              //  Id = query.GetInt32(0),
                                 Id = 1,
                                Name = query.GetString(1),
                                Pic1 = query.GetString(2),
                                Pic2 = query.GetString(3),
                                Pic3 = query.GetString(4),
                                Pic4 = query.GetString(5),
                                Pic5 = query.GetString(6),
                                Pic6 = query.GetString(7),
                                Movie = query.GetString(10)
                            },
                             new Pic()
                            {
                                Id = 2,
                                 Name = query.GetString(1),
                                 Pic1 = query.GetString(3),
                                 Pic2 = query.GetString(3),
                                 Pic3 = query.GetString(4),
                                 Pic4 = query.GetString(5),
                                 Pic5 = query.GetString(6),
                                 Pic6 = query.GetString(7),
                                 Movie = query.GetString(10)
                            },
                              new Pic()
                            {
                                Id = 3,
                                  Name = query.GetString(1),
                                  Pic1 = query.GetString(4),
                                  Pic2 = query.GetString(3),
                                  Pic3 = query.GetString(4),
                                  Pic4 = query.GetString(5),
                                  Pic5 = query.GetString(6),
                                  Pic6 = query.GetString(7),
                                  Movie = query.GetString(10)
                            },
                               new Pic()
                            {
                                Id = 4,
                                Name = query.GetString(1),
                                Pic1 = query.GetString(5),
                                Pic2 = query.GetString(3),
                                Pic3 = query.GetString(4),
                                Pic4 = query.GetString(5),
                                Pic5 = query.GetString(6),
                                Pic6 = query.GetString(7),
                                Movie = query.GetString(10)
                            },
                                   new Pic()
                            {
                                Id = 5,
                                Name = query.GetString(1),
                                Pic1 = query.GetString(6),
                                Pic2 = query.GetString(3),
                                Pic3 = query.GetString(4),
                                Pic4 = query.GetString(5),
                                Pic5 = query.GetString(6),
                                Pic6 = query.GetString(7),
                                Movie = query.GetString(10)
                            },
                                       new Pic()
                            {
                                Id = 6,
                                Name = query.GetString(1),
                                Pic1 = query.GetString(7),
                                Pic2 = query.GetString(3),
                                Pic3 = query.GetString(4),
                                Pic4 = query.GetString(5),
                                Pic5 = query.GetString(6),
                                Pic6 = query.GetString(7),
                                Movie = query.GetString(10)
                            },
                                           new Pic()
                            {
                                Id = 7,
                                Name = query.GetString(1),
                                Pic1 = query.GetString(8),
                                Pic2 = query.GetString(3),
                                Pic3 = query.GetString(4),
                                Pic4 = query.GetString(5),
                                Pic5 = query.GetString(6),
                                Pic6 = query.GetString(7),
                                Movie = query.GetString(10)
                            },
                                               new Pic()
                            {
                                Id = 8,
                                Name = query.GetString(1),
                                Pic1 = query.GetString(9),
                                Pic2 = query.GetString(3),
                                Pic3 = query.GetString(4),
                                Pic4 = query.GetString(5),
                                Pic5 = query.GetString(6),
                                Pic6 = query.GetString(7),
                                Movie = query.GetString(10)
                            }
                         }
                     };
                }

                db.Close();
            }

            return entries;
        }
    }
}
