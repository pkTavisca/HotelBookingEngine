﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TripEngineServiceReference;
using HotelBookingServer.Implementations;

namespace HotelBookingServer.Services
{
    public class PaymentService
    {
        public async Task<CompleteBookingRS> BookTripFolder(string sessionId)
        {
            var tripFolderRS = TripFolderCache.Cache[sessionId];
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
            TripsEngineClient tripsEngineClient = new TripsEngineClient();
            CompleteBookingRS result = await tripsEngineClient.CompleteBookingAsync(bookingRQ);
            return result;
        }
    }
}