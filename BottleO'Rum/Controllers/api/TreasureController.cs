using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BottleOfRum.Business;

namespace BottleOfRum.Controllers.api
{
    public class TreasureController : ApiController
    {
        private readonly ITreasureCalculator _treasureCalculator;

        public TreasureController(ITreasureCalculator treasureCalculator)
        {
            _treasureCalculator = treasureCalculator;
        }

        [Route("api/treasure/calculate/{numberOfPirates}", Name = "CalculatePirateTreasureRoute")]
        [HttpGet]
        public HttpResponseMessage Calculate(int numberOfPirates)
        {
            if (numberOfPirates >= 21)
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                    new HttpError(string.Format("Seriously?  {0} pirates? How big is this ship anyway? A treasure that size won't fit on a normal pirate ship!", numberOfPirates)));

            if (numberOfPirates < 1)
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                    new HttpError(string.Format("Seriously?  {0} pirates?  What is this a ghost ship?", numberOfPirates)));

            if (numberOfPirates == 1)
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                    new HttpError("Please provide a number that is greater than 1."));

            try
            {
                var remainingCoins = _treasureCalculator.GetTreasureCount(numberOfPirates);
                return Request.CreateResponse(HttpStatusCode.OK, remainingCoins);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    new HttpError(string.Format("Oops! Something went wrong with that request. {0}", ex.Message)));
            }
        }
    }
}