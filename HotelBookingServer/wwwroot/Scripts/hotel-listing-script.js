var currentUrl = window.location.href;
var lastIndex = currentUrl.lastIndexOf("/");
var guid = currentUrl.slice(lastIndex + 1);
var searchResults;

$.ajax({
    type: "GET",
    url: '../api/search/get/' + guid,
    success: function(result) {
        searchResults = JSON.parse(result.searchTerm).item.data;
        hotelAjaxCall();
    }
});

function hotelAjaxCall() {
    $.ajax({
        type: "GET",
        url: '../api/hotel/get/' + searchResults.SearchType + '/' + searchResults.Latitude + '/' + searchResults.Longitude,
        success: onSuccess
    });
}

function onSuccess(result) {
    $("#loading-icon").hide();
    var hotelListHtml = "";
    var isHotel = false;
    if (searchResults.SearchType === "Hotel" || searchResults.SearchType === "hotel")
        isHotel = true;
    var i = 0;
    var htmlContainer = $('#hotel-list');
    htmlContainer.addClass('somediv');
    for (itinerary of result.itineraries) {
        i++;
        if (isHotel && i > 1) continue;
        if (itinerary.itineraryType !== "Hotel") continue;
        var singleHotel = $("<article>");
        singleHotel.addClass("hotel-info");
        htmlContainer.append(singleHotel);
        var hotelId = itinerary.hotelProperty.id;
        var detailsDiv = $('<div class="one-hotel-info">');
        singleHotel.append(detailsDiv);
        detailsDiv.append("<h2><a href='../HotelDetails/" + hotelId + "'>" + itinerary.hotelProperty.name + "</a></h2>");
        detailsDiv.append("<p>" + "<span>" + "Address : " + "</span>" + itinerary.hotelProperty.address.completeAddress + "," + " " + itinerary.hotelProperty.address.city.country + "</p>" + "<p>" + "<span>" + "Rating : " + "</span>" + itinerary.hotelProperty.hotelRating.rating + "*" + "</p>" + "<p>" + "<span>" + "Price : " + "</span>" + itinerary.fare.baseFare.amount + " " + itinerary.fare.baseFare.currency + "</p>");

        var imagesDiv = $('<div class="img-format">');
        imagesDiv.css("display", "flex");

        singleHotel.prepend(imagesDiv);
        singleHotel.css("display", "flex");
        var imglink = '<img   width=250 height=250 src="' + itinerary.hotelProperty.mediaContent[0].url + '" />';
        imagesDiv.append(imglink);
    }
}