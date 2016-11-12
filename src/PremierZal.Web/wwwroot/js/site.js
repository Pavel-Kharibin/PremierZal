"use strict";

// ReSharper disable FunctionsUsedBeforeDeclared

(function($) {
    $.fn.editorTable = function(params) {
        const defaults = {
            apiUrl: "",
            validate: function ($row) {
                var hasErrors = false;

                $row.find("input[required]").each(function () {
                    if ($(this).val().trim() === "") {
                        $(this).parent().addClass("has-error");
                        hasErrors = true;
                    } else {
                        $(this).parent().removeClass("has-error");
                    }
                });

                return !hasErrors;
            },
            add: {
                before: function() { return true; },
                after: function() {}
            },
            save: {
                before: function() { return true; },
                after: function() {}
            },
            delete: {
                confirm: "Вы действительно хотите удалить данную запись?",
                before: function() { return true; },
                after: function() {}
            },
            onInitEdior: function () { },
            onCloseEditor: function() {}
        };
        const options = $.extend(true, {}, defaults, params);
        
        this.find("tr[data-id]").each(function() {
            const $row = $(this);

            $(this).on("click", ".btn-edit", function() {
                showEditor($row);
            });
            $(this).on("click", ".btn-save", function() {
                saveRow($row);
            });
            $(this).on("click", ".btn-cancel", function() {
                hideEditor($row);
            });
            $(this).on("click", ".btn-delete", function() {
                deleteRow($row);
            });
        });

        function showEditor($row) {
            $row.find(".btn-edit, .btn-delete").hide();
            $row.find(".btn-save, .btn-cancel").show();

            $row.find("span:not(.glyphicon):not([data-ignore=1])").each(function() {
                $(this).hide();
                
                const $td = $(this).parent();
                const $input = $("<input class='form-control' type='text'>");

                $input.attr("name", $(this).attr("data-name")).val($(this).text());

                if ($(this).attr("data-required")) $input.attr("required", "required");
                if ($(this).attr("data-readonly")) $input.attr("readonly", "readonly");

                $td.append($input);
            });

            options.onInitEdior($row);
        }

        function hideEditor($row) {
            $row.find(".btn-edit, .btn-delete").show();
            $row.find(".btn-save, .btn-cancel").hide();

            $row.find("span:not(.glyphicon)").show();

            $row.find("input").each(function () {
                $(this).remove();
            });

            $row.find("td").removeClass("has-error");


            options.onCloseEditor($row);
        }

        function saveRow($row) {
            if (!options.save.before($row) || !options.validate($row)) return;

            const item = { id: getId($row) };
            $row.find("input").each(function() {
                item[$(this).attr("name")] = $(this).val();
            });

            disableRow($row);
            $.ajax({
                url: options.apiUrl,
                type: "PUT",
                dataType: "json",
                data: item,
                success: function (data, textStatus, jqXhr) {
                    updateRow($row, item);
                    hideEditor();
                    options.save.after();
                },
                error: function (jqXhr, textStatus, error) {
                    alert(error);
                },
                complete: function() {
                    disableRow($row, false);
                }
            });
        }

        function deleteRow($row) {
            const id = getId($row);

            if (id === 0) {
                $row.remove();
                return;
            }

            if (options.delete.confirm && !confirm(options.delete.confirm) || !options.delete.before($row)) return;

            $.ajax({
                url: `${options.apiUrl}${id}`,
                type: "DELETE",
                dataType: "json",
                success: function(data, textStatus, jqXhr) {
                    $row.remove();
                    options.delete.after();
                },
                error: function(jqXhr, textStatus, error) {
                    alert(error);
                }
            });
        }

        function getId($row) {
            return parseInt($row.attr("data-id"));
        }

        function disableRow($row, disable = true) {
            if (disable)
                $row.find("input, button").attr("disabled", "disabled");
            else
                $row.find("input, button").removeAttr("disabled");
        }

        function updateRow($row, item) {
            console.log(item);
            for (let key in item) {
                if (item.hasOwnProperty(key)) {
                    $row.find(`span[data-name='${key}']`).text(item[key]);
                }
            }
        }

        return this;
    };
}(jQuery));