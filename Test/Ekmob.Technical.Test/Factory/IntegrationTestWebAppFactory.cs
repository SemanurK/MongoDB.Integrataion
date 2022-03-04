using Ekmob.Technical.Customer;
using Ekmob.Technical.Test.Base;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekmob.Technical.Test.Factory
{
    public class IntegrationTestWebAppFactory : BaseWebApplicationFactory<Startup>
    {
        /// <summary>
        /// Create host builder
        /// </summary>
        /// <returns></returns>
        protected override IHostBuilder CreateHostBuilder()
        {
            var builder = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(x =>
                {
                    x.UseTestServer()
                    .UseStartup<Startup>()
                    .UseContentRoot(Directory.GetCurrentDirectory());
                });
            return builder;
        }
    }
}
