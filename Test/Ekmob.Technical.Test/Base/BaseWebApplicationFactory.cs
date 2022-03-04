using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ekmob.Technical.Test.Base
{
    public class BaseWebApplicationFactory<TStartup> :
        WebApplicationFactory<TStartup> where TStartup : class
    {
        /// <summary>
        /// Client encapsulation
        /// </summary>
        public HttpClient Client { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        public BaseWebApplicationFactory()
        {
            Client = CreateClient();
        }
    }
}
