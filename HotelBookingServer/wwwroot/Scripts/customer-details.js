﻿var sessionId;
var result;
$(document).ready(function () {
    sessionId = sessionStorage.getItem('SessionId');
});
function formInfo() {
    $("#confirmation").on("click", function () {
        var firstName = $("#FirstName").val();
        var middleName = $("#MiddleName").val();
        var lastName = $("#LastName").val();
        var email = $("#email").val();
        var phoneNum = $("#phone").val();
        var day = $("#date option:selected").val();
        var month = $("#month option:selected").val();
        var year = $("#year option:selected").val();
        var addressLine1 = $("#addressLine1").val();
        var addressLine2 = $("#addressLine2").val();
        var city = $("#city").val();
        var country = $("#Country option:selected").val();
        var zipcode = $("#zipcode").val();

        var bookTripRequest =
            {
                FirstName: firstName,
                LastName: lastName,
                MiddleName: middleName,
                Email: email,
                PhoneNumber: phoneNum,
                Day: day,
                Month: month,
                Year: year,
                AdressLine1: addressLine1,
                AdressLIne2: addressLine2,
                City: city,
                Country: country,
                ZipCode: zipcode,
                SessionID: sessionId
            };
        var customerData = JSON.stringify(bookTripRequest);
        $.ajax({

            url: '../../api/TripFolder/post',
            type: 'post',
            crossDomain: true,
            data: customerData,
            dataType: 'json',
            contentType: 'application/json',
            success: function (result) {
                sessionStorage.setItem('PaymentDetails', JSON.stringify(sessionId));
                window.location.href = "/payment-index";
            }

        });

    });
}
