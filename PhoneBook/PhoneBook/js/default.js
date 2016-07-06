$(document).ready(function() {
    var request = {
        contact: {
            name: "Иван",
            surname: "Иванов",
            phone: "234324"
        }
    };

    /*$.ajax({
            url: "/PhoneBookService.svc/AddContact",
            data: JSON.stringify(request),
            dataType: "json",
            method: "POST",
            processData: false,
            contentType: "application/json"
        })
        .done(function() {
            alert("Создан контакт");
    });

    $.ajax({
        url: "/PhoneBookService.svc/GetContacts",
        data: {},
        dataType: "json",
        method: "POST",
        processData: false,
        contentType: "application/json"
    }).done(function (contacts) {
        alert(JSON.stringify(contacts));
    });*/
})