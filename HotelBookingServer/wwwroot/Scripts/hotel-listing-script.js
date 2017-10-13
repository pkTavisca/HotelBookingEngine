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
    for (i = 0; i < searchResults.itineraries.length; i++) {
        for (k = 0; k < searchResults.itineraries[i].hotelProperty.mediaContent.length; k++) {
            if (searchResults.itineraries[i].hotelProperty.mediaContent[k].url != null) {
                urlImage = searchResults.itineraries[i].hotelProperty.mediaContent[k].url.toString();
                break;
            }
        }
        hotelList.push({
            image: urlImage,
            name: searchResults.itineraries[i].hotelProperty.name,
            address: searchResults.itineraries[i].hotelProperty.address.completeAddress,
            cost: searchResults.itineraries[i].fare.totalFare.amount +" "+searchResults.itineraries[i].fare.totalFare.currency,
            rating: searchResults.itineraries[i].hotelProperty.hotelRating.rating,

        });
    }
    var template = $('#hotel-item');
    var compiledTemplate = Handlebars.compile(template.html());
    var html = compiledTemplate(hotelList);
    $('#hotelList-container').html(html);
}