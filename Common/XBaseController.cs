using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace 微山ASP.NETCore_LayUI开发框架.Common
{
    //[Authorize]
    //public class XBaseController : ControllerBase
    //{
    //    protected XUser user;
    //    public XBaseController()
    //    {
    //        user = new XUser();
    //        user.Name = User.FindFirstValue(ClaimTypes.Name);
    //        user.Role = User.FindFirstValue(ClaimTypes.Role);
    //        user.RealName = User.FindFirstValue(ClaimTypes.GivenName);
    //    }
    //}

    public class XUser
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public string RealName { get; set; }
    }
}
