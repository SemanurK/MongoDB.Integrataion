using Ekmob.Technical.Customer;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Ekmob.Technical.Test.Base;
using Xunit;

namespace Ekmob.Technical.Test
{
    public class DepartmentControllerTest : BaseControllerProperty, IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private static HttpClient _client;
        public DepartmentControllerTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;

            //Arrange
            _client ??= _factory.CreateClient();
            RouteHeader = "http://localhost:5001/";
            ObjectId = "61a758293a589a833b1ed40f";
            RouteName = "api/department";
        }

        [Fact]
        public async Task GetDepartment_ShouldReturnValidResultWithExistingId()
        {
            // Arrange
            string endPoint = RouteHeader + RouteName + "/" + ObjectId;

            //Act
            var response = await _client.GetAsync(endPoint);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Theory]
        [InlineData("000000000000000000000000")]
        public async Task GetDepartment_ShouldReturnErrorWithNonExistingId(string nonExistingId)
        {
            //Arrange
            var endPoint = RouteHeader + RouteName + "/" + nonExistingId;

            //Act 
            var response = await _client.GetAsync(endPoint);

            //Assert
            Assert.True(response.StatusCode == HttpStatusCode.NotFound);
        }

        //[Fact]
        //public async Task GetEmployee_ShouldReturnErrorWithNonExistingId()
        //{
        //    //Arrange
        //    ObjectId = "000000000000000000000000";
        //    string endPoint = RouteHeader + RouteName + "/" + ObjectId;

        //    //Act
        //    var response = await _client.GetAsync(endPoint);
        //    //Assert
        //    Assert.True(response.StatusCode == HttpStatusCode.NotFound);
        //}
    }
}
