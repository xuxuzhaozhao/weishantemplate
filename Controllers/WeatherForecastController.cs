using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace 微山ASP.NETCore_LayUI开发框架.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            var rng = new Random();
            var x = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
            return JsonConvert.SerializeObject(x, Formatting.Indented);
        }

        /// <summary>
        /// 从认证了的登陆者中获取登陆者的信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object Post()
        {
            var keys = new string[] { ClaimTypes.Name, ClaimTypes.Role, ClaimTypes.GivenName };
            var list = keys.Select((r, i) =>
            {
                var value = User.FindFirstValue(r);
                return $"{r} = {value}";
            });
            return JsonConvert.SerializeObject(list, Formatting.Indented);
        }
    }
}
