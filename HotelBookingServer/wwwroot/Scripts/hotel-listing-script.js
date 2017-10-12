var currentUrl = window.location.href;
var lastIndex = currentUrl.lastIndexOf("/");
var guid = currentUrl.slice(lastIndex + 1);
var searchResults;

$.ajax({
    type: "GET",
    url: '../api/search/get/' + guid,
    success: function (hotel) {
        searchResults = JSON.parse(hotel.searchTerm).item.data;
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

function bookNowButtonClick(id) {
    window.location.href = "../HotelDetails/" + id;
}

function onSuccess(hotel) {
searchResults = hotel;
var hotelList = [];
var urlImage = "";
for (i = 0; i < hotel.itinerary.length; i++) {
    for ( k = 0; k < hotel.itinerary[i].hotelProperty.mediaContent.length; k++) {
        if (hotel.itinerary[i].hotelProperty.mediaContent[k].url != null) {
            urlImage = hotel.itinerary[i].hotelProperty.mediaContent[k].url.toString();
            break;
        }
    }
    hotelList.push({
        image: urlImage,
        name: hotel.itinerary[i].hotelProperty.name,
        address: hotel.itinerary[i].hotelProperty.address.completeAddress,
        cost: hotel.itinerary[i].fare.baseFare.amount,
    });
}
var template = $('#hotel-item');
var compiledTemplate = Handlebars.compile(template.html());
var html = compiledTemplate(hotelList);
$('#hotelList-container').html(html);
}