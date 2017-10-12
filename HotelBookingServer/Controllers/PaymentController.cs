using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TripEngineServiceReference;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelBookingServer.Controllers
{
    [Route("/api/[controller]")]
    public class PaymentController : Controller
    {
        [HttpGet("Payment")]
        public async Task<CompleteBookingRS> Payments()
        {
            CreditCardPayment creditCardPayment = new CreditCardPayment()
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
                SecurityCode = "123"

            };

            CompleteBookingRQ bookingRQ = new CompleteBookingRQ();
            bookingRQ.ResultRequested = ResponseType.Unknown;
            bookingRQ.SessionId = Guid.NewGuid().ToString();
            bookingRQ.ExternalPayment = new CreditCardPayment()
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
                Amount = new Money()
                {
                    Amount = 41.20M,
                    BaseEquivAmount = 0M,
                    BaseEquivCurrency = "USD",
                    Currency = "USD",
                    DisplayAmount = 41.20M,
                    DisplayCurrency = "USD",
                    UsdEquivAmount = 0M
                },


                Attributes = new StateBag[]
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
                },
                BillingAddress = new Address()
                {
                    Code = "true",
                    CodeContext = LocationCodeContext.Address,
                    GmtOffsetMinutes = 0,
                    Id = 0,
                    AddressLine1 = "5360 Legacy Drive Suite 300",
                    City = new City()
                    {
                        CodeContext = LocationCodeContext.City,
                        GmtOffsetMinutes = 0,
                        Id = 0,
                        Name = "Plano",
                        Country = "US",
                        State = "TX"
                    },
                    PhoneNumber = "1214-231-5445",
                    ZipCode = "75024"
                },
                Id = new Guid("00000000-0000-0000-0000-000000000000"),
                PaymentType = PaymentType.Credit,
                Rph = 0,
                //CardMake = creditCardPayment
            };
            bookingRQ.TripFolderId = new Guid("bb900986-6117-40f5-8d2e-f72a32ea5185");

            TripsEngineClient tripsEngineClient = new TripsEngineClient();
            CompleteBookingRS result = await tripsEngineClient.CompleteBookingAsync(bookingRQ);
            return result;
        }
    }
}
