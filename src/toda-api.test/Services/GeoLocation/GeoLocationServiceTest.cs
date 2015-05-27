using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toda.api.Models;
using toda.api.Services.GeoLocation;

namespace toda.api.test.Services.GeoLocation
{
    [TestFixture]
    public class GeoLocationServiceTest
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
        public void When_Get_Valid_City_Should_Return_City()
        {
            var mockService = new Mock<IGeoLocationService>();
            mockService.Setup(p => p.GetCity(It.IsAny<string>())).Returns(new City() { Code = "BKK", ISO = "TH-10", Name = "Bangkok" });
            var service = mockService.Object;

            var actual = service.GetCity("TH-10");
            Assert.IsNotNull(actual);
            Assert.AreEqual("BKK", actual.Code);
            Assert.AreEqual("TH-10", actual.ISO);
            Assert.AreEqual("Bangkok", actual.Name);
        }

        [Test]
        public void When_Get_Invalid_City_Should_Return_Null()
        {
            var mockService = new Mock<IGeoLocationService>();
            mockService.Setup(p => p.GetCity(It.IsAny<string>())).Returns(default(City));
            var service = mockService.Object;

            var actual = service.GetCity("TH-10");
            Assert.IsNull(actual);
        }

        [Test]
        public void When_Get_Cities_Should_Return_List()
        {
            var mockService = new Mock<IGeoLocationService>();
            mockService.Setup(p => p.GetCities()).Returns(new City[] { new City() { Code = "BKK", ISO = "TH-10", Name = "Bangkok" } });
            var service = mockService.Object;

            var actual = service.GetCities();
            Assert.IsNotNull(actual);
            Assert.AreEqual(1, actual.Length);
            Assert.AreEqual("BKK", actual[0].Code);
            Assert.AreEqual("TH-10", actual[0].ISO);
            Assert.AreEqual("Bangkok", actual[0].Name);
        }
    }
}
