var currentUrl = window.location.href;
var lastIndex = currentUrl.lastIndexOf("/");
var hotelId = currentUrl.slice(lastIndex + 1);

$.ajax({
    type: "GET",
    url: '../api/search/get/' + hotelId,
    success: function (result) {
        searchResults = JSON.parse(result.searchTerm).item.data;
        hotelAjaxCall();
    }
});
function hotelAjaxCall() {
    $.ajax({
        type: "GET",
        url: '../api/hotel/single/' + hotelId,
        success: onSuccess
    });
}

function onSuccess(result) {
    console.log(result);
    $("#loading-icon").hide();
    if (searchResults.SearchType === "Hotel" || searchResults.SearchType === "hotel")
        isHotel = true;
    var i = 0;
    var htmlContainer = $('#single-hotel-list');
    htmlContainer.addClass('hotelinfo-div');

    }

