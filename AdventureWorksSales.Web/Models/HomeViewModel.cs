﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdventureWorksSales.Web.Models
{
    public class HomeViewModel
    {
        public int TotalOrders { get; set; }
        public int HighestLineTotal { get; set; }
        public int FrontBrakeSales { get; set; }
    }
}