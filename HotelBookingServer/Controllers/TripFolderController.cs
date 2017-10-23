//using HotelBookingServer.Models;
//using HotelEngineServiceReference;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Options;
//using HotelBookingServer.Services;
using TripEngineServiceReference;
using System;
using HotelBookingServer.Implementations;
using System.Threading.Tasks;

namespace HotelBookingServer.Controllers
{
    [Route("/api/[controller]")]
    public class TripFolderController : Controller
    {
        [HttpGet("get/{sessionId}")]
        public async Task<TripFolderBookRS> Get(string sessionId)
        {
            HotelTripProduct tripProduct = (HotelTripProduct)TripProductPriceCache.Cache[sessionId].TripProduct;
            TripFolderBookRQ tripFolderBookRQ = new TripFolderBookRQ()
            {
                SessionId = sessionId,
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
                        Email = "sshrikhande@tavisca.com",
                        FirstName = "Shweta",
                        LastName = "Shrikhande",
                        Prefix = "Mr.",
                        Title = "Mr",
                        UserId = 26149061229281280,
                        UserName = "sshrikhande"
                    },
                    FolderName = "sshrikhande",
                    //LastModifiedDate = new DateTime(),
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
                        Email = "sshrikhande@tavisca.com",
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
                            Age = 27,
                            BirthDate = new DateTime(1990,03,03),
                            CustomFields=new StateBag[]
                            {
                                new StateBag(){ Name="Boyd Gaming"},
                                new StateBag(){ Name="IsPassportRequired" , Value="false"}
                            },
                            Email = "shrikhande@tavisca.com",
                            FirstName = "Shweta",
                            Gender = Gender.Male,
                            LastName = "Shrikhande",
                            KnownTravelerNumber="789456",
                            //PassengerId = new Guid("00000000-0000-0000-0000-000000000000"),
                            PassengerType = PassengerType.Adult,
                            PhoneNumber = "123456789",
                            Rph = 0,
                            UserId = 0,
                            UserName = "sshrikhande@tavisca.com"
                        }
                    },
                    Payments = new CreditCardPayment[]
                    {
                        new CreditCardPayment()
                        {
                            PaymentType = PaymentType.Credit,
                            Attributes = new StateBag[]
                            {
                                new StateBag() { Name="API_SESSION_ID", Value=sessionId},
                                new StateBag() { Name="PointOfSaleRule"},
                                new StateBag() { Name="SectorRule"},
                                new StateBag() { Name="_AttributeRule_Rovia_Username"},
                                new StateBag() { Name="_AttributeRule_Rovia_Password"}
                            },
                            CardMake = new CreditCardMake()
                            {
                                Code = "VI",
                                Name = "Visa"
                            },
                            CardType = CreditCardType.Personal,
                            ExpiryMonthYear = new DateTime(2019, 01, 01),
                            NameOnCard = "Saurabh Cache",
                            IsThreeDAuthorizeRequired = false,
                            Number = "0000000000001111",
                            SecurityCode = "123",
                            Amount = tripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalFare,
                            //new Money()
                            //{
                            //    Amount = 200.34M,
                            //    Currency = "USD",
                            //    DisplayAmount = 200.34M,
                            //    DisplayCurrency = "USD"
                            //},
                            BillingAddress = new Address()
                            {
                                CodeContext = LocationCodeContext.Address,
                                AddressLine1 = "5100 Tennyson Parkway",
                                AddressLine2 = "dsv effs",
                                PhoneNumber = "972-805-5200",
                                ZipCode = "75024",
                                City = new City()
                                {
                                    Code = "PLN",
                                    CodeContext = LocationCodeContext.City,
                                    Name = "Plano",
                                    Country = "US",
                                    State = "TX"

                                }
                            },
                        }
                    },
                    //Products = new HotelTripProduct[] { (HotelTripProduct)TripProductPriceCache.Cache[sessionId].TripProduct },
                    Products = new HotelTripProduct[]
                    {
                        new HotelTripProduct()
                        {
                            Attributes=new StateBag[]
                            {
                                new StateBag{ Name ="API_SESSION_ID", Value=sessionId},
                                new StateBag{ Name ="token", Value=""},
                                new StateBag{ Name ="ChargingHoursPriorToCPW", Value="48"},
                                new StateBag{ Name ="IsLoginWhileSearching", Value="Y"},
                                new StateBag{ Name ="IsInsuranceSelected", Value="no"},
                            },
                            /*Id=Guid.Parse("372c3e4b-7e20-4590-8e83-2a0c54f3303f"),*/
                            IsOnlyLeadPaxInfoRequired=true,
                            Owner=new User()
                            {
                                AdditionalInfo=new StateBag[]
                                {
                                    new StateBag(){Name="AgencyName", Value="WV"},
                                    new StateBag(){ Name="CompanyName", Value="Rovia"},
                                    new StateBag(){ Name="UserType", Value="Normal"}
                                },
                                 Email = "sbejugam@v-worldventures.com",
                                 FirstName = "Sandbox",
                                 LastName = "Test",
                                 MiddleName = "User",
                                 Prefix = "Mr.",
                                 Title = "Mr",
                                 UserId = 169050,
                                 UserName = "3285301"
                            },
                            PassengerSegments=new PassengerSegment[]
                            {
                                new PassengerSegment()
                                {
                                    BookingStatus=TripProductStatus.Planned,
                                    PostBookingStatus=PostBookingTripStatus.None,
                                    Rph=0
                                }
                            },
                            PaymentBreakups=new PaymentBreakup[]
                            {
                                new PaymentBreakup()
                                {
                                    Amount=tripProduct.HotelItinerary.Rooms[0].DisplayRoomRate.TotalFare
                                }
                            },
                            PaymentOptions=new PaymentType[]
                            {
                                PaymentType.SoftCash,
                                PaymentType.External,
                                PaymentType.Credit
                            },
                            Rph=4,
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
                                            Ages=new int[]{27},
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
          //  tripFolderBookRQ.TripFolder.Products[0].Owner = tripFolderBookRQ.TripFolder.Owner;
            TripsEngineClient tripsEngineClient = new TripsEngineClient();
            var response = await tripsEngineClient.BookTripFolderAsync(tripFolderBookRQ);
            TripFolderCache.Cache[sessionId] = response;
            return response;
        }
    }
}
