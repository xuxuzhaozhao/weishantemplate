using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using 微山ASP.NETCore_LayUI开发框架.Common;

namespace 微山ASP.NETCore_LayUI开发框架.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TestAuthController : ControllerBase
    {
        protected XUser user;

        public TestAuthController()
        {
            
        }

        [HttpGet]
        public object Get()
        {
            user = new XUser();
            user.Name = User.FindFirstValue(ClaimTypes.Name);
            user.Role = User.FindFirstValue(ClaimTypes.Role);
            user.RealName = User.FindFirstValue(ClaimTypes.GivenName);
            return user;
        }
    }
}
