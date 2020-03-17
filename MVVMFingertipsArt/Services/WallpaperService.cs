using MVVMFingertipsArt.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace MVVMFingertipsArt.Services
{
   public class WallpaperService
    {

        public async Task<WallpapersData> GetWallparper(int index, int number)
        {
            // string url = "https://cn.bing.com/HPImageArchive.aspx?format=js&idx=8&n=25";
            string json = string.Empty;
            string url = string.Format("https://www.bing.com/HPImageArchive.aspx?format=js&idx={0}&n={1}", index, number);
            Uri uri = new Uri(url);
            using (var httpClient = new HttpClient())
            {
                json = await httpClient.GetStringAsync(uri);
            }
              
            WallpapersData wallPapersData = JsonConvert.DeserializeObject<WallpapersData>(json);
            return wallPapersData;
        }
    }
}
