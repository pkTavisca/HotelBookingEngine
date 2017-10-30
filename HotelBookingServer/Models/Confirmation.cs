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
        public string Address { get; set; }
        public string Email { get; set; }
        public string NoOfNights { get; internal set; }
    }
}
