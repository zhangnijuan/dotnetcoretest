using System;
using System.Collections.Generic;
using System.Text;
using DotNetCoreTestDemo.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetCoreTestDemo.Model.Maps
{
   public class RoleMap:IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.RoleName).HasMaxLength(16).IsRequired();
            builder.Property(i => i.IsDelete).IsRequired();
            builder.HasMany(i => i.UserRole).WithOne(i => i.Role).HasForeignKey(i => i.RoleId);
        }
    }
}
