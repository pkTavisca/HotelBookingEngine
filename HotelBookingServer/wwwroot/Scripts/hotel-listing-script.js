$.ajax({
    type: "GET",
    url: '../api/hotel/get',
    success: onSuccess
});

function onSuccess(result) {
    var hotelListHtml = "";
    for (itinerary of result.itineraries) {
        if (itinerary.itineraryType !== "Hotel") continue;
        hotelListHtml += "<div>" + itinerary.hotelProperty.name + "</div>";
    }
    $("#hotel-list").html(hotelListHtml);
}