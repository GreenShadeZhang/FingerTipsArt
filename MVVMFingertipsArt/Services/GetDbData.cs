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
        public  List<OrigamiDetail> GetOrigamiData()
        {
            var detail = new List<OrigamiDetail>();
            using (var db = new OrigamiContext())
            {

                foreach (var item in db.origamis)
                {
                    detail.Add(new OrigamiDetail(item));
                }
                return detail;
            }
          
        }
    }
}
