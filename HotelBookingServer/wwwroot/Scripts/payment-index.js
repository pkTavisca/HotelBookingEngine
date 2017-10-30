var sessionId;
$(document).ready(function() {
    sessionId = sessionStorage.getItem('SessionId');
    var year = 2017;
    for (i = 0; i < 15; i++) {
        $("#expiry_year").get(0).options[$("#expiry_year").get(0).options.length] = new Option(year, year);
        year = year + 1;
    }
});

function paymentInfo() {
    var name = $("#cardHolderName").val();
    var numberOne = $("#numberOne").val();
    var numberTwo = $("#numberTwo").val();
    var numberThree = $("#numberThree").val();
    var numberFour = $("#numberFour").val();
    var cvc = $("#cvc").val();
    var expMonth = $("#expiry_month").val();
    var expYear = $("#expiry_year").val();

    var paymentData = {
        Name: name,
        NumberOne: numberOne,
        NumberTwo: numberTwo,
        NumberThree: numberThree,
        NumberFour: numberFour,
        CVC: cvc,
        ExpMonth: expMonth,
        ExpYear: expYear,
        SessionID: sessionId
    };

    var customerData = JSON.stringify({
        PassengerInfo: JSON.parse(sessionStorage.getItem('passengerDetails')),
        CreditCardInfo: paymentData
    });
    $.ajax({
        url: '../../api/TripFolder/post',
        type: 'post',
        crossDomain: true,
        data: customerData,
        dataType: 'json',
        contentType: 'application/json',
        success: function(result) {
            sessionStorage.setItem('ConfirmationDetails', JSON.stringify(result));
            window.location.href = "/Confirmation";
        }
    });
}