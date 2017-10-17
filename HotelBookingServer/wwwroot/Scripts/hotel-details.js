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
    for (room of result.itinerary.rooms)
        console.log(room.hotelFareSource.name);
    var template = $('#room-item');
    var compiledTemplate = Handlebars.compile(template.html());
    var html = compiledTemplate(result);
    $('#roomList-container').html(html);
}

function priceAjaxCall(roomId) {
    $.ajax({
        type: "get",
        url: '../../api/roomprice/get/' + sessionId + '/' + roomId,
        success: function(result) {
            $.ajax({
                type: "get",
                url: '../../api/tripfolder/get/' + sessionId,
                success: function(result2) {
                    var x = result2;
                    console.log(x);
                    $.ajax({
                        type: "get",
                        url: '../../api/payment/payment/' + sessionId,
                        success: function(result3) {
                            console.log(result3);
                        }
                    });
                }
            });
        }
    });
}

hotelAjaxCall();