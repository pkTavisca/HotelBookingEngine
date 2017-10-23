using HotelBookingServer.Implementations;
using HotelBookingServer.Models;
using HotelEngineServiceReference;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HotelBookingServer.Services
{
    public class HotelService
    {
        private AppSettings _appSettings;
        public HotelService(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }
        public HotelSearchRS GetHotelDetails(string sessionId, string type, string lat, string lon, DateTime checkIn, DateTime checkOut)
        {
            if (HotelMultiAvailCache.Contains(sessionId))
                return HotelMultiAvailCache.GetFromCache(sessionId).Item2;
            float latitude = float.Parse(lat);
            float longitude = float.Parse(lon);
            HotelEngineClient hotelEngineClient = new HotelEngineClient();
            var searchRequest = BuildSearchRequest(sessionId, type, checkIn, checkOut, GetDefaultPassenger(), 1, latitude, longitude);
            var result = hotelEngineClient.HotelAvailAsync(searchRequest).GetAwaiter().GetResult();
            hotelEngineClient.CloseAsync().GetAwaiter().GetResult();
            HotelMultiAvailCache.AddToCache(searchRequest, result);
            return result;
        }
        private PassengerTypeQuantity[] GetDefaultPassenger()
        {
            return
            new PassengerTypeQuantity[]
                {
                    new PassengerTypeQuantity()
                    {
                        Ages = new int[1]
                        {
                           20
                        },
                        PassengerType = PassengerType.Adult,
                        Quantity = 1
                    }
                };
        }

        public HotelSearchRS GetMultiAvailDetails(string sessionId)
        {
            SearchObject searchData = SearchDataCache.GetFromCache(sessionId);
            JObject searchAutoSuggestData = JsonConvert.DeserializeObject(searchData.SearchTerm) as JObject;
            var data = searchAutoSuggestData.First.First["data"];
            string latitiude = (string)data["Latitude"];
            string longitude = (string)data["Longitude"];
            string searchType = (string)data["SearchType"];
            return GetHotelDetails(sessionId, searchType, latitiude, longitude, searchData.CheckIn, searchData.CheckOut);
        }

        private HotelSearchRQ BuildSearchRequest(string sessionId, string searchType, DateTime start, DateTime end, PassengerTypeQuantity[] passengers,
            int noOfRooms = 1, float latitude = 19.0760f, float longitude = 72.8777f)
        {
            return new HotelSearchRQ
            {
                ResultRequested = ResponseType.Complete,
                Filters = SetHotelFilters(),
                SessionId = sessionId,
                HotelSearchCriterion = SetSearchCriterion(sessionId, searchType, noOfRooms, start, end, passengers, latitude, longitude),
                PagingInfo = SetPagingInfo(),
            };
        }
        private PagingInfo SetPagingInfo()
        {
            return new PagingInfo()
            {
                Enabled = false,
                EndNumber = 0,
                StartNumber = 0,
                TotalRecordsBeforeFiltering = 0,
                TotalResults = 0
            };
        }
        private HotelFilter[] SetHotelFilters()
        {
            HotelFilter[] hotelFilters = new HotelFilter[]
            {
                new AvailabilityFilter()
                {
                    ReturnOnlyAvailableItineraries = true
                }
            };
            return hotelFilters;
        }
        private HotelSearchCriterion SetSearchCriterion(string sessionId, string searchType, int noOfRooms, DateTime start, DateTime end,
            PassengerTypeQuantity[] passengers, float latitude, float longitude)
        {
            HotelSearchCriterion hotelSearchCriterion = new HotelSearchCriterion();
            HotelDisplayOrder displayOrder;
            if (searchType.ToLowerInvariant().Equals("hotel")) displayOrder = HotelDisplayOrder.DistanceAscending;
            else displayOrder = HotelDisplayOrder.ByRelevanceScoreDescending;
            hotelSearchCriterion.Attributes = new StateBag[]
            {
                new StateBag() { Name= "API_SESSION_ID",Value= sessionId },
                new StateBag() { Name= "FareType",Value= "BaseFare" },
                new StateBag() { Name= "ResetFiltersIfNoResults",Value= "true" },
                new StateBag() { Name= "ReturnRestrictedRelevanceProperties",Value= "true" },
                new StateBag() { Name= "MaxHideawayRelevancePropertiesToDisplay",Value= "5" },
                new StateBag() { Name= "MaxHotelRelevancePropertiesToDisplay",Value= "10" }
            };
            hotelSearchCriterion.MatrixResults = true;
            hotelSearchCriterion.MaximumResults = 1500;
            hotelSearchCriterion.Pos = new PointOfSale()
            {
                AdditionalInfo = new StateBag[]
                {
                    new StateBag(){Name="IPAddress",Value="127.0.0.1"},
                    new StateBag(){Name="DealerUrl",Value="localhost"},
                    new StateBag(){Name="SiteUrl",Value="ota"},
                    new StateBag(){Name="AccountId",Value="169050"},
                    new StateBag(){Name="UserId",Value="3285301"},
                    new StateBag(){Name="CountryName",Value="United States"},
                    new StateBag(){Name="CountryCode",Value="US"},
                    new StateBag(){Name="UserProfileCountryCode",Value="US"},
                    new StateBag(){Name="CustomerType",Value="DTP"},
                    new StateBag(){Name="DKCommissionIdentifier",Value="3285301P"},
                    new StateBag(){Name="MemberSignUpDate",Value="Tue, 04 Jan 2011"}
                },
                PosId = 101,
                Requester = new Company()
                {
                    Agency = new Agency()
                    {
                        AgencyAddress = new Address() { }
                    }
                }
            };
            hotelSearchCriterion.PriceCurrencyCode = "USD";
            hotelSearchCriterion.Location = new Location()
            {
                CodeContext = LocationCodeContext.GeoCode,
                GeoCode = new GeoCode() { Latitude = latitude, Longitude = longitude },
                Radius = new Distance()
                {
                    Amount = displayOrder == HotelDisplayOrder.DistanceAscending ? 5 : 50,
                    From = LocationCodeContext.GeoCode,
                    Unit = DistanceUnit.mi
                },
            };
            hotelSearchCriterion.RoomOccupancyTypes = new RoomOccupancyType[1]
            {
                new RoomOccupancyType()
                {
                    PaxQuantities = passengers
                }
            };
            hotelSearchCriterion.ProcessingInfo = new HotelSearchProcessingInfo()
            {
                DisplayOrder = displayOrder,
            };
            hotelSearchCriterion.NoOfRooms = noOfRooms;
            hotelSearchCriterion.StayPeriod = new DateTimeSpan()
            {
                End = end,
                Start = start,
                Duration = (int)Math.Ceiling(end.Subtract(start).TotalDays) + 1
            };
            hotelSearchCriterion.Guests = new PassengerTypeQuantity[]
            {
                new PassengerTypeQuantity()
                {
                    Ages = new int[1]{20 },
                    PassengerType = PassengerType.Adult,
                    Quantity = 1
                }
            };
            return hotelSearchCriterion;
        }
    }
}
