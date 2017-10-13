var currentUrl = window.location.href;
var lastIndex = currentUrl.lastIndexOf("/");
var hotelId = currentUrl.slice(lastIndex + 1);
var sessionId = currentUrl.split('/')[4];
var presentAmenities = [];

Handlebars.registerHelper('nonRepeatingAmenitiesCond', function(amenity, options) {
    if (checkIfPresent(amenity)) {
        return options.inverse(this);
    } else {
        presentAmenities.push(amenity);
        return options.fn(this);
    }
});

function checkIfPresent(amenity) {
    for (presentAmenity of presentAmenities) {
        if (presentAmenity.masterAmenityId === amenity.masterAmenityId) {
            return true;
        }
    }
    return false;
}

function hotelAjaxCall() {
    $.ajax({
        type: "get",
        url: '../../api/hotel/single/' + sessionId + "/" + hotelId,
        success: onSuccess
    });
}

function onSuccess(result) {
    priceAjaxCall();
    var template = $('#room-item');
    var compiledTemplate = Handlebars.compile(template.html());
    var html = compiledTemplate(result);
    $('#roomList-container').html(html);
}

function priceAjaxCall() {
    $.ajax({
        type: "get",
        url: '../../api/roomprice/get/' + sessionId,
        success: function(result) {
            console.log(result);
        }
    });
}

hotelAjaxCall();