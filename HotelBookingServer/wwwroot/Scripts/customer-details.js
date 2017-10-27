$(document).ready(function () {
    var sessionId = sessionStorage.getItem('SessionId');
    $("#confirmation").on("click", function () {
        var firstName = $("#FisrtName").val();
        var middleName = $("#MiddleName").val();
        var lastName = $("#LastName").val();
        var email = $("#email").val();
        var phoneNum = $("#phone").val();
        var day = $("#date option:selected").val();
        var month = $("#month option:selected").val();
        var year = $("#year option:selected").val();
        var addressLine1 = $("#addressLine1").val();
        var addressLine2 = $("#addressLine2").val();
        var city = $("#city").val();
        var country = $("#Country option:selected").val();
        var zipcode = $("#zipcode").val();

        var bookTripRequest =
            {
                FirstName: firstName,
                LastName: lastName,
                MiddleName: middleName,
                Email: email,
                PhoneNumber: phoneNum,
                Day: day,
                Month: month,
                Year: year,
                AdressLine1: addressLine1,
                AdressLIne2: addressLine2,
                City: city,
                Country: country,
                ZipCode: zipcode,
                SessionID: sessionId
            };
        try {
            $.ajax({
                type: "POST",
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                url: '../../api/tripfolder/post',
                success: confirmation,
                cache: false,
                data: JSON.stringify(bookTripRequest),
                dataType: 'json',
                crossDomain: true,
               
            });
        }
        catch (exception) {
            alert("Cannot connect to server ");
        }
        function confirmation(result) {
            sessionStorage.setItem('ConfirmationDetails', JSON.stringify(result));
            window.location.href = "/Confirmation";
        }
    });
});