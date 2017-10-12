var dataToSend;
var jsonobject;
$("#search-field").keyup(function() {
    var search = $("#search-field")[0].value;
    $.ajax({
        url: '/api/search/getAutoSuggestResults/' + search,
        type: 'get',
        contentType: "application/json",
        success: function(jsonresult) {
            $('#search-field').autocomplete({
                minChars: 3,
                source: parseit(jsonresult),
                select: function(e, mdata) {
                    dataToSend = mdata;
                }
            });

        }
    })
})

function parseit(jsonresult) {
    var parsed = [];
    jsonobject = JSON.parse(jsonresult);
    for (var i = 0; i < jsonobject[0].ItemList.length; i++) {
        parsed.push({ value: jsonobject[0].ItemList[i].CulturedText, data: jsonobject[0].ItemList[i] });
    }
    return parsed;
}

$("button").click(function() {
    var term = dataToSend;
    var ci = $("#ci-datepicker")[0].value;
    var co = $("#co-datepicker2")[0].value;
    var data = {
        "searchterm": JSON.stringify(term),
        "checkin": ci,
        "checkout": co
    }
    var datam = JSON.stringify(data);
    $.ajax({
        url: '/api/search/new',
        type: 'post',
        contentType: "application/json",
        success: function(result) {
            window.location.href = "/hotellisting/" + term.item.data.SearchType + "/" + result;
        },
        data: datam
    });
});