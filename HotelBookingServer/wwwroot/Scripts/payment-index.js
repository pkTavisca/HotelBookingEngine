//function checkDate() {
//    var selectedDate = new Date(document.getElementById("expiry_year").value, document.getElementById("expiry_month").value);
//    var today = new Date();
//    if (today > selectedDate) {
//        alert("Invalid Month/Year");
//    }
//    else {
//        alert("Valid Month & Year");
//    }
//}
var sessionId;
var paymentDetails;
$(document).ready(function () {
    sessionId = sessionStorage.getItem('PaymentDetails');
    paymentDetails = JSON.parse(sessionId);

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
        //crossDomain: true,
        //data: paymentInfo,
        //dataType: 'json',
        //contentType: 'application/json',
        success: function (result) {
            sessionStorage.setItem('ConfirmationDetails', JSON.stringify(result));
            window.location.href = "/Confirmation";
        }

    });
}