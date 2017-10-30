using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingServer.Models
{
    public class UpdatedPriceResponse
    {
        public string HotelName { get; set; }
        public string RoomType { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public int Duration { get; set; }
        public decimal UpdatedPrice { get; set; }
        public string SessionId { get; set; }
        public string Currency { get; set; }
    }
}
