using DataModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFingertipsArt.Models
{
    public class FavoriteData
    {
        public int FavId { get; set; }
        public int OrigamiId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
        public FavoriteData()
        {

        }
        public FavoriteData(Favorite favorite)
        {
            FavId = favorite.Id;
            CreateDate = favorite.CreateDate;
            this.OrigamiId = favorite.Origami.Id;
            this.Title = favorite.Origami.Title;
            this.Name = favorite.Origami.Name;
            this.Avatar = favorite.Origami.Avatar;
            this.Type = favorite.Origami.Type;
            this.Status = favorite.Origami.Status;
        }
    }
}
