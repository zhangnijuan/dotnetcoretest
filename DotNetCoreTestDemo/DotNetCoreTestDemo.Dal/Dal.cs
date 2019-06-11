

 

using System;
using System.Collections.Generic;
using System.Text;
using DotNetCoreTestDemo.IDal;
using DotNetCoreTestDemo.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreTestDemo.Dal
{
         
        public partial class RoleDal:BaseDal<Role>,IRoleDal
        {
            public RoleDal(DbContext dbContext) : base(dbContext)
            {
            }
        }
         
        public partial class UserInfoDal:BaseDal<UserInfo>,IUserInfoDal
        {
            public UserInfoDal(DbContext dbContext) : base(dbContext)
            {
            }
        }
         
        public partial class UserRoleDal:BaseDal<UserRole>,IUserRoleDal
        {
            public UserRoleDal(DbContext dbContext) : base(dbContext)
            {
            }
        }
                    

}