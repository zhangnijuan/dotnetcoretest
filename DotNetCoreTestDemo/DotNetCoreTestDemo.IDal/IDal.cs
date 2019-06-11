
 
using System;
using System.Collections.Generic;
using System.Text;
using DotNetCoreTestDemo.Model.Models;

namespace DotNetCoreTestDemo.IDal
{
        public partial interface IRoleDal:IBaseDal<Role>
        {
        }public partial interface IUserInfoDal:IBaseDal<UserInfo>
        {
        }public partial interface IUserRoleDal:IBaseDal<UserRole>
        {
        }            
}


