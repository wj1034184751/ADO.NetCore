using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Model
{
    public class MyDbContext : DbContext
    {
        public DbSet<JD_Commodity_001> JD_Commodity_001 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //注入Sql链接字符串
            optionsBuilder.UseSqlServer(@"Server=.;Database=MyTest1;Trusted_Connection=True;Uid=sa;Pwd=1034184751");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
