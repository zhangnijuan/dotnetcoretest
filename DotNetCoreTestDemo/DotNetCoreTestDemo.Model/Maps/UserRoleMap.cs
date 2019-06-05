using System;
using System.Collections.Generic;
using System.Text;
using DotNetCoreTestDemo.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetCoreTestDemo.Model.Maps
{
   public class UserRoleMap:IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRole");
            builder.HasKey(i => new { i.UserId, i.RoleId });
        }
    }
}
