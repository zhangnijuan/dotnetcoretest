using System;
using System.Collections.Generic;
using System.Text;
using DotNetCoreTestDemo.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetCoreTestDemo.Model.Maps
{
  public class UserInfoMap:IEntityTypeConfiguration<UserInfo>
    {
        public void Configure(EntityTypeBuilder<UserInfo> builder)
        {
            builder.ToTable("UserInfo");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.UserName).HasMaxLength(24).IsRequired();
            builder.Property(i => i.PassWord).HasMaxLength(24).IsRequired();
            builder.Property(i => i.Name).HasMaxLength(8).IsRequired();            
            builder.Property(i => i.Phone).HasMaxLength(16).IsRequired();
            builder.Property(i => i.IsDelete).IsRequired();
            builder.Property(i => i.CreateTime).HasColumnType("datetime").IsRequired();
            builder.HasMany(i => i.UserRole).WithOne(i => i.UserInfo).HasForeignKey(i => i.UserId);
        }
    }
}
