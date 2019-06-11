using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using DotNetCoreTestDemo.Bll;
using DotNetCoreTestDemo.Dal;
using DotNetCoreTestDemo.IBll;
using Microsoft.AspNetCore.Mvc;
using DotNetCoreTestDemo.Mis.Models;
using DotNetCoreTestDemo.Model.Models;
using log4net;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreTestDemo.Mis.Controllers
{
    public class HomeController : Controller

    {
        private readonly IUserInfoService _userInfoService;
        private readonly IRoleService _roleService;
        private readonly IUserRoleService _userRoleService;
        private ILog log = LogManager.GetLogger(Startup.Repository.Name, typeof(HomeController));
        public HomeController(IUserInfoService userInfoService, IRoleService roleService, IUserRoleService userRoleService)
        {
            this._userInfoService = userInfoService;
            this._roleService = roleService;
            this._userRoleService = userRoleService;
        }
        public IActionResult Index()
        {
            //  UserInfo user = new UserInfo()
            //  {
            //      Name = "张",
            //      UserName = "zhangnijuan",
            //      PassWord = "123456",
            //      IsDelete = false,
            //      Phone = "13345555555"
            //  };
            //var flag=  _userInfoService.InsertAsync(user).Result;
            // Role role=new Role()
            // {
            //     RoleName = "管理员",
            //     IsDelete = false
            // };
            //var  flag = _roleService.InsertAsync(role).Result;
            //UserRole ur=new UserRole()
            //{
            //    RoleId = role.Id,
            //    UserId = user.Id
            //};
            //flag = _userRoleService.InsertAsync(ur).Result;
            //var ur = _userRoleService.GetList(i => true,false).Include(i=>i.Role).Include(i=>i.UserInfo).FirstOrDefault();

            //_userRoleService.Delete(ur);
            log.Error(222222222);
            int c = 0;
            var a = 1 / c;
           
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
