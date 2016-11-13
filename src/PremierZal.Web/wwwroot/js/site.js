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
        const $this = this;

        $this.on("click", ".btn-edit", function() {
            const $row = $(this).closest("tr[data-id]");
            showEditor($row);
        });
        $this.on("click", ".btn-save", function() {
            const $row = $(this).closest("tr[data-id]");
            saveRow($row);
        });
        $this.on("click", ".btn-cancel", function() {
            const $row = $(this).closest("tr[data-id]");
            hideEditor($row);
        });
        $this.on("click", ".btn-delete", function() {
            const $row = $(this).closest("tr[data-id]");
            deleteRow($row);
        });
        $this.find(".btn-add").on("click", function() {
            addNewRow($(this));
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
                if ($(this).attr("data-placeholder")) $input.attr("placeholder", $(this).attr("data-placeholder"));
                if ($(this).attr("data-readonly")) $input.attr("readonly", "readonly");

                $td.append($input);
            });

            options.onInitEdior($row);
        }

        function hideEditor($row) {
            if (getId($row) === 0) {
                $row.remove();
                return;
            }

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
                type: item.id === 0 ? "POST" : "PUT",
                dataType: "json",
                data: item,
                success: function(data, textStatus, jqXhr) {
                    item.id = item.id === 0 ? data.id : item.id;
                    
                    updateRow($row, item);
                    hideEditor($row);
                    
                    options.save.after();
                },
                error: function(jqXhr, textStatus, error) {
                    alert(error);
                },
                complete: function() {
                    disableRow($row, false);
                }
            });
        }

        function deleteRow($row) {
            if (options.delete.confirm && !confirm(options.delete.confirm) || !options.delete.before($row)) return;
            
            disableRow($row);

            $.ajax({
                url: `${options.apiUrl}${getId($row)}`,
                type: "DELETE",
                success: function(data, textStatus, jqXhr) {
                    $row.remove();
                    options.delete.after();
                },
                error: function(jqXhr, textStatus, error) {
                    alert(error);
                    disableRow($row, false);
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
            $row.attr("data-id", item.id);
            for (let key in item) {
                if (item.hasOwnProperty(key)) {
                    $row.find(`span[data-name='${key}']`).text(item[key]);
                }
            }
        }

        function addNewRow($btn) {
            $btn.button("loading");
            $.ajax({
                url: "/home/newrow",
                dataType: "html",
                success: function(data, textStatus, jqXhr) {
                    $this.find("tbody").append(data);
                    showEditor($this.find("tr[data-id='0']").last());
                },
                error: function(jqXhr, textStatus, error) {
                    alert(error);
                },
                complete: function() {
                    $btn.button("reset");
                }
            });
        }

        return this;
    };
}(jQuery));