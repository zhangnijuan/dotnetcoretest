using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreTestDemo.Model.Models
{
   public class UserRole
    {
        public int UserId { get; set; }
        public UserInfo UserInfo { get; set; }
        public  int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
