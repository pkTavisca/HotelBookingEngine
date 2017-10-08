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
    for (itinerary of result.itineraries) {
        if (itinerary.itineraryType !== "Hotel") continue;
        hotelListHtml += "<div>" + itinerary.hotelProperty.name + "</div>";
    }
    $("#hotel-list").html(hotelListHtml);
}