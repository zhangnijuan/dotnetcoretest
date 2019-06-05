using System;
using System.Collections.Generic;
using System.Text;
using DotNetCoreTestDemo.IDal;
using DotNetCoreTestDemo.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreTestDemo.Dal
{
   public partial class UserInfoDal:BaseDal<UserInfo>,IUserInfoDal
    {
       
    }
}
