using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HotelBookingServer.Models;
using HotelBookingServer.Services;
using Microsoft.AspNetCore.Http;

namespace HotelBookingServer.Controllers
{
    [Route("/api/[controller]")]
    public class TripFolderController : Controller
    {
        TripFolderService tripFolderService;

        public TripFolderController()
        {
            tripFolderService = new TripFolderService();
        }

        [HttpPost("post")]
        public async Task Get([FromBody]PassengerAndPaymentInfo completeDetails)
        {
            var responseString = await tripFolderService.CompletelyBook(completeDetails);
            await HttpContext.Response.WriteAsync(responseString);
        }
    }
}
