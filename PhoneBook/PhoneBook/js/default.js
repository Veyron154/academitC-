﻿(function($, ko, _) {
    $(document)
        .ready(function() {
            var vm = new PhoneBookViewModel();
            ko.applyBindings(vm);
            vm.refreshTable();
        });

    function PhoneBookViewModel() {
        var self = this;
        self.tableItems = ko.observableArray([]);
        self.name = ko.observable("");
        self.surname = ko.observable("");
        self.phone = ko.observable("");
        self.isTopChecked = ko.observable(false);
        self.filterText = ko.observable("");
        self.needValidate = ko.observable(false);
        self.url = ko.computed(function() {
            return "/PhoneBookService.svc/Excel?filter=" + self.filterText();
        });

        self.isTopChecked.subscribe(function(newValue) {
            _.each(self.tableItems(),
                function(item) {
                    item.isChecked(newValue);
                });
        });

        self.refreshTable = function () {
            self.tableItems.removeAll();
            ajaxPostRequest("/PhoneBookService.svc/GetContacts", {filter: self.filterText()}).done(function (contacts) {
                _.each(contacts,
                    function (contact) {
                        var addedItem = new TableItemViewModel(contact.name, contact.surname, contact.phone, contact.id);
                        self.tableItems.push(addedItem);
                    });
            });
        }

        var isFiltered = false;

        self.addTableItem = function() {
            self.needValidate(true);

            if (self.surname() === "" || self.name() === "" || self.phone() === "") {
                $.alert({
                    title: "Ошибка заполнения",
                    content: "Заполните выделенные поля",
                    confirmButton: "OK"
                });
                return;
            }

            var isUniquePhone = _.every(self.tableItems(),
                function(item) {
                    return item.itemPhone !== self.phone();
                });


            if (!isUniquePhone) {
                $.alert({
                    title: "Ошибка заполнения",
                    content: "Контакт с номером " + self.phone() + " уже существует",
                    confirmButton: "OK"
                });
                return;
            }

            ajaxPostRequest("/PhoneBookService.svc/AddContact",
                {
                    contact: {
                        name: self.name(),
                        surname: self.surname(),
                        phone: self.phone()
                    }
                }).always(function () { self.refreshTable(); });

            if (isFiltered) {
                self.executeFilter();
            }

            self.name("");
            self.surname("");
            self.phone("");
            self.needValidate(false);
        };

        self.removeTableItem = function(item) {
            var rows = _.filter(self.tableItems(),
                function(item) {
                    return item.isChecked() === true;
                });
            var messageString = "следующие контакты? <br />";
            messageString += _.pluck(rows, "itemSurname").join("<br />");
            if (rows.length === 0) {
                rows.push(item);
                messageString = "контакт: " + item.itemSurname + " ?";
            }
            $.confirm({
                title: "Подтверждение удаления",
                content: "Вы действительно хотите удалить " + messageString,
                confirmButton: "OK",
                cancelButton: "Отмена",
                confirm: function () {
                    var array = _.map(rows, function(r) { return r.itemId });
                    ajaxPostRequest("/PhoneBookService.svc/RemoveContact", { ids: array}).always(function() { self.refreshTable() });
                }
            });
        };

        self.executeFilter = function() {
            self.refreshTable();
            isFiltered = true;
        };

        self.cancelFilter = function () {
            self.filterText("");
            self.refreshTable();
            isFiltered = false;
        }
    }

    function TableItemViewModel(name, surname, phone, id) {
        var self = this;

        self.itemId = id;
        self.itemName = name;
        self.itemSurname = surname;
        self.itemPhone = phone;

        self.isChecked = ko.observable(false);
    }

    function ajaxPostRequest(url, data) {
        return $.ajax({
            url: url,
            data: JSON.stringify(data),
            dataType: "json",
            method: "POST",
            processData: false,
            contentType: "application/json"
        });
    }
})($, ko, _)