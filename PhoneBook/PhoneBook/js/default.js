(function($, ko, _) {
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
        self.countOfContacts = ko.observable(0);
        self.sizeOfPage = ko.observable(5);
        self.numberOfPage = ko.observable(1);
        self.url = ko.computed(function() {
            return "/PhoneBookService.svc/Excel?filter=" + self.filterText();
        });  

        self.isTopChecked.subscribe(function(newValue) {
            _.each(self.tableItems(), function(item) {
                item.isChecked(newValue);
            });
        });

        self.refreshTable = function () {
            self.tableItems.removeAll();
            ajaxPostRequest("/PhoneBookService.svc/GetContacts", {
                filter: self.filterText(),
                sizeOfPage: self.sizeOfPage(),
                numberOfPage: self.numberOfPage()
            }).done(function (data) {
                _.each(data.contactsList, function (contact) {
                    var addedItem = new TableItemViewModel(contact.name, contact.surname, contact.phone, contact.id);
                    self.tableItems.push(addedItem);
                });
                self.countOfContacts(data.countOfContacts)
            });
        }

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
                    ajaxPostRequest("/PhoneBookService.svc/RemoveContacts ", {
                        ids: array
                    }).done(function() {
                        self.refreshTable();
                    });
                }
            });
        };

        self.executeFilter = function () {
            self.numberOfPage(1);
            self.refreshTable();
        };

        self.cancelFilter = function () {
            self.filterText("");
            self.numberOfPage(1);
            self.refreshTable();
        }

        self.sortTable = function(column) {
            self.tableItems.sort(function (a, b) {
                var v1 = null;
                var v2 = null;
                if (column === "name") {
                    v1 = a.itemName.toString();
                    v2 = b.itemName.toString();
                }
                if (column === "surname") {
                    v1 = a.itemSurname.toString().toLowerCase();
                    v2 = b.itemSurname.toString().toLowerCase();
                }
                if (column === "phone") {
                    v1 = a.itemPhone;
                    v2 = b.itemPhone;
                }
                return v1 < v2 ? -1 : 1;
            });
        }

        self.getNextPage = function () {
            self.numberOfPage(self.numberOfPage() + 1);
            self.refreshTable();
        }

        self.getPrevPage = function () {
            self.numberOfPage(self.numberOfPage() - 1);
            self.refreshTable();
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

    function showAlert(message) {
        $.alert({
            title: "Ошибка заполнения",
            content: message,
            confirmButton: "OK"
        });
    }
})($, ko, _)