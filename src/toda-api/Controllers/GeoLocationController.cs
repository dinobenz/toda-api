using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using toda.api.Services.GeoLocation;

namespace toda.api.Controllers
{
    public class GeoLocationController : ApiController
    {
        private IGeoLocationService service;

        public GeoLocationController(IGeoLocationService service)
        {
            this.service = service;
        }

        // GET api/geolocation/cities/id
        [ActionName("cities")]
        [HttpGet]
        public HttpResponseMessage GetCities(string id)
        {
            HttpResponseMessage result = null;

            if (!string.IsNullOrEmpty(id))
            {
                var city = this.service.GetCity(id);
                if (city!=null)
                {
                    result = Request.CreateResponse(HttpStatusCode.OK, city);
                }
                else
                {
                    result = Request.CreateResponse(HttpStatusCode.NoContent);
                }
            }
            else
            {
                var cityList = this.service.GetCities();
                if (cityList != null)
                {
                    result = Request.CreateResponse(HttpStatusCode.OK, cityList);
                }
                else
                {
                    result = Request.CreateResponse(HttpStatusCode.NoContent);
                }
            }

            return result;
        }
    }
}
