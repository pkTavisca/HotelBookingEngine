$(document).ready(function () {
    var data = sessionStorage.getItem('UpdatedPrice');
    var updatedData = JSON.parse(data);
    if (updatedData.hotelName === null) {
        $("#inner-guest-container").hide();
        $("#error-div").show();
    }
    else {
        $("#inner-guest-container").show();
        $("#error-div").hide();
    }
    var inDate = updatedData.checkinDate;
    var outDate = updatedData.checkoutDate;
    var htmlData = {
        hotelName: " " + updatedData.hotelName,
        roomType: " " + updatedData.roomType,
        checkInDate: " " + inDate,
        checkOutDate: " " + outDate,
        duration: " " + updatedData.duration,
        amount: " " + (updatedData.currency + " " + updatedData.updatedPrice)
    }
    $("#hotelName").html(htmlData.hotelName);
    $("#roomName").html(htmlData.roomType);
    $("#checkIn").html(htmlData.checkInDate);
    $("#checkOut").html(htmlData.checkOutDate);
    $("#nights").html(htmlData.duration);
    $("#fare").html(htmlData.amount);
    $('#Proceed-button').click(function () {
        sessionStorage.setItem("SessionId", updatedData.sessionId);
        window.location.href = "customerDetails";
    });
    $('#Cancel-button').click(function () {
        window.location.href = "/index";
    });
});