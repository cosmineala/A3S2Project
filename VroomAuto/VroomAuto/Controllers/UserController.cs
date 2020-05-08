using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using VroomAuto.AppLogic.Services;

namespace VroomAuto.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        UserManager<IdentityUser> userIdentity;
        UserService userService;

        public UserController( UserManager<IdentityUser> userIdentity, UserService userService )
        {
            this.userIdentity = userIdentity;
            this.userService = userService;
        }

        public IActionResult Index(  )
        {
            var users = userService.GetAll();

            return View( users );
        }
    }
}
