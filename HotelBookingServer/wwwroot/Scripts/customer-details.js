var sessionId;
var result;
$(document).ready(function() {
    sessionId = sessionStorage.getItem('SessionId');
});
for (var i = 2017; i >= 1947; i--) {
    $("#year").append("<option value='" + i + "'>" + i + "</option>");
}

function formInfo() {
    var firstName = $("#FirstName").val();
    var middleName = $("#MiddleName").val();
    var lastName = $("#LastName").val();
    var gender = $("#gender option:selected").val();
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

    var bookTripRequest = {
        FirstName: firstName,
        LastName: lastName,
        MiddleName: middleName,
        Gender: gender,
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
    sessionStorage.setItem('passengerDetails', customerData);
    window.location.href = "/payment-index";
}