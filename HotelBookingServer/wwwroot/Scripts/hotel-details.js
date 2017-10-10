var currentUrl = window.location.href;
var lastIndex = currentUrl.lastIndexOf("/");
var hotelId = currentUrl.slice(lastIndex + 1);

function hotelAjaxCall() {
    $.ajax({
        type: "GET",
        url: '../api/hotel/single/' + hotelId,
        success: onSuccess
    });
}

function onSuccess(result) {
    console.log(result);
}

hotelAjaxCall();