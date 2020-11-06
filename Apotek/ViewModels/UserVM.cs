using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apotek.ViewModels
{
    public class UserVm
    {
        public UserVm()
        {
            Users = new List<UserListVm>();
        }

        public class UserListVm
        {
            public string UserId { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }
            public string UserRoles { get; set; }
            public string Email { get; set; }
        }
        public List<UserListVm> Users { get; set; }
    }
}