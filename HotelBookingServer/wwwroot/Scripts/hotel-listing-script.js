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
    var htmlContainer = $('<div />');
    for (itinerary of result.itineraries) {
        i++;
        if (isHotel && i > 1) continue;
        if (itinerary.itineraryType !== "Hotel") continue;
        for (itinerary of result.itineraries) {
            if (itinerary.itineraryType !== "Hotel") continue;
            htmlContainer.append("<h2>" + itinerary.hotelProperty.name + "</h2>" + " " + "<p>" + "City : " + itinerary.hotelProperty.address.city.name + "</p>" + " " + " " + "Country : " + itinerary.hotelProperty.address.city.country + " " + "<p>" + "Rating : " + itinerary.hotelProperty.hotelRating.rating + "</p>" + "<p>" + "Address : " + itinerary.hotelProperty.address.addressLine1 + "</p>");
            for (imageUrl of itinerary.hotelProperty.mediaContent) {
                var imglink = '<img width=100 height=100 src="' + imageUrl.url + '" />';
                htmlContainer.append(imglink);
            }
        }
    }
}