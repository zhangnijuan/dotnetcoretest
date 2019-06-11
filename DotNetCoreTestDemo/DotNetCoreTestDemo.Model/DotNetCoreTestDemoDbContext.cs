using System;
using System.Collections.Generic;
using System.Text;
using DotNetCoreTestDemo.Model.Maps;
using DotNetCoreTestDemo.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreTestDemo.Model
{
   public class DotNetCoreTestDemoDbContext:DbContext
    {
        public DotNetCoreTestDemoDbContext(DbContextOptions<DotNetCoreTestDemoDbContext> options):base(options)
        {
            
        }
        public DotNetCoreTestDemoDbContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
           // optionsBuilder.UseSqlServer(@"server=DESKTOP-FG2KKB5\ZHANGNIJUAN;Database=DotNetCoreTestDemo;Integrated Security=True;uid=sa;pwd=123456");
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserInfoMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new UserRoleMap());
        }

        public virtual DbSet<UserInfo> UserInfos { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
    }
}
