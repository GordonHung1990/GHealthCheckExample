using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GHealthCheckExample.Models
{
    public record Infos
    {
        /// <summary>
        /// The machine name
        /// </summary>
        public string MachineName { get; init; }
        /// <summary>
        /// The environment
        /// </summary>
        public string Environment { get; init; }
        /// <summary>
        /// The os version
        /// </summary>
        public string OsVersion { get; init; }
        /// <summary>
        /// The version
        /// </summary>
        public string Version { get; init; }
        /// <summary>
        /// The process count
        /// </summary>
        public int ProcessCount { get; init; }
        /// <summary>
        /// The clinet ip
        /// </summary>
        public string ClientIP { get; init; }
    }
}
