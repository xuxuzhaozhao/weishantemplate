using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using 微山ASP.NETCore_LayUI开发框架.Models;
using 微山ASP.NETCore_LayUI开发框架.Services;

namespace 微山ASP.NETCore_LayUI开发框架.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticateService authenticate;
        public AuthenticationController(IAuthenticateService authenticate)
        {
            this.authenticate = authenticate;
        }

        /// <summary>
        /// 请求获取token
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost, Route("requestToken")]
        public ActionResult RequestToken([FromBody] LoginRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Request.");
            }

            string token = string.Empty;
            if(authenticate.IsAuthenticated(request,out token))
            {
                return Ok(token);
            }

            return BadRequest(new { message=$"username or password is wrong."});
        }
    }
}
