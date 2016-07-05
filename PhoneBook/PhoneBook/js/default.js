$(document).ready(function () {
    var request = { text: "Некоторый текст" };

    $.ajax({
        url: "/PhoneBookService.svc/Echo",
        data: JSON.stringify(request),
        dataType: "json",
        method: "POST",
        processData: false,
        contentType: "application/json"
    }).done(function(response) {
        alert("Результат ajax: " + response);
    });
});