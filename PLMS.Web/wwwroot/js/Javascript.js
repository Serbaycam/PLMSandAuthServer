function displayInPopup(url, title, modalNumber) {
    $.ajax({
        type: "GET",
        url: url,
        contentType: 'application/html; charset=utf-8',
        dataType: 'html',
        success: function (data) {
            updateModalContent(modalNumber, title, data);
        }
    });
}

function updateModalContent(modalNumber, title, content) {
    $(`#popupTitle${modalNumber}`).html(title);
    $(`#popupContent${modalNumber}`).html(content);
    $(`#popupModal${modalNumber}`).modal({ backdrop: 'static', keyboard: false, show: true });
}

async function fetchJson(url) {
    const response = await fetch(url);
    return response.json();
}

async function DataTableJS(id, title) {
    var table = document.getElementById(id);

    const [buttonConfig, languageConfig, domConfig] = await Promise.all([
        fetchJson("../../js/DataTableSettings.Buttons.json"),
        fetchJson("../../js/DataTableSettings.Language.json"),
        fetchJson("../../js/DataTableSettings.Dom.json")
    ]);

    $(table).DataTable({
        responsive: true,
        autoWidth: true,
        colReorder: true,
        pageLength: 5,
        dom: domConfig,
        buttons: buttonConfig,
        language: languageConfig,
        fnInitComplete: function () {
            $('div.toolbar').html(`<h2 class="fw-bolder text-center">${title}</h2>`);
        },
    });
}
$(document).ready(async function () {
    const dataTableElement = $('.dataTableJSC');
    dataTableElement.on('dblclick', 'tbody tr', function (e) {
        e.currentTarget.classList.toggle('selected');
    });
    $('.dataTableJSC thead tr')
        .clone(true)
        .addClass('filters')
        .removeClass('bg-secondary')
        .appendTo('.dataTableJSC thead');
    const filtersTh = $('.filters th');

    if (dataTableElement.length > 0) {
        const [buttonConfig, languageConfig, domConfig] = await Promise.all([
            fetchJson("../../js/DataTableSettings.Buttons.json"),
            fetchJson("../../js/DataTableSettings.Language.json"),
            fetchJson("../../js/DataTableSettings.Dom.json")
        ]);

        dataTableElement.DataTable({
            orderCellsTop: true,
            fixedHeader: true,
            responsive: true,
            autoWidth: true,
            colReorder: true,
            pageLength: 5,
            dom: domConfig,
            buttons: buttonConfig,
            language: languageConfig,
            initComplete: function () {
                var api = this.api();

                api.columns().eq(0).each(function (colIdx) {
                    var cell = filtersTh.eq(api.column(colIdx).index());
                    var title = cell.text();
                    cell.html(`<input class="form-control small" style="width:100px;" type="text" placeholder="${title}" />`);

                    var input = $('input', cell);

                    input.on('change', function () {
                        $(this).attr('title', $(this).val());
                        var regexr = '({search})';
                        api.column(colIdx).search(this.value !== '' ? regexr.replace('{search}', `(((${this.value})))`) : '', this.value !== '', this.value === '').draw();
                    }).on('keyup', function (e) {
                        e.stopPropagation();
                        $(this).trigger('change').focus()[0].setSelectionRange(this.selectionStart, this.selectionStart);
                    });
                });
            },
        });
    }
});
$(document).ready(function () {
    const dataTableElement = $('.dataTableJS');

    if (dataTableElement[0]) {
        (async function () {
            const [buttonConfig, languageConfig,domConfig] = await Promise.all([
                fetchJson("../../js/DataTableSettings.Buttons.json"),
                fetchJson("../../js/DataTableSettings.Language.json"),
                fetchJson("../../js/DataTableSettings.Dom.json")
            ]);

            dataTableElement.DataTable({
                responsive: true,
                autoWidth: true,
                colReorder: true,
                pageLength: 5,
                dom: domConfig,
                buttons: buttonConfig,
                language: languageConfig,
            });
        })();
    }

    if ($('.virtualMultiple')[0]) {
        VirtualSelect.init({
            ele: '.virtualMultiple',
            multiple: true,
            search: true,
        });
    }

    if ($('.virtualSingle')[0]) {
        VirtualSelect.init({
            ele: '.virtualSingle',
            multiple: false,
            search: true,
        });
    }

    if ($('.customSelect2')[0]) {
        $('.customSelect2').select2({
            placeholder: "Seçiniz",
            allowClear: false,
            focus: false,
            closeOnSelect: true,
            dropdownCssClass: 'select2-info',
            multiple: false,
        });
    }
});

function OpenModalWithFormSubmit(form, id, title) {
    var myModal = new bootstrap.Modal(document.getElementById(id), {
        keyboard: false
    });

    Swal.fire({
        title: "Pop-up Açılsın mı?",
        text: "Seçili işlemi göndermek üzeresiniz!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "Onayla",
        cancelButtonText: "İptal",
    })
        .then((result) => {
            if (result.isConfirmed) {
                $('#loader').removeClass('hidden');

                $.ajax({
                    type: 'POST',
                    url: form.action,
                    data: new FormData(form),
                    contentType: false,
                    processData: false,
                })
                    .then(function (res) {
                        myModal.toggle();
                        $('#customModal .modal-body').html(res.html);
                        $('#customModal #popupTitle').html(title);
                        $('#customModal').removeClass('hide');
                    })
                    .catch(function (err) {
                        console.error(err);
                    })
                    .finally(function () {
                        $('#loader').addClass('hidden');
                    });
            } else {
                Swal.fire("İşlem İptal Edildi");
            }
        });

    return false;
}

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    return !(charCode > 31 && (charCode < 48 || charCode > 57));
}

function isStringKey(evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode
    return ((charCode <= 93 && charCode >= 65) || (charCode <= 122 && charCode >= 97) || charCode == 8) || [350, 351, 304, 286, 287, 231, 199, 305, 214, 246, 220, 252, 32].includes(charCode);
}

function getPartialView(form, id) {
    var partialDiv = document.getElementById(id);

    $('#loader').removeClass('hidden');

    $.ajax({
        type: 'POST',
        url: form.action,
        data: new FormData(form),
        contentType: false,
        processData: false,
    })
        .done(function (res) {
            $(partialDiv).html(res.html);
        })
        .fail(function (err) {
            console.error(err);
        })
        .always(function () {
            $('#loader').addClass('hidden');
        });

    return false;
}

function askBeforeAdd(form, id) {
    var partialDiv = document.getElementById(id);

    Swal.fire({
        title: "Ekleme İşlemini Onaylıyor Musunuz?",
        text: "Bu işlem Geri Alınamaz!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "Onayla",
        cancelButtonText: "İptal",
    })
        .then((result) => {
            if (result.isConfirmed) {
                $(partialDiv).empty();

                Swal.fire({
                    title: "İşlem Başarıyla Gerçekleştirildi",
                    icon: "success",
                });

                $.ajax({
                    type: 'POST',
                    url: form.action,
                    data: new FormData(form),
                    contentType: false,
                    processData: false,
                    success: function (res) {
                        $(partialDiv).html(res.html);
                    },
                    error: function (err) {
                        console.error(err);
                    },
                });
            } else {
                Swal.fire("İşlem İptal Edildi");
            }
        });

    return false;
}

function askBeforeDelete(form, id) {
    var partialDiv = document.getElementById(id);

    Swal.fire({
        title: "Silme İşlemini Onaylıyor Musunuz?",
        text: "Bu işlem Geri Alınamaz!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "Onayla",
        cancelButtonText: "İptal",
    })
        .then((result) => {
            if (result.isConfirmed) {
                $(partialDiv).empty();

                $.ajax({
                    type: 'POST',
                    url: form.action,
                    data: new FormData(form),
                    contentType: false,
                    processData: false,
                    success: function (res) {
                        $(partialDiv).html(res.html);
                    },
                    error: function (err) {
                        console.error(err);
                    },
                });

                Swal.fire("İşlem Başarıyla Gerçekleştirildi", {
                    icon: "success",
                });
            } else {
                Swal.fire("İşlem İptal Edildi");
            }
        });

    return false;
}
