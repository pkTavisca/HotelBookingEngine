﻿var currentUrl = window.location.href;
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

Handlebars.registerHelper('loop', function(n, options) {
    var total = '';
    for (var i = 0; i < n; i++) {
        total += options.fn(n);
    }
    return total;
});

Handlebars.registerHelper('loopun', function(n, options) {
    var total = '';
    n = 5 - n;
    for (var i = 0; i < n; i++) {
        total += options.fn(n);
    }
    return total;
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
        success: onSuccess,
        error: onSuccess
    });
}

function onSuccess(result) {
    result = hotelSingleAvailDetails;
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
                    var x = JSON.stringify(result2)
                    console.log(x);
                }
            });
        }
    });
}

hotelAjaxCall();