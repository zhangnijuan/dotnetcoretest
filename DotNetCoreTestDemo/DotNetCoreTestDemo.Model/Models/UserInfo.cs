using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreTestDemo.Model.Models
{
   public partial class UserInfo:Entity
    {
        public  string UserName { get; set; }
        public string PassWord { get; set; }
        public string Name { get; set; }
        public  string Phone { get; set; }
        public  virtual  ICollection<UserRole> UserRole { get; set; }
    }
}
