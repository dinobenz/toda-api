using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using toda.api.Models;

namespace toda.api.Services.GeoLocation
{
    public class GeoLocationService : IGeoLocationService
    {
        public City GetCity(string id)
        {
            var item = default(City);
            var list = GetCities();
            if(list.Length>0)
            {
                for (int i = 0; i < list.Length; i++)
                {
                    if (list[i].ISO.Equals(id))
                    {
                        item = list[i];
                    }
                }
            }
            return item;
        }

        public City[] GetCities()
        {
            var list = new List<City>();
            list.Add(new City()
            {
                Code = "BKK",
                ISO = "TH-10",
                Name = "กรุงเทพมหานคร"
            });
            //list.Add(new City()
            //{
            //    Code = "",
            //    ISO = "",
            //    Name = ""
            //});
            //list.Add(new City()
            //{
            //    Code = "",
            //    ISO = "",
            //    Name = ""
            //});
            return list.Count > 0 ? list.ToArray() : null;
        }
    }
}