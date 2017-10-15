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
            TripFolderBookRQ tripFolderBookRQ2 = new TripFolderBookRQ()
            {
                TripFolder = new TripFolder()
                {
                    Passengers = new Passenger[]
                    {
                        new Passenger()
                        {
                            Age = 30,
                            BirthDate = DateTime.Now,
                            CustomFields = new StateBag[]
                            {
                                new StateBag()
                                {
                                    Name = "Boyd Gaming"
                                },
                                new StateBag()
                                {
                                    Name = "IsPassportRequired"
                                }
                            },
                            Email = "rsarda@tavisca.com",
                            FirstName = "Sandbox",
                            Gender = Gender.Male,
                            KnownTravelerNumber  ="789456",
                            LastName = "Test",
                            PassengerId = new Guid("00000000-0000-0000-0000-000000000000"),
                            PassengerType = PassengerType.Adult,
                            PhoneNumber = "1111111111",
                            Rph = 0,
                            UserId = 0,
                            UserName = "rsarda@tavisca.com"
                        }
                    },
                    Payments = new Payment[]
                    {
                        new CreditCardPayment()
                        {
                            CardMake = new CreditCardMake()
                            {
                                Code = "VI",
                                Name = "Visa"
                            },
                            CardType = CreditCardType.Personal,
                            ExpiryMonthYear = new DateTime(2020,1,1),
                            IsThreeDAuthorizeRequired = false,
                            NameOnCard = "test card",
                            Number = "0000000000001111",
                            SecurityCode = "123",
                            Amount = new Money()
                            {
                                Amount = (decimal)73.49,
                                BaseEquivAmount = (decimal)73.49,
                                BaseEquivCurrency = "USD",
                                DisplayAmount = 0,
                                DisplayCurrency="",
                                UsdEquivAmount = (decimal)73.49
                            },
                            Attributes = new StateBag[]
                            {
                                new StateBag()
                                {
                                    Name = "API_SESSION_ID",
                                    Value = sessionId
                                },
                                new StateBag()
                                {
                                    Name = "PointOfSaleRule"
                                },
                                new StateBag()
                                {
                                    Name = "SectorRule"
                                },
                                new StateBag()
                                {
                                    Name = "_AttributeRule_Rovia_Username"
                                },
                                new StateBag()
                                {
                                    Name = "_AttributeRule_Rovia_Password"
                                }
                            },
                            BillingAddress = new Address()
                            {
                                AddressLine1 = "E Sunset Rd",
                                AddressLine2 = "Near Trade Center",
                                City = new City()
                                {
                                    Country = "US",
                                    State = "State",
                                    CodeContext = LocationCodeContext.City,
                                    GmtOffsetMinutes = 0,
                                    Id = 0,
                                    Name = "LAS"
                                },
                                PhoneNumber = "123456",
                                ZipCode = "123456",
                                CodeContext = LocationCodeContext.Address,
                                GmtOffsetMinutes = 0,
                                Id = 0
                            },
                            Id = new Guid("00000000-0000-0000-0000-000000000000"),
                            PaymentType = PaymentType.Credit,
                            Rph = 0
                        }
                    },
                    Products = new HotelTripProduct[]{
                        new HotelTripProduct()
                        {
                            HotelItinerary = ((HotelTripProduct)(TripProductPriceCache.Cache[sessionId].TripProduct)).HotelItinerary,
                            HotelSearchCriterion = ((HotelTripProduct)(TripProductPriceCache.Cache[sessionId].TripProduct)).HotelSearchCriterion
                        }
                    }
                },
                TripProcessingInfo = new TripProcessingInfo()
                {
                    TripProductRphs = new int[] { 4 }
                }
            };
            TripFolderBookRQ tripFolderBookRQ = new TripFolderBookRQ()
            {
                SessionId = sessionId,
                ResultRequested = ResponseType.Unknown,
                TripFolder = new TripFolder()
                {
                    Creator = new User()
                    {
                        Email = "sshrikhande@tavisca.com",
                        FirstName = "Shweta",
                        LastName = "Shrikhande",
                        UserId = 26149061229281280,
                        UserName = "sshrikhande"
                    },
                    FolderName = "sshrikhande",
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    LastModifiedDate = new DateTime(),
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
                        UserId = 26149061229281280,
                        UserName = "sshrikhande"
                    },
                    Pos = new PointOfSale()
                    {
                        PosId = 101,
                        Requester = new Company()
                        {
                            DK = "200000D",
                            ID = 0,
                            CodeContext = CompanyCodeContext.HotelChain,

                        }
                    },
                    Type = TripFolderType.Personal,
                    Passengers = new Passenger[]
                    {
                        new Passenger()
                        {
                            Age = 27,
                            BirthDate = new DateTime(1990,03,03),
                            Email = "shrikhande@tavisca.com",
                            FirstName = "Shweta",
                            Gender = Gender.Male,
                            LastName = "Shrikhande",
                            PassengerId = new Guid("00000000-0000-0000-0000-000000000000"),
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
                            Amount =//TripProductPriceCache.Cache[sessionId].TripProduct.
                            new Money()
                            {
                                Amount = 200.34M,
                                Currency = "USD",
                                DisplayAmount = 200.34M,
                                DisplayCurrency = "USD"
                            },
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
                    Products = new HotelTripProduct[] { (HotelTripProduct)TripProductPriceCache.Cache[sessionId].TripProduct },
                },
                TripProcessingInfo = new TripProcessingInfo()
                {
                    TripProductRphs = new int[] { 0 }
                }

            };
            tripFolderBookRQ.TripFolder.Products[0].Owner = tripFolderBookRQ.TripFolder.Owner;
            TripsEngineClient tripsEngineClient = new TripsEngineClient();
            var response = await tripsEngineClient.BookTripFolderAsync(tripFolderBookRQ);
            return response;
        }
    }
}
