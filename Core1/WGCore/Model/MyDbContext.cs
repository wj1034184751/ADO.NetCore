using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class MyDbContext : DbContext
    {
        public DbSet<JD_Commodity_001> JD_Commodity_001 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //注入Sql链接字符串
            optionsBuilder.UseSqlServer(@"Server=.;Database=MyTest1;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
