using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using toda.api.Services.GeoLocation;

namespace toda.api.Controllers
{
    [RoutePrefix("api/geolocation")]
    public class GeoLocationController : ApiController
    {
        private IGeoLocationService service;

        public GeoLocationController(IGeoLocationService service)
        {
            this.service = service;
        }

        // GET api/geolocation/cities
        [Route("cities")]
        [HttpGet]
        public HttpResponseMessage GetCities()
        {
            HttpResponseMessage result = null;
            var cityList = this.service.GetCities();
            if (cityList != null)
            {
                result = Request.CreateResponse(HttpStatusCode.OK, cityList);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.NoContent);
            }
            return result;
        }

        // GET api/geolocation/cities/iso
        [Route("cities/{iso}")]
        [HttpGet]
        public HttpResponseMessage GetCities(string iso)
        {
            HttpResponseMessage result = null;
            var city = this.service.GetCity(iso);
            if (city != null)
            {
                result = Request.CreateResponse(HttpStatusCode.OK, city);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.NoContent);
            }
            return result;
        }
    }
}
