using HotelBookingServer.Models;
using HotelEngineServiceReference;
using System;

namespace HotelBookingServer.Services
{
    public class HotelService
    {
        private AppSettings _appSettings;
        public HotelService(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public HotelSearchRS GetHotelDetails()
        {
            HotelEngineClient hotelEngineClient = new HotelEngineClient();
            var searchRequest = BuildSearchRequest(DateTime.Now, DateTime.Now.AddDays(1), GetDefaultPassenger());
            var result = hotelEngineClient.HotelAvailAsync(searchRequest).GetAwaiter().GetResult();
            hotelEngineClient.CloseAsync().GetAwaiter().GetResult();
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

        private HotelSearchRQ BuildSearchRequest(DateTime start, DateTime end, PassengerTypeQuantity[] passengers,
            int noOfRooms = 1, float latitude = 0, float longitude = 0)
        {
            return new HotelSearchRQ
            {
                ResultRequested = ResponseType.Complete,
                Filters = SetHotelFilters(),
                SessionId = _appSettings.HotelSessionId,
                HotelSearchCriterion = SetSearchCriterion(noOfRooms, start, end, passengers, latitude, longitude),
                PagingInfo = SetPagingInfo(),
            };
        }

        private PagingInfo SetPagingInfo()
        {
            return new PagingInfo()
            {
                Enabled = true,
                EndNumber = 120,
                StartNumber = 100,
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

        private HotelSearchCriterion SetSearchCriterion(int noOfRooms, DateTime start, DateTime end,
            PassengerTypeQuantity[] passengers, float latitude, float longitude)
        {
            HotelSearchCriterion hotelSearchCriterion = new HotelSearchCriterion();
            hotelSearchCriterion.Attributes = new StateBag[]
            {
                new StateBag() { Name= "API_SESSION_ID",Value= "bf453bd0-8de8-417c-bccf-c6b8d50d6ad6" },
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
                    Amount = 10,
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
                DisplayOrder = HotelDisplayOrder.ByRelevanceScoreDescending
            };
            hotelSearchCriterion.NoOfRooms = noOfRooms;
            hotelSearchCriterion.StayPeriod = new DateTimeSpan()
            {
                End = end,
                Start = start,
                Duration = (int)Math.Ceiling(end.Subtract(start).TotalDays)
            };
            return hotelSearchCriterion;
        }
    }
}
