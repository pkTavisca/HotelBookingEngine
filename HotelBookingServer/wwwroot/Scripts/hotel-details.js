var currentUrl = window.location.href;
var lastIndex = currentUrl.lastIndexOf("/");
var hotelId = currentUrl.slice(lastIndex + 1);
var searchResults;

function hotelAjaxCall() {
    $.ajax({
        type: "GET",
        url: '../api/hotel/single/' + hotelId,
        success: onSuccess
    });
}
hotelAjaxCall();

function onSuccess(result) {
    console.log(result);
    


    }

