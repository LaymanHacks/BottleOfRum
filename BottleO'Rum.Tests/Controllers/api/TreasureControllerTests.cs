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
    public class TreasureControllerTests
    {

        private Mock<ITreasureCalculator> _treasureCalculator;
        private TreasureController _target;
        private decimal expected = 79;

        [SetUp]
        public void Init()
        {
            _treasureCalculator = new Mock<ITreasureCalculator>();
            _target = new TreasureController(_treasureCalculator.Object)
            {
                Request = new HttpRequestMessage { RequestUri = new Uri("http://localhost/api/treasure") }
            };

            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();
            config.EnsureInitialized();

            _target.Request.SetConfiguration(config);

            _treasureCalculator
               .Setup(it => it.GetTreasureCount(It.IsAny<Int32>()))
                   .Returns(expected);

        }

       
        [Test()]
        public void Calculate_Should_Return_Expected_Result()
        {
            var result = _target.Calculate(3);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(expected, Convert.ToDecimal(result.Content.ReadAsStringAsync().Result));
        }

        [Test()]
        public void Calculate_Should_Return_BadRequest_Provided_Greater_20()
        {
            var numberOfPirates = 21;
            
            var result = _target.Calculate(numberOfPirates);
            var httpErrorResult = JsonConvert.DeserializeObject<HttpError>(result.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
            Assert.AreEqual(string.Format("Seriously?  {0} pirates? How big is this ship anyway? A treasure that size won't fit on a normal pirate ship!", numberOfPirates), httpErrorResult.Message);
        }

        [Test()]
        public void Calculate_Should_Return_BadRequest_Provided_Less_Than_1()
        {
            var numberOfPirates = -1;
            
            var result = _target.Calculate(numberOfPirates);
            var httpErrorResult = JsonConvert.DeserializeObject<HttpError>(result.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
            Assert.AreEqual(string.Format("Seriously?  {0} pirates?  What is this a ghost ship?", numberOfPirates), httpErrorResult.Message);
        }

        [Test()]
        public void Calculate_Should_Return_BadRequest_Provided_Equal_1()
        {
            var numberOfPirates = 1;
            
            var result = _target.Calculate(numberOfPirates);
            var httpErrorResult = JsonConvert.DeserializeObject<HttpError>(result.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
            Assert.AreEqual("Please provide a number that is greater than 1.", httpErrorResult.Message);
        }
    }
}
