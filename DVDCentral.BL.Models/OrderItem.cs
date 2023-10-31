using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDCentral.BL.Models
{
    public class OrderItem
    {
        public  int Id { get; set; }
        public  int  OrderId { get; set; }
        public required int MovieId { get; set; }
        public required int Quantity { get; set; }
        public required double Cost { get; set; }
        public string MovieDescription { get; set; }

        public double TotalCost
        {
            get { return Cost * Quantity; }
        }
    }
}
