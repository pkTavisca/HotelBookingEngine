var currentUrl = window.location.href;
var lastIndex = currentUrl.lastIndexOf("/");
var hotelId = currentUrl.slice(lastIndex + 1);
var sessionId = currentUrl.split('/')[4];
var searchResults;

function hotelAjaxCall() {
    $.ajax({
        type: "get",
        url: '../../api/hotel/single/' + sessionId + "/" + hotelId,
        success: onSuccess
    });
}
hotelAjaxCall();

function onSuccess(result) {
    var template = $('#room-item');
    var compiledTemplate = Handlebars.compile(template.html());
    var html = compiledTemplate(result);
    $('#roomList-container').html(html);
}