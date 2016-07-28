using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace toda.api.Models
{
    public class District
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public SubDistrict[] SubDistricts { get; set; }
    }
}