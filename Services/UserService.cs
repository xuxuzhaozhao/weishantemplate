using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using 微山ASP.NETCore_LayUI开发框架.Models;

namespace 微山ASP.NETCore_LayUI开发框架.Services
{
    public interface IUserService
    {
        bool IsValid(LoginRequestDTO request);
    }

    public class UserService : IUserService
    {
        /// <summary>
        /// 数据库验证，测试直接验证成功
        /// </summary>
        public bool IsValid(LoginRequestDTO request)
        {
            return true;
        }
    }
}
