using Ekmob.Technical.Common.Utilities.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ekmob.Technical.Test.Base
{
    public class BaseControllerTest<TEntity, TTestWebAppFactory, TStartup> :
        IClassFixture<TTestWebAppFactory>
        where TEntity : class
        where TStartup : class
        where TTestWebAppFactory : BaseWebApplicationFactory<TStartup>
    {
        private BaseWebApplicationFactory<TStartup> _factory;
        public BaseWebApplicationFactory<TStartup> TestFactory => _factory;

        public BaseControllerTest(
           TTestWebAppFactory factory)
        {
            _factory = factory;        
        }
        protected async Task<HttpResponseMessage> TryGet(
            string endPoint)
        {
            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, endPoint);

            return await TestFactory.Client.SendAsync(requestMessage);
        }

        protected async Task<Response<IEnumerable<TOutput>>>
           GetListResult<TOutput>(HttpResponseMessage requestResult) where TOutput : class
        {
            try
            {
                var responseMessage = await requestResult.Content.ReadAsStringAsync();
                if (requestResult.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<Response<IEnumerable<TOutput>>>(responseMessage);
                return Response<IEnumerable<TOutput>>.Fail("Test Fail", (int)HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Response<IEnumerable<TOutput>>.Fail("Unable to serialize list: " +
                                                                   ex.Message, (int)HttpStatusCode.NotFound);
            }
        }


    }
}
