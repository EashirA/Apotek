using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apotek.ViewModels
{
    public class ManageUserVm
    {
        [Required(ErrorMessage = "Required.")]
        public string UserId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string UserRoles { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required.")]
        public string UserName { get; set; }
        public List<SelectListItem> UsersInSystem { get; set; }
        public string DropDown { get; set; }
    }
}