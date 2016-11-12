"use strict";

$(document).ready(function() {
    $("#list").editorTable({
        apiUrl: "/api/sessions/",
        delete: {
            confirm: "Вы действительно хотите удалить данный сеанс?"
        },
        onInitEdior: function($row) {
            const $dateTime = $row.find("input[name='begins']");
            $dateTime.wrap("<div class='picker-wrapper'/>"); // datetimepicker needs this.
            $dateTime.datetimepicker({
                format: "DD.MM.YYYY HH:mm:ss",
                showTodayButton: true,
                ignoreReadonly: true,
                sideBySide: true,
                locale: "ru"
            });
        },
        onCloseEditor: function($row) {
            $row.find(".picker-wrapper").remove();
        }
    });
});