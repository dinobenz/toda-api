using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toda.api.Models;

namespace toda.api.Services.GeoLocation
{
    public interface IGeoLocationService
    {
        City GetCity(string id);
        City[] GetCities();
    }
}
