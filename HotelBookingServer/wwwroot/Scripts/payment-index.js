var sessionId;
var paymentDetails;
$(document).ready(function () {
    sessionId = sessionStorage.getItem('PaymentDetails');
    paymentDetails = JSON.parse(sessionId);
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

    var paymentData =
        {
            Name: name,
            NumberOne: numberOne,
            NumberTwo: numberTwo,
            NumberThree: numberThree,
            NumberFour: numberFour,
            CVC: cvc,
            ExpMonth: expMonth,
            ExpYear: expYear,
            SessionID: paymentDetails
        };

    var paymentInfo = JSON.stringify(paymentData);
    $.ajax({

        url: '../../api/Payment/' + paymentDetails,
        type: 'get',
        success: function (result) {
            sessionStorage.setItem('ConfirmationDetails', JSON.stringify(result));
            window.location.href = "/Confirmation";
        }

    });
}