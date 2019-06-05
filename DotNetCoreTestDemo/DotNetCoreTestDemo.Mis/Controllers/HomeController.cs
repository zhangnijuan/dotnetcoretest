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

namespace DotNetCoreTestDemo.Mis.Controllers
{
    public class HomeController : Controller

    {
        private readonly IUserInfoService _userInfoService;
        public HomeController(IUserInfoService userInfoService)
        {
            this._userInfoService = userInfoService;
        }
        public IActionResult Index()
        {
            //UserInfo user=new UserInfo()
            //{
            //    Name = "张",
            //    UserName = "zhangnijuan",
            //    PassWord = "123456",
            //    IsDelete = false,
            //    Phone = "13345555555"
            //};
            var list1 = _userInfoService.GetList(i => true,false).ToList();
            var res = _userInfoService.DeleteAsync(list1).Result;
             var list = _userInfoService.Count(i => true);
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
