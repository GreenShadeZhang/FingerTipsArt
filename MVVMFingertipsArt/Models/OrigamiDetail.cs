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
        public string Title { get; set; }
        public string Name { get; set; }
        public string Introduce { get; set; }
        public string Avatar { get; set; }
        public string MovieUrl { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
        public OrigamiDetail(Origami origami)
        {
           this.OrigamiId = origami.Id;       
            this.Avatar = origami.Avatar;
            this.MovieUrl = origami.MovieUrl;
            this.Title = origami.Title;
            this.Introduce = origami.Introduce;
        }
    }
}
