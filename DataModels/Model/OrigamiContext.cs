using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModels.Model
{
    public class OrigamiContext : DbContext
    {
        public DbSet<Origami> Origamis { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
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

    public class Favorite
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int OrigamiId { get; set; }
        public DateTime CreateDate { get; set; }
        public Origami Origami { get; set; }
    }
    public class Origami
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        /// <summary>
        /// 折纸的Id
        /// </summary>
        public int Id { get; set; }
        public string NameId { get; set; }
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
