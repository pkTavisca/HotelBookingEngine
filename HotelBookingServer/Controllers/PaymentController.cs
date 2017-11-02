using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TripEngineServiceReference;
using HotelBookingServer.Implementations;
using HotelBookingServer.Services;

namespace HotelBookingServer.Controllers
{
    [Route("/api/[controller]")]
    public class PaymentController : Controller
    {
        PaymentService paymentService;

        public PaymentController()
        {
            paymentService = new PaymentService();
        }

        [HttpGet("{sessionId}")]
        public async Task<CompleteBookingRS> BookTripFolder(string sessionId)
        {
            return await paymentService.BookTripFolder(sessionId);
        }
    }
}
