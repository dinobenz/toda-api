using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using toda.api.Models;

namespace toda.api.Services.GeoLocation
{
    public class GeoLocationService : IGeoLocationService
    {
        public City GetCity(string iso)
        {
            var item = default(City);
            var list = GetCities();
            if(list.Length>0)
            {
                for (int i = 0; i < list.Length; i++)
                {
                    if (list[i].ISO.Equals(iso))
                    {
                        item = list[i];
                    }
                }
            }
            return item;
        }

        public City[] GetCities()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "toda.api.Data.city.json";
            var jsonContent = string.Empty;
            var list = new List<City>();

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (var reader = new StreamReader(stream))
                {
                    jsonContent = reader.ReadToEnd();
                }
            }

            if (!string.IsNullOrEmpty(jsonContent))
            {
                list = JsonConvert.DeserializeObject<List<City>>(jsonContent);
            }

            return list.Count > 0 ? list.ToArray() : null;
        }
    }
}