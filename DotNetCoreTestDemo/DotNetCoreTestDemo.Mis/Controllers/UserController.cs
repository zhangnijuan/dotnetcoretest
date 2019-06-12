using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DotNetCoreTestDemo.IBll;
using DotNetCoreTestDemo.Model.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CodeFixes;

namespace DotNetCoreTestDemo.Mis.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserInfoService _userInfoService;
        public UserController(IUserInfoService userInfoService)
        {
            this._userInfoService = userInfoService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string userName, string pwd)
        {
            var user = new UserInfo()
            {
                UserName = userName,
                PassWord = pwd,
                IsDelete = false,
                Name = "张",
                Phone = "1111"

            };
            await _userInfoService.InsertAsync(user);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userName, string pwd)
        {
            var user = await _userInfoService.GetAsync(i => i.UserName == userName && i.PassWord == pwd);
            if (user!=null)
            {
                var identity = new ClaimsIdentity(new[]{new Claim("userName", userName), new Claim("Id", user.Id.ToString())},CookieAuthenticationDefaults.AuthenticationScheme);
                //identity.AddClaim(new Claim("userName",userName));
                //identity.AddClaim(new Claim("Id",user.Id.ToString()));                
                var identityUser=new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, identityUser,
                    new AuthenticationProperties()
                    {
                         AllowRefresh = false,
                        IsPersistent = true,
                        ExpiresUtc = DateTime.Now.AddMinutes(1)
                    });
            }
            return RedirectToAction("Index", "Home");
        }
    }
}