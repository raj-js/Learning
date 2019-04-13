using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MigrationInRuntime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly SimpleDbContext _db = new SimpleDbContext();
        private readonly IHttpContextAccessor _accessor = null;

        public LogController(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Log>> Get()
        {
            _db.Logs.Add(new Log
            {
                Level = LogLevel.Info,
                Content = $"request. client ip is {_accessor.HttpContext.GetClientIp()} ",
                Time = DateTime.Now
            });

            _db.SaveChanges();

            return _db.Logs.ToArray();
        }
    }

    public static class HttpContextExtensions
    {
        public static string GetClientIp(this HttpContext context)
        {
            var ip = context.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (string.IsNullOrEmpty(ip))
            {
                ip = context.Connection.RemoteIpAddress.ToString();
            }
            return ip;
        }
    }
}
