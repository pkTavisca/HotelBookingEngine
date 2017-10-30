using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingServer.Models
{
    public class CreditCardInfo
    {
        public string Name { get; set; }
        public string NumberOne { get; set; }
        public string NumberTwo { get; set; }
        public string NumberThree { get; set; }
        public string NumberFour { get; set; }
        public string CVC { get; set; }
        public string ExpMonth { get; set; }
        public string ExpYear { get; set; }
        public string SessionId { get; set; }
    }
}
