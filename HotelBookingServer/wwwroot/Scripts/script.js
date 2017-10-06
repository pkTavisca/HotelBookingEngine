$("button").click(function () {
    var term = $("#search-field")[0].value;
    var ci = $("#ci-datepicker")[0].value;
    var co = $("#co-datepicker2")[0].value;
    var data = {
        "searchterm": term,
        "checkin": ci,
        "checkout": co
    }
    var datam = JSON.stringify(data);
    $.ajax({
        url: '/api/search/new',
        type: 'post',
        contentType: "application/json",
        success: function (result) {
            alert(result);
        },
        data: datam
    });
});


var jsonobject;
$("#search-field").keyup(function () {
    var search = $("#search-field")[0].value;
    $.ajax({
        url: '/api/search/getAutoSuggestResults/' + search,
        type: 'get',
        contentType: "application/json",
        success: function (jsonresult) {

            alert(parseit(jsonresult));

        }
    })
})
function parseit(jsonresult) {
    var ooo
    var outputf;
    jsonobject = JSON.parse(jsonresult);
    for (var i = 0; i < jsonobject[0].ItemList.length; i++) {
        ooo += jsonobject[0].ItemList[i].Name + "\n";
    }
    return ooo;
}
