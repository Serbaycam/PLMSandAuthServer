//-kullanım--   onclick="displayInPopup('@Url.Action("_GetAdressDetails","Uretim",new {depoadres = item.depoAdres })',title='Adres: '+ this.value)" value="@item.depoAdres" data-bs-toggle="modal" data-bs-target="#popupModal" --//
function displayInPopup(url, title) {
    $.ajax({
        type: "GET",
        url: url,
        contentType: 'application/html; charset=utf-8',
        dataType: 'html',
        success: function (data) {
            $('#popupTitle').html(title);
            $('#popupContent').html(data);
            $('#popupModal').modal({ backdrop: 'static', keyboard: false, show: true });
        }
    });
};
function displayInPopup2(url, title) {
    $.ajax({
        type: "GET",
        url: url,
        contentType: 'application/html; charset=utf-8',
        dataType: 'html',
        success: function (data) {
            $('#popupTitle2').html(title);
            $('#popupContent2').html(data);
            $('#popupModal2').modal({ backdrop: 'static', keyboard: false, show: true });
        }
    });
};
function displayInPopup3(url, title) {
    $.ajax({
        type: "GET",
        url: url,
        contentType: 'application/html; charset=utf-8',
        dataType: 'html',
        success: function (data) {
            $('#popupTitle3').html(title);
            $('#popupContent3').html(data);
            $('#popupModal3').modal({ backdrop: 'static', keyboard: false, show: true });
        }
    });
};
async function DataTableJS(id, title) {
    var table = document.getElementById(id);

    // DataTables configuration
    const [buttonConfig, languageConfig] = await Promise.all([
        fetchJson("../js/DataTableSettings.Buttons.json"),
        fetchJson("../js/DataTableSettings.Language.json")
    ]);

    $(table).DataTable({
        responsive: true,
        autoWidth: true,
        colReorder: true,
        pageLength: 5,
        dom: "<'row' <'col-sm-4'B> <'col-sm-4'<'toolbar'>> <'col-sm-4'f> >" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        buttons: buttonConfig,
        language: languageConfig,
        fnInitComplete: function () {
            $('div.toolbar').html(`<h2 class="fw-bolder text-center">${title}</h2>`);
        },
    });

    async function fetchJson(url) {
        const response = await fetch(url);
        return response.json();
    }
};
$(document).ready(function () {
    (async function () {
        const buttonConfig = await fetchJson("../js/DataTableSettings.Buttons.json");
        const languageConfig = await fetchJson("../js/DataTableSettings.Language.json");

        $('.dataTableJS').DataTable({
            responsive: true,
            autoWidth: true,
            colReorder: true,
            pageLength: 5,
            dom: "<'row'<'col-md-6'B><'col-md-6'f>>" +
                "<'row'<'col-sm-12'tr>>" +
                "<'row'<'col-md-5'i><'col-md-7'p>>",
            buttons: buttonConfig,
            language: languageConfig,
        });
    })();

    async function fetchJson(url) {
        const response = await fetch(url);
        return response.json();
    }
});
//-kullanımı  onkeypress="return isNumberKey(event)"   -//
function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;
    return true;
}
//-kullanımı  onkeypress="return isStringKey(event)"   -//
function isStringKey(evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode      
    if (((charCode <= 93 && charCode >= 65) || (charCode <= 122 && charCode >= 97) || charCode == 8) || charCode == 350 || charCode == 351 || charCode == 304 || charCode == 286 || charCode == 287 || charCode == 231 || charCode == 199 || charCode == 305 || charCode == 214 || charCode == 246 || charCode == 220 || charCode == 252 || charCode == 32) {      
        return true;       
    }
    return false;   
}

//#region GetPartialView
//-Get Partial View-//
//--  onsubmit = "return getPartialView(this,'divid');"  --//

function getPartialView(form, id) {
    var partialDiv = document.getElementById(id);
    try {
        $.ajax({
            beforeSend: function () {
                $('#loader').removeClass('hidden')
            },
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                $(partialDiv).html(res.html);
            },
            error: function (err) {
                console.log(err)
            },
            complete: function () {
                $('#loader').addClass('hidden')
            },
        })
    } catch (ex) {
        console.log(ex)
    }
    return false;
}
function askBeforeAdd(form, id) {
    var partialDiv = document.getElementById(id);
    swal({
        title: "Ekleme İşlemini Onaylıyor Musunuz ?",
        text: "Bu işlem Geri Alınamaz!",
        icon: "warning",
        buttons: true,
        dangerMode: false,
        buttons: {
            cancel: true,
            confirm: "Onayla",
            cancel: "İptal"
        }
    })
        .then((willDelete) => {
            if (willDelete) {
                try {
                    $(partialDiv).empty;
                    $.ajax({
                        beforeSend: function () {
                            //$('#loader').removeClass('hidden')
                        },
                        type: 'POST',
                        url: form.action,
                        data: new FormData(form),
                        contentType: false,
                        processData: false,
                        success: function (res) {
                            $(partialDiv).html(res.html);

                        },
                        error: function (err) {
                            console.log(err)
                        },
                        complete: function () {
                        },
                    })
                } catch (ex) {
                    console.log(ex)
                }
                swal("İşlem Başarıyla Gerçekleştirildi", {
                    icon: "success",
                });
            } else {
                swal("İşlem İptal Edildi");
            }
        });
    return false;
}
function askBeforeDelete(form, id) {
    var partialDiv = document.getElementById(id);
    swal({
        title: "Silme İşlemini Onaylıyor Musunuz ?",
        text: "Bu işlem Geri Alınamaz!",
        icon: "warning",
        buttons: true,
        dangerMode: false,
        buttons: {
            cancel: true,
            confirm: "Onayla",
            cancel: "İptal"
        }
    })
        .then((willDelete) => {
            if (willDelete) {
                try {
                    $(partialDiv).empty;
                    $.ajax({
                        beforeSend: function () {
                        },
                        type: 'POST',
                        url: form.action,
                        data: new FormData(form),
                        contentType: false,
                        processData: false,
                        success: function (res) {
                            $(partialDiv).html(res.html);
                        },
                        error: function (err) {
                            console.log(err)
                        },
                        complete: function () {
                        },
                    })
                } catch (ex) {
                    console.log(ex)
                }
                swal("İşlem Başarıyla Gerçekleştirildi", {
                    icon: "success",
                });
            } else {
                swal("İşlem İptal Edildi");
            }
        });
    return false;
}
$(document).ready(function () {
    VirtualSelect.init({
        ele: '.virtualMultiple',
        multiple: true, search: true,
        /*   required: true,*/
        selectAllOnlyVisible: true,
        /*hideValueTooltipOnSelectAll: true,*/
    });
    VirtualSelect.init({
        ele: '.virtualSingle',
        multiple: false, search: true,
        /*   required: true,*/
        selectAllOnlyVisible: true,
        /*hideValueTooltipOnSelectAll: true,*/
    });
});
//data-dropdown-css-class="select2-info"
$(document).ready(function () {
    $('.customSelect2').select2({
        placeholder: "Seçiniz",
        allowClear: false,
        focus: false,
        closeOnSelect: true,
        dropdownCssClass: 'select2-info',
        multiple:false,

    })
});
function OpenModalWithFormSubmit(form, id, title) {
    var myModal = new bootstrap.Modal(document.getElementById(id), {
        keyboard: false
    });
    swal({
        title: "Pop-up Açılsın mı ?",
        text: "Seçili işlemi göndermek üzeresiniz!",
        icon: "warning",
        buttons: true,
        dangerMode: false,
        buttons: {
            cancel: true,
            confirm: "Onayla",
            cancel: "İptal"
        }
    })
        .then((willDelete) => {
            if (willDelete) {
                try {
                    $.ajax({
                        beforeSend: function () {
                            $('#loader').removeClass('hidden')
                        },
                        type: 'POST',
                        url: form.action,
                        data: new FormData(form),
                        contentType: false,
                        processData: false,
                        success: function (res) {
                            myModal.toggle();
                            $('#customModal .modal-body').html(res.html);
                            $('#customModal #popupTitle').html(title);
                            $('#customModal').removeClass('hide');
                            $('#loader').addClass('hidden');
                        },
                        error: function (err) {
                            $('#loader').addClass('hidden');
                            console.log(err);
                        },
                        complete: function () {
                            $('#loader').addClass('hidden');
                        },
                    })
                } catch (ex) {
                    console.log(ex)
                }
            } else {
                swal("İşlem İptal Edildi");
            }
        });
    return false;
}