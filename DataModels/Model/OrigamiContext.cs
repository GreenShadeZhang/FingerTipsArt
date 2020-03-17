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
            //optionsBuilder.UseSqlite("Data Source=mynew.db");
            optionsBuilder.UseSqlite($"Data Source={DbFilePath}");
        }

        /// <summary>
        /// 数据库文件的路径
        /// </summary>
        public string DbFilePath { get; set; }
    }
    public class Origami
    {
        /// <summary>
        /// 折纸的Id
        /// </summary>
        public int OrigamiId { get; set; }
        public string NameId { get; set; }
        public string PicList { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 语言
        /// </summary>
        public string Language { get; set; }
        public string Introduce { get; set; }
        public string Avatar { get; set; }
        public string MovieUrl { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }

    }
}
