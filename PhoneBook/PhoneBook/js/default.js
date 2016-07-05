$(document).ready(function () {
    var request = { text: "Некоторый текст" };

    $.ajax({
        url: "/PhoneBookService.svc/AddContact",
        data: JSON.stringify(),
        dataType: "json",
        method: "POST",
        processData: false,
        contentType: "application/json"
    }).done(function() {
        alert("Результат ajax: ");
    });
});