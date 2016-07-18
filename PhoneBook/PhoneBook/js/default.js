(function ($, ko, _) {
    window.SortCommand = {
        Name: 0,
        Surname: 1,
        Phone: 2
    };

    $(document).ready(function() {
        var vm = new PhoneBookViewModel();
        ko.applyBindings(vm, document.getElementById("main-container"));
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
        self.countOfContacts = ko.observable(0);
        self.sizeOfPage = ko.observable(5);
        self.numberOfPage = ko.observable(1);
        self.sortCommand = ko.observable(SortCommand.Surname);
        self.isSortedDesc = ko.observable(false);

        self.urlForExcel = ko.computed(function() {
            return "/PhoneBookService.svc/Excel?filter=" + self.filterText() + "&sortCommand=" + self.sortCommand() +
                "&isSortedDesc=" + self.isSortedDesc();
        });
        self.countOfContactsText = ko.computed(function() {
            return "Число контактов: " + self.countOfContacts();
        });
        self.isDasabledNextPageButton = ko.computed(function () {
            return self.numberOfPage() === Math.ceil(self.countOfContacts() / self.sizeOfPage())
        });

        self.isTopChecked.subscribe(function(newValue) {
            _.each(self.tableItems(), function(item) {
                item.isChecked(newValue);
            });

        });

        self.refreshTable = function() {
            ajaxPostRequest("/PhoneBookService.svc/GetContacts", {
                requestData: {
                    filter: self.filterText(),
                    sizeOfPage: self.sizeOfPage(),
                    numberOfPage: self.numberOfPage(),
                    sortCommand: self.sortCommand(),
                    isSortedDesc: self.isSortedDesc()
                }
            }).done(function(data) {
                var tmpList = _.map(data.contactsList, function(contact) {
                    return new TableItemViewModel(contact.name, contact.surname, contact.phone, contact.id);
                });
                self.tableItems(tmpList);
                self.countOfContacts(data.countOfContacts);
            });
        };

        self.addTableItem = function() {
            self.needValidate(true);

            if (self.surname() === "" || self.name() === "" || self.phone() === "") {
                showAlert("Заполните выделенные поля");
                return;
            }

            ajaxPostRequest("/PhoneBookService.svc/AddContact", {
                contact: {
                    name: self.name(),
                    surname: self.surname(),
                    phone: self.phone()
                }
            }).done(function (baseResponse) {
                if (baseResponse.success === false) {
                    showAlert(baseResponse.message);
                    return;
                }
                self.refreshTable();
            });

            self.name("");
            self.surname("");
            self.phone("");
            self.needValidate(false);
        };

        self.removeTableItem = function(item) {
            var rows = _.filter(self.tableItems(), function(item) {
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
                    var array = _.map(rows, function(r) {
                        return r.itemId;
                    });
                    ajaxPostRequest("/PhoneBookService.svc/RemoveContacts ", {
                        ids: array
                    }).done(function () {
                        self.numberOfPage(1);
                        self.refreshTable();
                    });
                }
            });
        };

        self.executeFilter = function () {
            self.numberOfPage(1);
            self.refreshTable();
        };

        self.cancelFilter = function() {
            self.filterText("");
            self.executeFilter();
        };

        self.sortList = function(sortCommand) {
            if (self.sortCommand() === sortCommand) {
                self.isSortedDesc(!self.isSortedDesc());
            } else {
                self.isSortedDesc(false);
            }
            self.sortCommand(sortCommand);
            self.numberOfPage(1);
            self.refreshTable();
        };

        self.getNextPage = function() {
            self.numberOfPage(self.numberOfPage() + 1);
            self.refreshTable();
        };

        self.getPrevPage = function() {
            self.numberOfPage(self.numberOfPage() - 1);
            self.refreshTable();
        };
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

    function showAlert(message) {
        $.alert({
            title: "Ошибка заполнения",
            content: message,
            confirmButton: "OK"
        });
    }
})($, ko, _)