var currentUrl = window.location.href;
var lastIndex = currenturl.lastindexof("/");
var hotelId = currenturl.slice(lastindex + 1);
var searchResults;

function hotelAjaxCall() {
    $.ajax({
        type: "get",
        url: '../api/hotel/single/' + hotelid,
        success: onsuccess
    });
}
hotelAjaxCall();

$(function onSuccess(result) {
    Console.log(result);
    var result = [];

    var template = $('#room-item');

    var compiledTemplate = Handlebars.compile(template.html());

    var html = compiledTemplate(result);

    $('#roomList-container').html(html);
});


