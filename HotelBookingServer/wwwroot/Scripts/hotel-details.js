var currentUrl = window.location.href;
var lastIndex = currenturl.lastindexof("/");
var hotelId = currenturl.slice(lastindex + 1);
var searchResults;

//function hotelAjaxCall() {
//    $.ajax({
//        type: "get",
//        url: '../api/hotel/single/' + hotelid,
//        success: onsuccess
//    });
//}
//hotelAjaxCall();

//$(function onSuccess(result) {
//    Console.log(result);
//    var result = [];

//    var template = $('#room-item');

//    var compiledTemplate = Handlebars.compile(template.html());

//    var html = compiledTemplate(result);

//    $('#roomList-container').html(html);
//});

$(function () {
    var result = [{ name: "Hyatt", cost: "4000", address: "pune", roomtype: "Single-Seater", description: "five" },
    { name: "Novotel", cost: "5000", address: "Nagar Road", roomtype: "Single-Seater", description: "five" },
    { name: "Taj", cost: "4122", address: "Mumbai", roomtype: "single occupancy", description: "abcdefghi" },
    { name: "Bombay Hotel", cost: "2000", address: "Guess??", roomtype: "Double occupancy", description: "qwerty" }];

    var template = $('#room-item');

    var compiledTemplate = Handlebars.compile(template.html());

    var html = compiledTemplate(result);

    $('#roomList-container').html(html);
});


