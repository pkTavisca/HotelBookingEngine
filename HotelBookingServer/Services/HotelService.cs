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
            var result = hotelEngineClient.HotelAvailAsync(BuildSearchRequest()).GetAwaiter().GetResult();
            hotelEngineClient.CloseAsync().GetAwaiter().GetResult();
            return result;
        }

        private HotelSearchRQ BuildSearchRequest()
        {
            return new HotelSearchRQ
            {
                ResultRequested = ResponseType.Complete,
                Filters = SetHotelFilters(),
                SessionId = _appSettings.HotelSessionId,
                HotelSearchCriterion = SetSearchCriterion(),
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

        private HotelSearchCriterion SetSearchCriterion()
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
                GeoCode = new GeoCode() { Latitude = 36.11093f, Longitude = -115.16935f },
                GmtOffsetMinutes = 0,
                Id = 0,
                Name = "Las Vegas",
                Radius = new Distance()
                {
                    Amount = 30,
                    From = LocationCodeContext.City,
                    Unit = DistanceUnit.mi
                },
            };
            hotelSearchCriterion.Guests = new PassengerTypeQuantity[] {
                new PassengerTypeQuantity()
                {
                    Ages= new int[]{20,20},
                    PassengerType = PassengerType.Adult,
                    Quantity = 2
                }
            };
            hotelSearchCriterion.RoomOccupancyTypes = new RoomOccupancyType[1]
            {
                new RoomOccupancyType()
                {
                    PaxQuantities =new PassengerTypeQuantity[]
                    {
                        new PassengerTypeQuantity()
                        {
                            Ages = new int[2]
                            {
                               30,30
                            },
                            PassengerType = PassengerType.Adult,
                            Quantity = 2
                        }
                    }
                }
            };
            hotelSearchCriterion.ProcessingInfo = new HotelSearchProcessingInfo()
            {
                DisplayOrder = HotelDisplayOrder.ByRelevanceScoreDescending
            };
            hotelSearchCriterion.NoOfRooms = 1;
            hotelSearchCriterion.StayPeriod = new DateTimeSpan()
            {
                Duration = 0,
                End = new DateTime(2017, 10, 26),
                Start = new DateTime(2017, 10, 25)
            };
            return hotelSearchCriterion;
        }
    }
}
