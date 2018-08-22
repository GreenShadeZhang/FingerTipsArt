using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFingertipsArt.Models
{
    public class GridViewDataTemplate
    {
        public Int32 Id { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Age { get; set; }
        public string Movie { get; set; }
        public ObservableCollection<Picture> Pic { get; set; } = new ObservableCollection<Picture>();
    }

    public class Picture
    {
        public Int32 Id { get; set; }
        public string Name { get; set; }
        public string Pic1 { get; set; }
        public string Pic2 { get; set; }
        public string Pic3 { get; set; }
        public string Pic4 { get; set; }
        public string Pic5 { get; set; }
        public string Pic6 { get; set; }
        public string PicText { get; set; }
        public string Movie { get; set; }
        public ObservableCollection<Pic> PicList { get; set; }
        //  public string Pic3 { get; set; }
        // public string Pic4 { get; set; }
    }
    public class Pic
    {
        public Int32 Id { get; set; }
        public string Name { get; set; }
        public string Pic1 { get; set; }
        public string Pic2 { get; set; }
        public string Pic3 { get; set; }
        public string Pic4 { get; set; }
        public string Pic5 { get; set; }
        public string Pic6 { get; set; }
        public string PicText { get; set; }
        public string Movie { get; set; }
    }
}
