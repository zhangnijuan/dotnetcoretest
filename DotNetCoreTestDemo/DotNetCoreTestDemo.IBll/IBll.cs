

 

using System;
using System.Collections.Generic;
using System.Text;
using DotNetCoreTestDemo.Model.Models;
namespace DotNetCoreTestDemo.IBll
{
        public partial interface IRoleService:IBaseService<Role>
        {
        }
        public partial interface IUserInfoService:IBaseService<UserInfo>
        {
        }
        public partial interface IUserRoleService:IBaseService<UserRole>
        {
        }
               
}