using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.Model
{
    public class OrigamiContext : DbContext
    {
        public DbSet<Origami> origamis { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=mynew.db");
        }
    }

    public class Origami
    {
        public int OrigamiId { get; set; }
        public string PicList { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Introduce { get; set; }
        public string Avatar { get; set; }
        public string MovieUrl { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }

    }
}
