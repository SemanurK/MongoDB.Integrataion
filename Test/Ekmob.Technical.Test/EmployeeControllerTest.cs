using Ekmob.Technical.Customer;
using Ekmob.Technical.Test.Base;
using Ekmob.Technical.Test.Factory;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Ekmob.Technical.Test
{
    public class EmployeeControllerTest : BaseControllerProperty,IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private static HttpClient _client;
        public EmployeeControllerTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;

            _client ??= _factory.CreateClient();
            //Arrange
            RouteHeader = "http://localhost:5001/";
            ObjectId = "61a758293a589a833b1ed410";
            RouteName = "api/employee";

        }

      [Fact]
        public async Task GetEmployees_ShouldReturnValidEmployeeList()
        {
            //Arrange
            var endPoint = RouteHeader + RouteName;
            
            //Act
            var response = await _client.GetAsync(endPoint);

            //Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task GetEmployee_ShouldReturnValidResultWithExistingId()
        {
            //Arrange
            var endPoint = RouteHeader + RouteName + "/" + ObjectId;

            //Act
            var response = await _client.GetAsync(endPoint);

            //Assert
            Assert.True(response.IsSuccessStatusCode);

        }

        [Fact]
        public async Task GetEmployee_ShouldReturnErrorResultWithNonExistingId()
        {
            //Arrange
            var endPoint = RouteHeader + RouteName + "/" + "000000000000000000000000";

            //Act
            var response = await _client.GetAsync(endPoint);

            //Assert
            Assert.True(response.StatusCode==HttpStatusCode.NotFound);

        }
    }
}
