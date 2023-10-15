﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDCentral.BL.Models
{//
    public class Order
    {
        public int Id { get; set; }
        public required int CustomerId { get; set; }
        public required DateTime OrderDate { get; set; }
        public required int UserId { get; set; }
        public  DateTime ShipDate { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
