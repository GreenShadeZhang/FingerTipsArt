using DataModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFingertipsArt.Models
{
   public class OrigamiDetail
    {
        public int OrigamiId { get; set; }
        public List<Pic> PicList { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Introduce { get; set; }
        public string Avatar { get; set; }
        public string MovieUrl { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
        public OrigamiDetail(Origami origami)
        {
            List<Pic> list = new List<Pic>();
           this.OrigamiId = origami.OrigamiId;
            string[] vs = origami.PicList.Split(",");
            for (int i = 0; i < vs.Length; i++)
            {
                list.Add(new Pic() { Id = i + 1, MovieUrl = vs[i] });
            }
            PicList = list;
            this.Avatar = origami.Avatar;
            this.MovieUrl = origami.MovieUrl;
            this.Title = origami.Title;
            this.Introduce = origami.Introduce;
        }
    }
}
