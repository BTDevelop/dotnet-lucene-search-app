﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchEngine.Web.Models
{
    public class Classifieds
    {
        public int Id
        { get; set; }
        public string Title
        { get; set; }
        public double Price
        { get; set; }
        public string Region
        { get; set;}
        public string City
        { get; set; }
        public string CityArea
        { get; set; }

    }
}