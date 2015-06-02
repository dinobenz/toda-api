using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using toda.api.Controllers;
using toda.api.Models;
using toda.api.Services.GeoLocation;

namespace toda.api.test.Controllers
{
    [TestFixture]
    public class GeoLocationControllerTest
    {
        [SetUp]
        public void TestSetup()
        {
        }

        [TearDown]
        public void TestCleanup()
        {
        }

        [Test]
        public void When_Get_Valid_City_Should_Return_HttpStatusCode_OK()
        {
            var mockService = new Mock<IGeoLocationService>();
            mockService.Setup(p => p.GetCity(It.IsAny<string>())).Returns(new City() { Code = "BKK", ISO = "TH-10", Name = "Bangkok" });

            var controller = new GeoLocationController(mockService.Object);
            controller.Request = new HttpRequestMessage();
            controller.Request.SetConfiguration(new HttpConfiguration());

            var result = controller.GetCities("TH-10");
            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);

            var content = result.Content.ReadAsAsync<City>();
            Assert.IsNotNull(content.Result);
            Assert.AreEqual("BKK", content.Result.Code);
            Assert.AreEqual("TH-10", content.Result.ISO);
            Assert.AreEqual("Bangkok", content.Result.Name);
        }

        [Test]
        public void When_Get_Invalid_City_Should_Return_HttpStatusCode_NoContent()
        {
            var mockService = new Mock<IGeoLocationService>();
            mockService.Setup(p => p.GetCity(It.IsAny<string>())).Returns(default(City));

            var controller = new GeoLocationController(mockService.Object);
            controller.Request = new HttpRequestMessage();
            controller.Request.SetConfiguration(new HttpConfiguration());

            var result = controller.GetCities("TH-10");
            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
            Assert.IsNull(result.Content);
        }

        [Test]
        public void When_Get_Valid_Cities_Should_Return_HttpStatusCode_OK()
        {
            var mockService = new Mock<IGeoLocationService>();
            mockService.Setup(p => p.GetCities()).Returns(new City[] { new City() { Code = "BKK", ISO = "TH-10", Name = "Bangkok" } });

            var controller = new GeoLocationController(mockService.Object);
            controller.Request = new HttpRequestMessage();
            controller.Request.SetConfiguration(new HttpConfiguration());

            var result = controller.GetCities();
            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);

            var content = result.Content.ReadAsAsync<City[]>();
            Assert.IsNotNull(content.Result);
            Assert.AreEqual("BKK", content.Result[0].Code);
            Assert.AreEqual("TH-10", content.Result[0].ISO);
            Assert.AreEqual("Bangkok", content.Result[0].Name);
        }

        [Test]
        public void When_Get_Invalid_Cities_Should_Return_HttpStatusCode_NoContent()
        {
            var mockService = new Mock<IGeoLocationService>();
            mockService.Setup(p => p.GetCities()).Returns(default(City[]));

            var controller = new GeoLocationController(mockService.Object);
            controller.Request = new HttpRequestMessage();
            controller.Request.SetConfiguration(new HttpConfiguration());

            var result = controller.GetCities();
            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
            Assert.IsNull(result.Content);
        }
    }
}
