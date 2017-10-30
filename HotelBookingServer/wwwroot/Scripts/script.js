var datatobesend;
var jsonobject;
$("#search-field").keyup(function () {
    var search = $("#search-field")[0].value;
    $.ajax({
        url: '/api/search/getAutoSuggestResults/' + search,
        type: 'get',
        contentType: "application/json",
        success: function (jsonresult) {
            $('#search-field').autocomplete({
                minChars: 3,
                source: parseit(jsonresult),
                select: function (e, mdata) {
                    datatobesend = mdata;
                    console.log(mdata);
                }
            });

        }
    })
})

function parseit(jsonresult) {
    var ooo = [];
    jsonobject = JSON.parse(jsonresult);
    for (var i = 0; i < jsonobject[0].ItemList.length; i++) {
        ooo.push({ value: jsonobject[0].ItemList[i].CulturedText, data: jsonobject[0].ItemList[i] });
    }
    return ooo;
}
$("button").click(function () {
    var term = datatobesend;
    var ci = $("#ci-datepicker")[0].value;
    var co = $("#co-datepicker2")[0].value;
    var data = {
        "searchterm": JSON.stringify(term),
        "checkin": ci,
        "checkout": co
    }
    var datam = JSON.stringify(data);
    console.log(datam);
    $.ajax({
        url: '/api/search/new',
        type: 'post',
        contentType: "application/json",
        success: function (result) {
            window.location.href = "/hotellisting/" + term.item.data.SearchType + "/" + result;
        },
        data: datam
    });
});