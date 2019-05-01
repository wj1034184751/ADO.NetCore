
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace EFMYSQL
{
    public class MyDbContext : DbContext
    {
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<T_Books> T_Books { get; set; }
        public DbSet<T_Author> T_Author { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //注入Sql链接字符串
            optionsBuilder.UseMySql(@"Server=127.0.0.1;Database=mysql;Uid=root;Pwd=1034184751");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            base.OnModelCreating(modelBuilder);
            //var ctPerson = modelBuilder.Entity<UserInfo>();
            //ctPerson.ToTable("userinfo");
            //modelBuilder.Entity<UserInfo>().ToTable("Userinfo");
            //modelBuilder.Entity<T_Books>().ToTable("books").
            //    HasOne(e => e.Author).WithMany().HasForeignKey(e => e.AuthorId).IsRequired();
            //modelBuilder.Entity<T_Author>().ToTable("author");
            modelBuilder.AddEntityConfigurationsFromAssembly(Assembly.Load("EFMYSQL"));
        }
    }
}
