<%@ Page Title="Телефонная книга" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PhoneBook._Default" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="main container">
        <div class="form-inline">
            <div class="form-group">
               <label>
                    Фильтр: <input class="text-filter form-control" type="text" data-bind="value: filterText"/>
                </label>
            </div>
            <button class="btn btn-default button-filter-ok" data-bind="click: executeFilter">Применить</button>
            <button class="btn btn-default button-filter-clear" data-bind="click: cancelFilter">Очистить</button>
            <a class="button-excel btn btn-default" data-bind="attr: { href: url }" target="_blank">Excel</a>
        </div>
        <div class="table-responsive">
            <table class="table table-striped table-condensed table-phone-book">
                <thead>
                <tr>
                    <th class="first-column"><input class="top-checkbox" type="checkbox"
                                                    data-bind="checked: isTopChecked" title="Выделить все"/></th>
                    <th class="second-column">№</th>
                    <th class="third-column cursor-pointer" data-bind="click: sortTable('surname')" 
                        title="Нажмите, чтобы отсортировать таблицу по этому полю">Фамилия</th>
                    <th class="fourth-column cursor-pointer" data-bind="click: sortTable('name')" 
                        title="Нажмите, чтобы отсортировать таблицу по этому полю">Имя</th>
                    <th class="fifth-column cursor-pointer" data-bind="click: sortTable('phone')" 
                        title="Нажмите, чтобы отсортировать таблицу по этому полю">Номер телефона</th>
                    <th class="sixth-column">Удалить</th>
                </tr>
                </thead>
                <tbody data-bind="foreach: tableItems">
                <tr>
                    <td class="first-column"><input type="checkbox" title="Выделить"
                                                    data-bind="checked: isChecked"/></td>
                    <td class="second-column" data-bind="text: ($index() + 1)"></td>
                    <td class="third-column" data-bind="text: itemSurname"></td>
                    <td class="fourth-column" data-bind="text: itemName"></td>
                    <td class="fifth-column" data-bind="text: itemPhone"></td>
                    <td class="sixth-column" data-bind="click: $parent.removeTableItem">
                        <button type='button' class='btn btn-default'>
                            <span class='glyphicon glyphicon-remove-sign' aria-hidden='true'></span></button>
                    </td>
                </tr>
                </tbody>
            </table>
        </div>
        <nav>
            <ul class="pager">
                <li data-bind="css: { 'disabled': numberOfPage() === 1 }">
                    <a data-bind="click: getPrevPage" class="btn btn-default">Предыдущая</a>
                </li>
                <li data-bind="css: { 'disabled': numberOfPage() === Math.ceil(countOfContacts() / sizeOfPage())}">
                    <a data-bind="click: getNextPage" class="btn btn-default">Следующая</a>
                </li>
            </ul>
        </nav>
        <h1>Заполнение телефонной книги</h1>
        <form class="form-horizontal">
            <div class="form-inline bottom-input" data-bind="css: {'has-error': surname() === ''
                && needValidate() === true}">
                <label for="surname" class="col-sm-2 control-label">Фамилия:</label>
                <div class="col-sm">
                    <input class="input-phone-book form-control" type="text" placeholder="Фамилия" title="Фамилия"
                           id="surname" autocomplete="off" data-bind="value: surname"/><br/>
                </div>
            </div>
            <div class="form-inline bottom-input" data-bind="css: {'has-error': name() === ''
                && needValidate() === true}">
                <label for="name" class="col-sm-2 control-label">Имя:</label>
                <div class="col-sm">
                    <input class="input-phone-book form-control" type="text" placeholder="Имя" title="Имя" id="name"
                           autocomplete="off" data-bind="value: name"/><br/>
                </div>
            </div>
            <div class="form-inline bottom-input" data-bind="css: {'has-error': phone() === ''
                && needValidate() === true}">
                <label for="phone" class="col-sm-2 control-label">Телефон:</label>
                <div class="col-sm">
                    <input class="input-phone-book form-control" type="tel" placeholder="8-XXX-XXX-XXXX"
                           title="Номер телефона" id="phone" autocomplete="off" data-bind="value: phone"/><br/>
                </div>
            </div>
            <div class="form-inline">
                <div class="col-sm-offset-2 col-sm">
                    <input type="submit" class="btn btn-default submit" data-bind="click: addTableItem"
                           value="Добавить"/>
                </div>
            </div>
        </form>
    </div>
</asp:Content>
