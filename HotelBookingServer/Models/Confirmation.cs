using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingServer.Models
{
    public class Confirmation
    {
        public string ConfirmationID { get; set; }
        public string HotelName { get; set; }
        public string RoomName { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
        public string BookingStatus { get; set; }
        public string NoOfNights { get; internal set; }
    }
}
