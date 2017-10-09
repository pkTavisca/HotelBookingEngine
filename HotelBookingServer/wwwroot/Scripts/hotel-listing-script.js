﻿var currentUrl = window.location.href;
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

        singleHotel.append("<h2>" + itinerary.hotelProperty.name + "</h2>" + " " + "<p>" + "<span>" + "Address : " + "</span>" + itinerary.hotelProperty.address.completeAddress + "," + " " + itinerary.hotelProperty.address.city.country + "</p>" + "<p>" + "<span>" + "Rating : " + "</span>" + itinerary.hotelProperty.hotelRating.rating + "*" + "</p>" + "<p>" + "<span>" + "Price : " + "</span>" + itinerary.fare.baseFare.amount + " " + itinerary.fare.baseFare.currency + "</p>");

        var imagesDiv = $('<div class="img-format">');
        imagesDiv.css("display", "flex");

        singleHotel.append(imagesDiv);
        for (imageUrl of itinerary.hotelProperty.mediaContent) {
            var imglink = '<img   width=100 height=100 src="' + imageUrl.url + '" />';
            imagesDiv.append(imglink);
        }
    }
}