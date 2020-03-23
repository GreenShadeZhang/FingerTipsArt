using DataModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFingertipsArt.Models
{
   public class HomeItemData
    {
        public int OrigamiId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
        public HomeItemData(Origami origami)
        {
            this.OrigamiId = origami.Id;
            this.Title = origami.Title;
            this.Name = origami.Name;
            this.Avatar = origami.Avatar;
            this.Type = origami.Type;
            this.Status = origami.Status;
        }
    }
}
