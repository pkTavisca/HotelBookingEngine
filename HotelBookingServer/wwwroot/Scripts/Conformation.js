$(document).ready(function () {
    var result = sessionStorage.getItem('ConfirmationDetails');
    var confirmationDetails = JSON.parse(result);
    //var data = sessionStorage.getItem('UpdatedPrice');
    //var updatedData = JSON.parse(data);
    var inDate = confirmationDetails.checkinDate;
    var outDate = confirmationDetails.checkoutDate;
    var htmlData = {
        ConfirmationId: " " + confirmationDetails.ConfirmationID,
        hotelName: " " + confirmationDetails.HotelName,
        roomName: " " + confirmationDetails.RoomName,
        checkInDate: " " + confirmationDetails.CheckIn,
        checkOutDate: " " + confirmationDetails.CheckOut,
        nightsOfStay: " " + confirmationDetails.NoOfNights,
        email: " " + confirmationDetails.Email,
        address: " " + confirmationDetails.Address

        //amount: " " + (" " + confirmationDetails.status)
    }
    $("#hotelName").val(htmlData.hotelName);
    $("#email").val(htmlData.email);
    $("#address").val(htmlData.address);
    $("#roomName").val(htmlData.roomName);
    $("#checkIn").val(htmlData.checkInDate);
    $("#checkOut").val(htmlData.checkOutDate);
    $("#nights").val(htmlData.nightsOfStay);
});