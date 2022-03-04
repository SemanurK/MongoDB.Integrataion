using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Ekmob.Technical.CustomerTest
{
    [TestClass]
    public class CustomerControllerTest
    {
        private readonly HttpClient _client;
        /// <summary>
        /// A valid response should be obtained with GetById
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GET_retrieves_weather_forecast()
        {
            var response = await _client.GetAsync("/weatherforecast");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var forecast = JsonConvert.DeserializeObject<WeatherForecast[]>(await response.Content.ReadAsStringAsync());
            forecast.Should().HaveCount(5);
        }
    }
}
