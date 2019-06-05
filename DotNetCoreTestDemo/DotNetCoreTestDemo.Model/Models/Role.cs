using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreTestDemo.Model.Models
{
   public class Role:Entity
    {
        public  string RoleName { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
