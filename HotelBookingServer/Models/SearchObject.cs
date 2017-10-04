using System;

namespace HotelBookingServer.Models
{
    public class SearchObject
    {
        public string SearchTerm { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
