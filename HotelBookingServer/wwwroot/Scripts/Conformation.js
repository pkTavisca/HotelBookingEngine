$(document).ready(function() {
    var result = sessionStorage.getItem('ConfirmationDetails');
    var passengerDetails = JSON.parse(sessionStorage.getItem('passengerDetails'));
    var confirmationDetails = JSON.parse(result);
    var inDate = confirmationDetails.CheckIn;
    var outDate = confirmationDetails.CheckOut;
    var htmlData = {
        ConfirmationId: " " + confirmationDetails.ConfirmationID,
        hotelName: " " + confirmationDetails.HotelName,
        roomName: " " + confirmationDetails.RoomName,
        checkInDate: " " + confirmationDetails.CheckIn,
        checkOutDate: " " + confirmationDetails.CheckOut,
        nightsOfStay: " " + confirmationDetails.NoOfNights,
        email: " " + confirmationDetails.Email,
        address: " " + confirmationDetails.Address
    }
    $("#hotelName").html(htmlData.hotelName);
    $("#email").html(htmlData.email);
    $("#address").html(htmlData.address);
    $("#roomName").html(htmlData.roomName);
    $("#checkIn").html(htmlData.checkInDate);
    $("#checkOut").html(htmlData.checkOutDate);
    $("#nights").html(htmlData.nightsOfStay);
    $("#bookingId").html(htmlData.ConfirmationId);
    $("#name").html(passengerDetails.FirstName + " " + passengerDetails.MiddleName + " " + passengerDetails.LastName + ",");
});