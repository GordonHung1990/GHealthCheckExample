using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using GHealthCheckExample.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GHealthCheckExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        public InfoController(IWebHostEnvironment env)
        {
            _env = env ?? throw new ArgumentNullException(nameof(env));
        }
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Infos Get()
        {
            string ipAddress = string.Empty;
            var ip = Request.HttpContext.Connection.RemoteIpAddress;
            if (ip != null)
            {
                if (ip.AddressFamily == AddressFamily.InterNetworkV6)
                {
                    ip = Dns.GetHostEntry(ip).AddressList.First(x => x.AddressFamily == AddressFamily.InterNetwork);
                }
                ipAddress = ip.ToString();
            }
            return new Infos
            {
                MachineName = Environment.MachineName,
                Environment = _env.EnvironmentName,
                OsVersion = $"{Environment.OSVersion}",
                Version = Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                ProcessCount = Environment.ProcessorCount,
                ClientIP = ipAddress
            };

        }
    }
}
