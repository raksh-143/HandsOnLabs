﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrazyProductsCatalogService.Models.DomainModels
{
    public class CrazyProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string Country { get; set; }
    }
}