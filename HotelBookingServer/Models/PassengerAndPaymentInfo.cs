using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingServer.Models
{
    public class PassengerAndPaymentInfo
    {
        public PassengerInfo PassengerInfo { get; set; }
        public CreditCardInfo CreditCardInfo { get; set; }
    }
}
