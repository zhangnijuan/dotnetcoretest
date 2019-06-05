using System;
using System.Collections.Generic;
using System.Text;
using DotNetCoreTestDemo.IBll;
using DotNetCoreTestDemo.IDal;
using DotNetCoreTestDemo.Model.Models;

namespace DotNetCoreTestDemo.Bll
{
  public partial  class UserInfoService:BaseService<UserInfo>,IUserInfoService
    {
       
    }
}
