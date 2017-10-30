//using HotelBookingServer.Models;
//using HotelEngineServiceReference;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Options;
//using HotelBookingServer.Services;
using TripEngineServiceReference;
using System;
using HotelBookingServer.Implementations;
using System.Threading.Tasks;
using HotelBookingServer.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace HotelBookingServer.Controllers
{
    [Route("/api/[controller]")]
    public class TripFolderController : Controller
    {
        [HttpPost("post")]
        public async Task Get([FromBody]PassengerInfo passengerInfo)
        {
            HotelTripProduct tripProduct = (HotelTripProduct)TripProductPriceCache.Cache[passengerInfo.SessionID].TripProduct;
            DateTime passengerBirthDate = new DateTime(int.Parse(passengerInfo.Year), int.Parse(passengerInfo.Month), int.Parse(passengerInfo.Day));
            Gender passengerGender;
            if (passengerInfo.Gender.Equals("Female")) passengerGender = Gender.Female;
            else passengerGender = Gender.Male;
            int passengerAge = (int)((DateTime.Now - passengerBirthDate).TotalDays / 365);
            TripFolderBookRQ tripFolderBookRQ = new TripFolderBookRQ()
            {
                ResultRequested = ResponseType.Unknown,
                TripFolder = new TripFolder()
                {
                    Creator = new User()
                    {
                        AdditionalInfo = new StateBag[]
                        {
                            new StateBag(){ Name="AgencyName", Value="WV"},
                            new StateBag(){ Name="CompanyName", Value= "Rovia"},
                            new StateBag(){ Name="UserType", Value="Normal"}
                        },
                        Email = "ssaraf@tavisca.com",
                        FirstName = "Shweta",
                        LastName = "Shrikhande",
                        Prefix = "Mr.",
                        Title = "Mr",
                        UserId = 26149061229281280,
                        UserName = "sshrikhande"
                    },
                    FolderName = "TripFolder" + DateTime.Now,
                    Owner = new User()
                    {
                        AdditionalInfo = new StateBag[]
                        {
                            new StateBag()
                            {
                                Name = "AgencyName",
                                Value = "WV"
                            },
                            new StateBag()
                            {
                                Name = "CompanyName",
                                Value = "Rovia"
                            },
                            new StateBag()
                            {
                                Name = "UserType",
                                Value = "Normal"
                            },
                        },
                        Email = "ssaraf@tavisca.com",
                        FirstName = "Shweta",
                        LastName = "Shrikhande",
                        Prefix = "Mr.",
                        Title = "Mr",
                        UserId = 26149061229281280,
                        UserName = "sshrikhande"
                    },
                    Pos = new PointOfSale()
                    {
                        AdditionalInfo = new StateBag[]
                        {
                            new StateBag() { Name = "IPAddress", Value = "127.0.0.1" },
                            new StateBag() { Name = "DealerUrl", Value = "localhost" },
                            new StateBag() { Name = "SiteUrl", Value = "ota" },
                            new StateBag() { Name = "AccountId", Value = "169050" },
                            new StateBag() { Name = "UserId", Value = "3285301" },
                            new StateBag() { Name = "CountryName", Value = "United States" },
                            new StateBag() { Name = "CountryCode", Value = "US" },
                            new StateBag() { Name = "UserProfileCountryCode", Value = "US" },
                            new StateBag() { Name = "CustomerType", Value = "DTP" },
                            new StateBag() { Name = "DKCommissionIdentifier", Value = "3285301P" },
                            new StateBag() { Name = "MemberSignUpDate", Value = "Tue, 04 Jan 2011" }
                        },
                        PosId = 101,
                        Requester = new Company()
                        {
                            Agency = new Agency()
                            {
                                AgencyAddress = new Address()
                                {
                                    CodeContext = LocationCodeContext.Address,
                                    AddressLine1 = "Test1",
                                    AddressLine2 = "Test2",
                                    ZipCode = "89002"
                                },
                                AgencyName = "WV",
                            },
                            Code = "DTP",
                            CodeContext = CompanyCodeContext.Airline,
                            FullName = "Rovia",
                            DK = "200000D"

                        }
                    },
                    Type = TripFolderType.Personal,
                    Passengers = new Passenger[]
                    {
                        new Passenger()
                        {
                            Age = passengerAge,
                            BirthDate = passengerBirthDate,
                            CustomFields=new StateBag[]
                            {
                                new StateBag(){ Name="Boyd Gaming"},
                                new StateBag(){ Name="IsPassportRequired" , Value="false"}
                            },
                            Email = passengerInfo.Email,
                            FirstName = passengerInfo.FirstName,
                            Gender = passengerGender,
                            LastName = passengerInfo.LastName,
                            KnownTravelerNumber="789456",
                            PassengerType = PassengerType.Adult,
                            PhoneNumber = passengerInfo.PhoneNumber,
                            Rph = 0,
                            UserId = 0,
                            UserName = passengerInfo.Email
                        }
                    },
                    Payments = new CreditCardPayment[]
                    {
                        new CreditCardPayment()
                        {
                            PaymentType = PaymentType.Credit,
                            Attributes = new StateBag[]
                            {
                                new StateBag() { Name="API_SESSION_ID", Value=passengerInfo.SessionID},
                                new StateBag() { Name="PointOfSaleRule"},
                                new StateBag() { Name="SectorRule"},
                                new StateBag() { Name="_AttributeRule_Rovia_Username"},
                                new StateBag() { Name="_AttributeRule_Rovia_Password"}
                            },
                            CardMake = new CreditCardMake()
                            {
                                Code = "VI",
                                Name = "VISA"
                            },
                            Rph=0,
                            CardType = CreditCardType.Personal,
                            ExpiryMonthYear = new DateTime(2019, 01, 01),
                            NameOnCard = "Saurabh Cache",
                            IsThreeDAuthorizeRequired = false,
                            Number = "4444333322221111",
                            SecurityCode = "123",
                            Amount = tripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalFare,
                            BillingAddress = new Address()
                            {
                                CodeContext = LocationCodeContext.Address,
                                AddressLine1 = "5100 Tennyson Parkway",
                                AddressLine2 = "dsv effs",
                                PhoneNumber = "9728055200",
                                ZipCode = "75024",
                                City = new City()
                                {
                                   Id=0,
                                   CodeContext = LocationCodeContext.City,
                                   Name = "Plano",
                                   Country = "US",
                                   State = "TX"
                                }
                            },
                        }
                    },
                    Products = new HotelTripProduct[]
                    {
                        new HotelTripProduct()
                        {
                            Attributes=new StateBag[]
                            {
                                new StateBag{ Name ="API_SESSION_ID", Value=passengerInfo.SessionID},
                                new StateBag{ Name ="token", Value=""},
                                new StateBag{ Name ="ChargingHoursPriorToCPW", Value="48"},
                                new StateBag{ Name ="IsLoginWhileSearching", Value="Y"},
                                new StateBag{ Name ="IsInsuranceSelected", Value="no"},
                            },
                            IsOnlyLeadPaxInfoRequired=true,
                            Owner=new User()
                            {
                                AdditionalInfo=new StateBag[]
                                {
                                    new StateBag(){Name="AgencyName", Value="WV"},
                                    new StateBag(){ Name="CompanyName", Value="Rovia"},
                                    new StateBag(){ Name="UserType", Value="Normal"}
                                },
                            Email = "ssaraf@tavisca.com",
                            FirstName = "Shweta",
                            LastName = "Shrikhande",
                            UserId = 0,
                            Prefix = "Mr.",
                            Title = "Mr",
                            UserName = "sshrikhande@tavisca.com"
                            },
                            PassengerSegments=new PassengerSegment[]
                            {
                                new PassengerSegment()
                                {
                                    BookingStatus=TripProductStatus.Planned,
                                    LineNumber=0,
                                    PassengerRph=0,
                                    PostBookingStatus=PostBookingTripStatus.None,
                                    Rph=0
                                }
                            },
                            PaymentBreakups=new PaymentBreakup[]
                            {
                                new PaymentBreakup()
                                {
                                    Amount=tripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalFare,
                                    PassengerRph=0,
                                    PaymentRph=0
                                }
                            },
                            PaymentOptions=new PaymentType[]
                            {
                                PaymentType.SoftCash,
                                PaymentType.External,
                                PaymentType.Credit
                            },
                            Rph=0,
                            HotelItinerary= tripProduct.HotelItinerary,
                            HotelSearchCriterion=tripProduct.HotelSearchCriterion,
                            RoomOccupancyTypes=new RoomOccupancyType[]
                            {
                                new RoomOccupancyType()
                                {
                                    PaxQuantities=new PassengerTypeQuantity[]
                                    {
                                        new PassengerTypeQuantity()
                                        {
                                            Ages=new int[]{passengerAge},
                                            PassengerType=PassengerType.Adult,
                                            Quantity=1
                                        }
                                    }
                                }
                            }
                   }
                },
                    Status = TripStatus.Planned
                },
                TripProcessingInfo = new TripProcessingInfo()
                {
                    TripProductRphs = new int[] { 0 }
                }
            };
            tripFolderBookRQ.TripFolder.Products[0].Owner = tripFolderBookRQ.TripFolder.Owner;
            TripsEngineClient tripsEngineClient = new TripsEngineClient();
            var response = await tripsEngineClient.BookTripFolderAsync(tripFolderBookRQ);
            TripFolderCache.Cache[passengerInfo.SessionID] = response;
            CompleteBookingRQ completeBookingRQ = CompleteBookingRQParser(response.SessionId, response);
            CompleteBookingRS completeBookingRS = await tripsEngineClient.CompleteBookingAsync(completeBookingRQ);
            Confirmation confirmation = ConfirmationParser(completeBookingRS);
            await HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(confirmation));
        }

        private Confirmation ConfirmationParser(CompleteBookingRS completeBookingRS)
        {
            HotelTripProduct tripProduct = (HotelTripProduct)completeBookingRS.TripFolder.Products[0];
            HotelItinerary hotelItinerary = tripProduct.HotelItinerary;
            Confirmation confirmation = new Confirmation()
            {
                ConfirmationID = completeBookingRS.TripFolder.Products[0].PassengerSegments[0].VendorConfirmationNumber,
                HotelName = hotelItinerary.HotelProperty.Name,
                RoomName = hotelItinerary.Rooms[0].RoomName,
                CheckIn = hotelItinerary.StayPeriod.Start.ToString(),
                CheckOut = hotelItinerary.StayPeriod.End.ToString(),
                BookingStatus = completeBookingRS.ServiceStatus.Status.ToString(),
                NoOfNights = hotelItinerary.StayPeriod.Duration.ToString(),
            };
            return confirmation;
        }

        public CompleteBookingRQ CompleteBookingRQParser(string sessionId, TripFolderBookRS tripFolderBookRS)
        {
            var tripFolderRS = tripFolderBookRS;
            CompleteBookingRQ bookingRQ = new CompleteBookingRQ()
            {
                ResultRequested = ResponseType.Unknown,
                SessionId = sessionId,
                ExternalPayment = tripFolderRS.TripFolder.Payments[0],
                TripFolderId = tripFolderRS.TripFolder.Id
            };
            bookingRQ.ExternalPayment.Attributes = new StateBag[]
            {
                new StateBag()
                {
                    Name = "PointOfSaleRule",
                    Value = "true"
                },
                new StateBag()
                {
                    Name = "SectorRule",
                    Value = "true"
                },
                new StateBag()
                {
                    Name = "_AttributeRule_Rovia_Username",
                    Value = "true"
                },
                new StateBag()
                {
                    Name = "_AttributeRule_Rovia_Password",
                    Value = "true"
                },
                new StateBag()
                {
                    Name = "AmountToAuthorize",
                    Value = "1"
                },
                new StateBag()
                {
                    Name = "IsDefaultDollerAuthorization",
                    Value = "Y"
                },
                new StateBag()
                {
                    Name = "PaymentStatus",
                    Value = "Authorization successful"
                },
                new StateBag()
                {
                    Name = "AuthorizationTransactionId",
                    Value = "daa73e68-f46f-4035-94d5-df80a77c1c62"
                },
                new StateBag()
                {
                    Name = "ProviderAuthorizationTransactionId",
                    Value = "DEF127D6-9257-43D3-AA45-92E53AA59CAE"
                },
                new StateBag()
                {
                    Name = "PointOfSaleRule",
                    Value = "true"
                },
                new StateBag()
                {
                    Name = "SectorRule",
                    Value = "true"
                },
                new StateBag()
                {
                    Name = "_AttributeRule_Rovia_Username",
                    Value = "true"
                },
                new StateBag()
                {
                    Name = "_AttributeRule_Rovia_Password",
                    Value = "true"
                }
            };
            return bookingRQ;
        }
    }
}
