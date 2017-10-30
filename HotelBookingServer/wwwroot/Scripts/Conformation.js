$(document).ready(function () {
    var result = sessionStorage.getItem('ConfirmationDetails');
    var confirmationDetails = JSON.parse(result);
    //var data = sessionStorage.getItem('UpdatedPrice');
    //var updatedData = JSON.parse(data);
    var inDate = confirmationDetails.checkinDate;
    var outDate = confirmationDetails.checkoutDate;
    var htmlData = {
        ConfirmationId: " "+confirmationDetails.
        hotelName: " " + confirmationDetails.hotelName,
        roomName: " " + confirmationDetails.roomName,
        checkInDate: " " + inDate,
        checkOutDate: " " + outDate,
        nightsOfStay: " " + confirmationDetails.nights
        //amount: " " + (" " + confirmationDetails.status)
    }
    $("#hotelName").val(htmlData.hotelName);
    $("#roomName").val(htmlData.roomName);
    $("#checkIn").val(htmlData.checkInDate);
    $("#checkOut").val(htmlData.checkOutDate);
    $("#nights").val(htmlData.nightsOfStay);
});