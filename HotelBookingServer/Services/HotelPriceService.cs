using System;
using HotelBookingServer.Implementations;
using TripEngineServiceReference;
using hotel = HotelEngineServiceReference;
using HotelBookingServer.Models;

namespace HotelBookingServer.Services
{
    public class HotelPriceService
    {
        private string[] _hotelFareSource;
        public HotelPriceService()
        {
            _hotelFareSource = new string[]
            {
                "TouricoTGSTest","HotelBeds Test"
            };
        }
        public UpdatedPriceResponse GetPrice(string sessionId, string roomId)
        {
            var hotelRoomAvailTuple = HotelRoomAvailRQRSCache.GetFromCache(sessionId);
            TripsEngineClient tripsEngineClient = new TripsEngineClient();
            Room selectedRoom = new Room();
            foreach (var room in hotelRoomAvailTuple.Item2.Itinerary.Rooms)
            {
                if (room.RoomId.ToString() == roomId && (_hotelFareSource[0].Equals(room.HotelFareSource.Name) || _hotelFareSource[1].Equals(room.HotelFareSource.Name)))
                {
                    selectedRoom = ReferenceConverter.Convert<hotel.Room, Room>(room);
                    break;
                }
            }
            hotelRoomAvailTuple.Item2.Itinerary.Rooms = ReferenceConverter.Convert<Room[], hotel.Room[]>(new Room[] { selectedRoom });
            TripProductPriceRQ priceRequest = new TripProductPriceRQ()
            {
                TripProduct = new HotelTripProduct()
                {
                    HotelItinerary = ReferenceConverter.Convert<hotel.HotelItinerary, HotelItinerary>(hotelRoomAvailTuple.Item2.Itinerary),
                    HotelSearchCriterion = ReferenceConverter.Convert<hotel.HotelSearchCriterion, HotelSearchCriterion>(hotelRoomAvailTuple.Item1.HotelSearchCriterion),
                },
                ResultRequested = ResponseType.Unknown,
                SessionId = sessionId,
            };
            TripProductPriceRS priceResponse = tripsEngineClient.PriceTripProductAsync(priceRequest).GetAwaiter().GetResult();
            TripProductPriceCache.Cache[sessionId] = priceResponse;
            UpdatedPriceResponse updatedPriceResponse;
            try
            {
                UpdateRates((HotelTripProduct)priceResponse.TripProduct);
                updatedPriceResponse = UpdatedPriceResponseParser(priceResponse);
            }
            catch
            {
                updatedPriceResponse = new UpdatedPriceResponse();
                updatedPriceResponse.UpdatedPrice = 0;
            }

            return updatedPriceResponse;
        }

        private UpdatedPriceResponse UpdatedPriceResponseParser(TripProductPriceRS priceResponse)
        {
            UpdatedPriceResponse updatedPriceResponse = new UpdatedPriceResponse();
            HotelTripProduct hotelTripProduct = (HotelTripProduct)priceResponse.TripProduct;
            HotelItinerary hotelItinerary = hotelTripProduct.HotelItinerary;
            updatedPriceResponse.CheckinDate = hotelItinerary.StayPeriod.Start.ToString().Remove(10);
            updatedPriceResponse.CheckoutDate = hotelItinerary.StayPeriod.End.ToString().Remove(10);
            updatedPriceResponse.Duration = hotelItinerary.StayPeriod.Duration;
            updatedPriceResponse.HotelName = hotelItinerary.HotelProperty.Name;
            updatedPriceResponse.RoomType = hotelItinerary.Rooms[0].RoomName;
            updatedPriceResponse.UpdatedPrice = hotelItinerary.Rooms[0].DisplayRoomRate.TotalFare.Amount;
            updatedPriceResponse.SessionId = priceResponse.SessionId;
            updatedPriceResponse.Currency = hotelItinerary.Rooms[0].DisplayRoomRate.TotalFare.Currency;
            return updatedPriceResponse;
        }

        private void UpdateRates(HotelTripProduct hotelTripProduct)
        {
            hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.BaseFare.DisplayAmount = hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.BaseFare.Amount;
            hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.BaseFare.DisplayCurrency = hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.BaseFare.Currency;
            hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalFare.DisplayAmount = hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalFare.Amount;
            hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalFare.DisplayCurrency = hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalFare.Currency;
            hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.DailyRates[0].DisplayCurrency = hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.DailyRates[0].Currency;
            hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.DailyRates[0].DisplayAmount = hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.DailyRates[0].Amount;
            hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.Taxes[0].DisplayAmount = hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.Taxes[0].Amount;
            hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.Taxes[0].DisplayCurrency = hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.Taxes[0].Currency;
            hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalCommission.DisplayCurrency = hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalCommission.Currency;
            hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalCommission.DisplayAmount = hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalCommission.Amount;
            hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalDiscount.DisplayCurrency = hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalDiscount.Currency;
            hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalDiscount.DisplayAmount = hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalDiscount.Amount;
            hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalFare.DisplayCurrency = hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalFare.Currency;
            hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalFare.DisplayAmount = hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalFare.Amount;
            hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalTax.DisplayCurrency = hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalTax.Currency;
            hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalTax.DisplayAmount = hotelTripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalTax.Amount;
            hotelTripProduct.HotelItinerary.Fare.AvgDailyRate.DisplayAmount = hotelTripProduct.HotelItinerary.Fare.AvgDailyRate.Amount;
            hotelTripProduct.HotelItinerary.Fare.AvgDailyRate.DisplayCurrency = hotelTripProduct.HotelItinerary.Fare.AvgDailyRate.Currency;
            hotelTripProduct.HotelItinerary.Fare.BaseFare.DisplayAmount = hotelTripProduct.HotelItinerary.Fare.BaseFare.Amount;
            hotelTripProduct.HotelItinerary.Fare.BaseFare.DisplayCurrency = hotelTripProduct.HotelItinerary.Fare.BaseFare.Currency;
            hotelTripProduct.HotelItinerary.Fare.MaxDailyRate.DisplayAmount = hotelTripProduct.HotelItinerary.Fare.MaxDailyRate.Amount;
            hotelTripProduct.HotelItinerary.Fare.MaxDailyRate.DisplayCurrency = hotelTripProduct.HotelItinerary.Fare.MaxDailyRate.Currency;
            hotelTripProduct.HotelItinerary.Fare.MinDailyRate.DisplayAmount = hotelTripProduct.HotelItinerary.Fare.MinDailyRate.Amount;
            hotelTripProduct.HotelItinerary.Fare.MinDailyRate.DisplayCurrency = hotelTripProduct.HotelItinerary.Fare.MinDailyRate.Currency;
            hotelTripProduct.HotelItinerary.Fare.TotalCommission.DisplayAmount = hotelTripProduct.HotelItinerary.Fare.TotalCommission.Amount;
            hotelTripProduct.HotelItinerary.Fare.TotalCommission.DisplayCurrency = hotelTripProduct.HotelItinerary.Fare.TotalCommission.Currency;
            hotelTripProduct.HotelItinerary.Fare.TotalDiscount.DisplayAmount = hotelTripProduct.HotelItinerary.Fare.TotalDiscount.Amount;
            hotelTripProduct.HotelItinerary.Fare.TotalDiscount.DisplayCurrency = hotelTripProduct.HotelItinerary.Fare.TotalDiscount.Currency;
            hotelTripProduct.HotelItinerary.Fare.TotalFare.DisplayAmount = hotelTripProduct.HotelItinerary.Fare.TotalFare.Amount;
            hotelTripProduct.HotelItinerary.Fare.TotalFare.DisplayCurrency = hotelTripProduct.HotelItinerary.Fare.TotalFare.Currency;
            hotelTripProduct.HotelItinerary.Fare.TotalFee.DisplayAmount = hotelTripProduct.HotelItinerary.Fare.TotalFee.Amount;
            hotelTripProduct.HotelItinerary.Fare.TotalFee.DisplayCurrency = hotelTripProduct.HotelItinerary.Fare.TotalFee.Currency;
            hotelTripProduct.HotelItinerary.Fare.TotalTax.DisplayAmount = hotelTripProduct.HotelItinerary.Fare.TotalTax.Amount;
            hotelTripProduct.HotelItinerary.Fare.TotalTax.DisplayCurrency = hotelTripProduct.HotelItinerary.Fare.TotalTax.Currency;
        }
    }
}
