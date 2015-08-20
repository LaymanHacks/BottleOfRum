using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BottleOfRum.Business;
using BottleOfRum.Controllers.api;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;

namespace BottleOfRum.Web.UI.Tests.Controllers.api
{
    [TestFixture()]
    public class TreasureControllerTreasureCalculatorCheatIntegrationTests
    {
        private ITreasureCalculator _treasureCalculator;
        private TreasureController _target;

        [SetUp]
        public void Init()
        {
            _treasureCalculator = new TreasureCalculatorCheat();
            _target = new TreasureController(_treasureCalculator)
            {
                Request = new HttpRequestMessage { RequestUri = new Uri("http://localhost/api/treasure") }
            };

            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();
            config.EnsureInitialized();

            _target.Request.SetConfiguration(config);
        }

        [Test]
        public void GetTreasureCount_Should_Equal_15621_When_Provided_5()
        {
            var expected = 15621;
            var result = _target.Calculate(5);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(expected, Convert.ToDecimal(result.Content.ReadAsStringAsync().Result));
        }

        [Test]
        public void GetTreasureCount_Should_Equal_79_When_Provided_3()
        {
            var expected = 79;
            var result = _target.Calculate(3);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(expected, Convert.ToDecimal(result.Content.ReadAsStringAsync().Result));
        }
    }
}
