using DataModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVVMFingertipsArt.Models;

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
    }
}
