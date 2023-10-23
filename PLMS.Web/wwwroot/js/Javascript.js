//#region DisplayInPopUp Functions
//---------------KATMANLI MODAL YAPISI-------------------------------//

//-kullanım--   onclick="displayInPopup('@Url.Action("_GetAdressDetails","Uretim",new {depoadres = item.depoAdres })',title='Adres: '+ this.value)" value="@item.depoAdres" data-bs-toggle="modal" data-bs-target="#popupModal" --//

function displayAccountPopup(url) {

    $.ajax({
        type: "GET",
        url: url,
        contentType: 'application/html; charset=utf-8',
        dataType: 'html',
        success: function (data) {
            $('#accountModalContent').html(data);
            $('#accountModal').modal({ backdrop: 'static', keyboard: false, show: true });
        }
    });

};

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
//---------------KATMANLI MODAL YAPISI-------------------------------//
//#endregion

//#region Datatable Functions
//---------------DATATABLE-------------------------------//


//`
//<'row' <'col-sm-4'B> <'col-sm-4'<'toolbar'>> <'col-sm-4'f> >
//<'row'<'col-sm-12'tr>>
//<'row'<'col-sm-5'i><'col-sm-7'p>>
//<'row'<'#btn_custom.col-sm-6 col-lg-2'>>
//`
function DataTableJS(id, title) {
    var table = document.getElementById(id);
    $(table).DataTable({
        responsive: true,
        autoWidth: true,
        colReorder: true,
        pageLength: 5,
        dom: "<'row' <'col-sm-4'B> <'col-sm-4'<'toolbar'>> <'col-sm-4'f> >" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",

        buttons: [


            {
                extend: 'collection',
                text: 'Export',
                buttons: [
                    //'colvis',
                    //{
                    //    extend: 'colvis',
                    //    className: 'btn btn-secondary rounded',
                    //    text: 'Gizle/Göster'
                    //},
                    {
                        orientation: 'landscape',
                        pageSize: 'A4',
                        extend: 'excelHtml5',
                        text: '<i class="far fa-file-excel" data-toggle="tooltip" title="Export To Excel"></i> Excel',
                        className: 'btn btn-secondary rounded',
                        exportOptions: {
                            stripHtml: true
                        }
                    },
                    //{
                    //    orientation: 'landscape',
                    //    pageSize: 'A4',
                    //    extend: 'csvHtml5',
                    //    className: 'btn btn-secondary rounded',
                    //    text: '<i class="fas fa-file-csv" data-toggle="tooltip" title="Export To Csv"></i> Csv',
                    //    exportOptions: {
                    //        stripHtml: true
                    //    }
                    //},
                    {
                        extend: 'pdfHtml5',
                        text: '<i class="far fa-file-pdf" data-toggle="tooltip" title="Export To Pdf"></i> Pdf',
                        orientation: 'landscape',
                        className: 'btn btn-secondary rounded',
                        pageSize: 'A4'
                    },
                    //{
                    //    extend: 'print',
                    //    text: '<i class="fas fa-print" data-toggle="tooltip" title="Print"></i> Yazdır',
                    //    orientation: 'landscape',
                    //    className: 'btn btn-secondary rounded',
                    //    pageSize: 'A4'
                    //}

                ]
            }
        ],
        //language: {
        //    "emptyTable": "Tabloda herhangi bir veri mevcut değil",
        //    "info": "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor",
        //    "infoEmpty": "Kayıt yok",
        //    "infoFiltered": "(_MAX_ kayıt içerisinden bulunan)",
        //    "infoThousands": ".",
        //    "lengthMenu": "Sayfada _MENU_ kayıt göster",
        //    "loadingRecords": "Yükleniyor...",
        //    "processing": "İşleniyor...",
        //    "search": "Ara:",
        //    "zeroRecords": "Eşleşen kayıt bulunamadı",
        //    "paginate": {
        //        "first": "İlk",
        //        "last": "Son",
        //        "next": "Sonraki",
        //        "previous": "Önceki"
        //    },
        //    "aria": {
        //        "sortAscending": ": artan sütun sıralamasını aktifleştir",
        //        "sortDescending": ": azalan sütun sıralamasını aktifleştir"
        //    },
        //    "select": {
        //        "rows": {
        //            "_": "%d kayıt seçildi",
        //            "1": "1 kayıt seçildi"
        //        },
        //        "cells": {
        //            "1": "1 hücre seçildi",
        //            "_": "%d hücre seçildi"
        //        },
        //        "columns": {
        //            "1": "1 sütun seçildi",
        //            "_": "%d sütun seçildi"
        //        }
        //    },
        //    "autoFill": {
        //        "cancel": "İptal",
        //        "fillHorizontal": "Hücreleri yatay olarak doldur",
        //        "fillVertical": "Hücreleri dikey olarak doldur",
        //        "fill": "Bütün hücreleri <i>%d<\/i> ile doldur"
        //    },
        //    "buttons": {
        //        "collection": "Koleksiyon <span class=\"ui-button-icon-primary ui-icon ui-icon-triangle-1-s\"><\/span>",
        //        "colvis": "Sütun görünürlüğü",
        //        "colvisRestore": "Görünürlüğü eski haline getir",
        //        "copySuccess": {
        //            "1": "1 satır panoya kopyalandı",
        //            "_": "%ds satır panoya kopyalandı"
        //        },
        //        "copyTitle": "Panoya kopyala",
        //        "csv": "CSV",
        //        "excel": "Excel",
        //        "pageLength": {
        //            "-1": "Bütün satırları göster",
        //            "_": "%d satır göster"
        //        },
        //        "pdf": "PDF",
        //        "print": "Yazdır",
        //        "copy": "Kopyala",
        //        "copyKeys": "Tablodaki veriyi kopyalamak için CTRL veya u2318 + C tuşlarına basınız. İptal etmek için bu mesaja tıklayın veya escape tuşuna basın.",
        //        "createState": "Şuanki Görünümü Kaydet",
        //        "removeAllStates": "Tüm Görünümleri Sil",
        //        "removeState": "Aktif Görünümü Sil",
        //        "renameState": "Aktif Görünümün Adını Değiştir",
        //        "savedStates": "Kaydedilmiş Görünümler",
        //        "stateRestore": "Görünüm -&gt; %d",
        //        "updateState": "Aktif Görünümün Güncelle"
        //    },
        //    "searchBuilder": {
        //        "add": "Koşul Ekle",
        //        "button": {
        //            "0": "Arama Oluşturucu",
        //            "_": "Arama Oluşturucu (%d)"
        //        },
        //        "condition": "Koşul",
        //        "conditions": {
        //            "date": {
        //                "after": "Sonra",
        //                "before": "Önce",
        //                "between": "Arasında",
        //                "empty": "Boş",
        //                "equals": "Eşittir",
        //                "not": "Değildir",
        //                "notBetween": "Dışında",
        //                "notEmpty": "Dolu"
        //            },
        //            "number": {
        //                "between": "Arasında",
        //                "empty": "Boş",
        //                "equals": "Eşittir",
        //                "gt": "Büyüktür",
        //                "gte": "Büyük eşittir",
        //                "lt": "Küçüktür",
        //                "lte": "Küçük eşittir",
        //                "not": "Değildir",
        //                "notBetween": "Dışında",
        //                "notEmpty": "Dolu"
        //            },
        //            "string": {
        //                "contains": "İçerir",
        //                "empty": "Boş",
        //                "endsWith": "İle biter",
        //                "equals": "Eşittir",
        //                "not": "Değildir",
        //                "notEmpty": "Dolu",
        //                "startsWith": "İle başlar",
        //                "notContains": "İçermeyen",
        //                "notStartsWith": "Başlamayan",
        //                "notEndsWith": "Bitmeyen"
        //            },
        //            "array": {
        //                "contains": "İçerir",
        //                "empty": "Boş",
        //                "equals": "Eşittir",
        //                "not": "Değildir",
        //                "notEmpty": "Dolu",
        //                "without": "Hariç"
        //            }
        //        },
        //        "data": "Veri",
        //        "deleteTitle": "Filtreleme kuralını silin",
        //        "leftTitle": "Kriteri dışarı çıkart",
        //        "logicAnd": "ve",
        //        "logicOr": "veya",
        //        "rightTitle": "Kriteri içeri al",
        //        "title": {
        //            "0": "Arama Oluşturucu",
        //            "_": "Arama Oluşturucu (%d)"
        //        },
        //        "value": "Değer",
        //        "clearAll": "Filtreleri Temizle"
        //    },
        //    "searchPanes": {
        //        "clearMessage": "Hepsini Temizle",
        //        "collapse": {
        //            "0": "Arama Bölmesi",
        //            "_": "Arama Bölmesi (%d)"
        //        },
        //        "count": "{total}",
        //        "countFiltered": "{shown}\/{total}",
        //        "emptyPanes": "Arama Bölmesi yok",
        //        "loadMessage": "Arama Bölmeleri yükleniyor ...",
        //        "title": "Etkin filtreler - %d",
        //        "showMessage": "Tümünü Göster",
        //        "collapseMessage": "Tümünü Gizle"
        //    },
        //    "thousands": ".",
        //    "datetime": {
        //        "amPm": [
        //            "öö",
        //            "ös"
        //        ],
        //        "hours": "Saat",
        //        "minutes": "Dakika",
        //        "next": "Sonraki",
        //        "previous": "Önceki",
        //        "seconds": "Saniye",
        //        "unknown": "Bilinmeyen",
        //        "weekdays": {
        //            "6": "Paz",
        //            "5": "Cmt",
        //            "4": "Cum",
        //            "3": "Per",
        //            "2": "Çar",
        //            "1": "Sal",
        //            "0": "Pzt"
        //        },
        //        "months": {
        //            "9": "Ekim",
        //            "8": "Eylül",
        //            "7": "Ağustos",
        //            "6": "Temmuz",
        //            "5": "Haziran",
        //            "4": "Mayıs",
        //            "3": "Nisan",
        //            "2": "Mart",
        //            "11": "Aralık",
        //            "10": "Kasım",
        //            "1": "Şubat",
        //            "0": "Ocak"
        //        }
        //    },
        //    "decimal": ",",
        //    "editor": {
        //        "close": "Kapat",
        //        "create": {
        //            "button": "Yeni",
        //            "submit": "Kaydet",
        //            "title": "Yeni kayıt oluştur"
        //        },
        //        "edit": {
        //            "button": "Düzenle",
        //            "submit": "Güncelle",
        //            "title": "Kaydı düzenle"
        //        },
        //        "error": {
        //            "system": "Bir sistem hatası oluştu (Ayrıntılı bilgi)"
        //        },
        //        "multi": {
        //            "info": "Seçili kayıtlar bu alanda farklı değerler içeriyor. Seçili kayıtların hepsinde bu alana aynı değeri atamak için buraya tıklayın; aksi halde her kayıt bu alanda kendi değerini koruyacak.",
        //            "noMulti": "Bu alan bir grup olarak değil ancak tekil olarak düzenlenebilir.",
        //            "restore": "Değişiklikleri geri al",
        //            "title": "Çoklu değer"
        //        },
        //        "remove": {
        //            "button": "Sil",
        //            "confirm": {
        //                "_": "%d adet kaydı silmek istediğinize emin misiniz?",
        //                "1": "Bu kaydı silmek istediğinizden emin misiniz?"
        //            },
        //            "submit": "Sil",
        //            "title": "Kayıtları sil"
        //        }
        //    },
        //    "stateRestore": {
        //        "creationModal": {
        //            "button": "Kaydet",
        //            "columns": {
        //                "search": "Kolon Araması",
        //                "visible": "Kolon Görünümü"
        //            },
        //            "name": "Görünüm İsmi",
        //            "order": "Sıralama",
        //            "paging": "Sayfalama",
        //            "scroller": "Kaydırma (Scrool)",
        //            "search": "Arama",
        //            "searchBuilder": "Arama Oluşturucu",
        //            "select": "Seçimler",
        //            "title": "Yeni Görünüm Oluştur",
        //            "toggleLabel": "Kaydedilecek Olanlar"
        //        },
        //        "duplicateError": "Bu Görünüm Daha Önce Tanımlanmış",
        //        "emptyError": "Görünüm Boş Olamaz",
        //        "emptyStates": "Herhangi Bir Görünüm Yok",
        //        "removeJoiner": "ve",
        //        "removeSubmit": "Sil",
        //        "removeTitle": "Görünüm Sil",
        //        "renameButton": "Değiştir",
        //        "renameLabel": "Görünüme Yeni İsim Ver -&gt; %s:",
        //        "renameTitle": "Görünüm İsmini Değiştir",
        //        "removeConfirm": "Görünümü silmek istediğinize emin misiniz?",
        //        "removeError": "Görünüm silinemedi"
        //    }
        //},
        fnInitComplete: function () {
            $('div.toolbar').html(`<h2 class="fw-bolder text-center">${title}</h2>`);
        },
        //        "footerCallback": function (row, data, start, end, display) {
        //            var api = this.api(), data;

        //            // converting to interger to find total
        //            var intVal = function (i) {
        //                return typeof i === 'string' ?
        //                    i.replace(/[\$,]/g, '') * 1 :
        //                    typeof i === 'number' ?
        //                        i : 0;
        //            };

        //            // computing column Total of the complete result
        //            var Total = api
        //                .column(2)
        //                .data()
        //                .reduce(function (a, b) {
        //                    return intVal(a) + intVal(b);
        //                }, 0);
        //            $(api.column(1).footer()).html('Total');
        //            $(api.column(2).footer()).html(Total);
        //        },
    });
};

$(document).ready(function () {
    $('.dataTableJS').DataTable({
        responsive: true,
        autoWidth: true,
        colReorder: true,
        pageLength: 5,
        dom: "<'row'<'col-md-6'B><'col-md-6'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-md-5'i><'col-md-7'p>>",
        buttons: [


            {
                extend: 'collection',
                text: 'Export',
                className: 'btn bg-light text-black',
                buttons: [
                    {
                        orientation: 'landscape',
                        pageSize: 'A4',
                        extend: 'excelHtml5',
                        text: '<i class="far fa-file-excel" data-toggle="tooltip" title="Export To Excel"></i> Excel',
                        //className: 'btn btn-secondary rounded',
                        exportOptions: {
                            stripHtml: true
                        }
                    },
                    //{
                    //    orientation: 'landscape',
                    //    pageSize: 'A4',
                    //    extend: 'csvHtml5',
                    //    className: 'btn btn-secondary rounded',
                    //    text: '<i class="fas fa-file-csv" data-toggle="tooltip" title="Export To Csv"></i> Csv',
                    //    exportOptions: {
                    //        stripHtml: true
                    //    }
                    //},
                    {
                        extend: 'pdfHtml5',
                        text: '<i class="far fa-file-pdf" data-toggle="tooltip" title="Export To Pdf"></i> Pdf',
                        orientation: 'landscape',
                        //className: 'btn btn-secondary rounded',
                        pageSize: 'A4'
                    },
                    //{
                    //    extend: 'print',
                    //    text: '<i class="fas fa-print" data-toggle="tooltip" title="Print"></i> Yazdır',
                    //    orientation: 'landscape',
                    //    className: 'btn btn-secondary rounded',
                    //    pageSize: 'A4'
                    //}

                ]
            }
        ],
        //buttons: [

        //    {
        //        orientation: 'landscape',
        //        pageSize: 'A4',
        //        extend: 'excelHtml5',
        //        text: '<i class="far fa-file-excel" data-toggle="tooltip" title="Export To Excel"></i>',
        //        className: 'btn btn-secondary rounded',
        //        exportOptions: {
        //            stripHtml: true
        //        }
        //    },
        //    {
        //        orientation: 'landscape',
        //        pageSize: 'A4',
        //        extend: 'csvHtml5',
        //        className: 'btn btn-secondary ml-2 rounded',
        //        text: '<i class="fas fa-file-csv" data-toggle="tooltip" title="Export To Csv"></i>',
        //        exportOptions: {
        //            stripHtml: true
        //        }
        //    },
        //    {
        //        extend: 'pdfHtml5',
        //        text: '<i class="far fa-file-pdf" data-toggle="tooltip" title="Export To Pdf"></i>',
        //        orientation: 'landscape',
        //        className: 'btn btn-secondary ml-2 rounded',
        //        pageSize: 'A4'
        //    },
        //    {
        //        extend: 'print',
        //        text: '<i class="fas fa-print" data-toggle="tooltip" title="Print"></i>',
        //        orientation: 'landscape',
        //        className: 'btn btn-secondary ml-2 rounded',
        //        pageSize: 'A4'
        //    }
        //],
        //language: {
        //    "emptyTable": "Tabloda herhangi bir veri mevcut değil",
        //    "info": "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor",
        //    "infoEmpty": "Kayıt yok",
        //    "infoFiltered": "(_MAX_ kayıt içerisinden bulunan)",
        //    "infoThousands": ".",
        //    "lengthMenu": "Sayfada _MENU_ kayıt göster",
        //    "loadingRecords": "Yükleniyor...",
        //    "processing": "İşleniyor...",
        //    "search": "Ara:",
        //    "zeroRecords": "Eşleşen kayıt bulunamadı",
        //    "paginate": {
        //        "first": "İlk",
        //        "last": "Son",
        //        "next": "Sonraki",
        //        "previous": "Önceki"
        //    },
        //    "aria": {
        //        "sortAscending": ": artan sütun sıralamasını aktifleştir",
        //        "sortDescending": ": azalan sütun sıralamasını aktifleştir"
        //    },
        //    "select": {
        //        "rows": {
        //            "_": "%d kayıt seçildi",
        //            "1": "1 kayıt seçildi"
        //        },
        //        "cells": {
        //            "1": "1 hücre seçildi",
        //            "_": "%d hücre seçildi"
        //        },
        //        "columns": {
        //            "1": "1 sütun seçildi",
        //            "_": "%d sütun seçildi"
        //        }
        //    },
        //    "autoFill": {
        //        "cancel": "İptal",
        //        "fillHorizontal": "Hücreleri yatay olarak doldur",
        //        "fillVertical": "Hücreleri dikey olarak doldur",
        //        "fill": "Bütün hücreleri <i>%d<\/i> ile doldur"
        //    },
        //    "buttons": {
        //        "collection": "Koleksiyon <span class=\"ui-button-icon-primary ui-icon ui-icon-triangle-1-s\"><\/span>",
        //        "colvis": "Sütun görünürlüğü",
        //        "colvisRestore": "Görünürlüğü eski haline getir",
        //        "copySuccess": {
        //            "1": "1 satır panoya kopyalandı",
        //            "_": "%ds satır panoya kopyalandı"
        //        },
        //        "copyTitle": "Panoya kopyala",
        //        "csv": "CSV",
        //        "excel": "Excel",
        //        "pageLength": {
        //            "-1": "Bütün satırları göster",
        //            "_": "%d satır göster"
        //        },
        //        "pdf": "PDF",
        //        "print": "Yazdır",
        //        "copy": "Kopyala",
        //        "copyKeys": "Tablodaki veriyi kopyalamak için CTRL veya u2318 + C tuşlarına basınız. İptal etmek için bu mesaja tıklayın veya escape tuşuna basın.",
        //        "createState": "Şuanki Görünümü Kaydet",
        //        "removeAllStates": "Tüm Görünümleri Sil",
        //        "removeState": "Aktif Görünümü Sil",
        //        "renameState": "Aktif Görünümün Adını Değiştir",
        //        "savedStates": "Kaydedilmiş Görünümler",
        //        "stateRestore": "Görünüm -&gt; %d",
        //        "updateState": "Aktif Görünümün Güncelle"
        //    },
        //    "searchBuilder": {
        //        "add": "Koşul Ekle",
        //        "button": {
        //            "0": "Arama Oluşturucu",
        //            "_": "Arama Oluşturucu (%d)"
        //        },
        //        "condition": "Koşul",
        //        "conditions": {
        //            "date": {
        //                "after": "Sonra",
        //                "before": "Önce",
        //                "between": "Arasında",
        //                "empty": "Boş",
        //                "equals": "Eşittir",
        //                "not": "Değildir",
        //                "notBetween": "Dışında",
        //                "notEmpty": "Dolu"
        //            },
        //            "number": {
        //                "between": "Arasında",
        //                "empty": "Boş",
        //                "equals": "Eşittir",
        //                "gt": "Büyüktür",
        //                "gte": "Büyük eşittir",
        //                "lt": "Küçüktür",
        //                "lte": "Küçük eşittir",
        //                "not": "Değildir",
        //                "notBetween": "Dışında",
        //                "notEmpty": "Dolu"
        //            },
        //            "string": {
        //                "contains": "İçerir",
        //                "empty": "Boş",
        //                "endsWith": "İle biter",
        //                "equals": "Eşittir",
        //                "not": "Değildir",
        //                "notEmpty": "Dolu",
        //                "startsWith": "İle başlar",
        //                "notContains": "İçermeyen",
        //                "notStartsWith": "Başlamayan",
        //                "notEndsWith": "Bitmeyen"
        //            },
        //            "array": {
        //                "contains": "İçerir",
        //                "empty": "Boş",
        //                "equals": "Eşittir",
        //                "not": "Değildir",
        //                "notEmpty": "Dolu",
        //                "without": "Hariç"
        //            }
        //        },
        //        "data": "Veri",
        //        "deleteTitle": "Filtreleme kuralını silin",
        //        "leftTitle": "Kriteri dışarı çıkart",
        //        "logicAnd": "ve",
        //        "logicOr": "veya",
        //        "rightTitle": "Kriteri içeri al",
        //        "title": {
        //            "0": "Arama Oluşturucu",
        //            "_": "Arama Oluşturucu (%d)"
        //        },
        //        "value": "Değer",
        //        "clearAll": "Filtreleri Temizle"
        //    },
        //    "searchPanes": {
        //        "clearMessage": "Hepsini Temizle",
        //        "collapse": {
        //            "0": "Arama Bölmesi",
        //            "_": "Arama Bölmesi (%d)"
        //        },
        //        "count": "{total}",
        //        "countFiltered": "{shown}\/{total}",
        //        "emptyPanes": "Arama Bölmesi yok",
        //        "loadMessage": "Arama Bölmeleri yükleniyor ...",
        //        "title": "Etkin filtreler - %d",
        //        "showMessage": "Tümünü Göster",
        //        "collapseMessage": "Tümünü Gizle"
        //    },
        //    "thousands": ".",
        //    "datetime": {
        //        "amPm": [
        //            "öö",
        //            "ös"
        //        ],
        //        "hours": "Saat",
        //        "minutes": "Dakika",
        //        "next": "Sonraki",
        //        "previous": "Önceki",
        //        "seconds": "Saniye",
        //        "unknown": "Bilinmeyen",
        //        "weekdays": {
        //            "6": "Paz",
        //            "5": "Cmt",
        //            "4": "Cum",
        //            "3": "Per",
        //            "2": "Çar",
        //            "1": "Sal",
        //            "0": "Pzt"
        //        },
        //        "months": {
        //            "9": "Ekim",
        //            "8": "Eylül",
        //            "7": "Ağustos",
        //            "6": "Temmuz",
        //            "5": "Haziran",
        //            "4": "Mayıs",
        //            "3": "Nisan",
        //            "2": "Mart",
        //            "11": "Aralık",
        //            "10": "Kasım",
        //            "1": "Şubat",
        //            "0": "Ocak"
        //        }
        //    },
        //    "decimal": ",",
        //    "editor": {
        //        "close": "Kapat",
        //        "create": {
        //            "button": "Yeni",
        //            "submit": "Kaydet",
        //            "title": "Yeni kayıt oluştur"
        //        },
        //        "edit": {
        //            "button": "Düzenle",
        //            "submit": "Güncelle",
        //            "title": "Kaydı düzenle"
        //        },
        //        "error": {
        //            "system": "Bir sistem hatası oluştu (Ayrıntılı bilgi)"
        //        },
        //        "multi": {
        //            "info": "Seçili kayıtlar bu alanda farklı değerler içeriyor. Seçili kayıtların hepsinde bu alana aynı değeri atamak için buraya tıklayın; aksi halde her kayıt bu alanda kendi değerini koruyacak.",
        //            "noMulti": "Bu alan bir grup olarak değil ancak tekil olarak düzenlenebilir.",
        //            "restore": "Değişiklikleri geri al",
        //            "title": "Çoklu değer"
        //        },
        //        "remove": {
        //            "button": "Sil",
        //            "confirm": {
        //                "_": "%d adet kaydı silmek istediğinize emin misiniz?",
        //                "1": "Bu kaydı silmek istediğinizden emin misiniz?"
        //            },
        //            "submit": "Sil",
        //            "title": "Kayıtları sil"
        //        }
        //    },
        //    "stateRestore": {
        //        "creationModal": {
        //            "button": "Kaydet",
        //            "columns": {
        //                "search": "Kolon Araması",
        //                "visible": "Kolon Görünümü"
        //            },
        //            "name": "Görünüm İsmi",
        //            "order": "Sıralama",
        //            "paging": "Sayfalama",
        //            "scroller": "Kaydırma (Scrool)",
        //            "search": "Arama",
        //            "searchBuilder": "Arama Oluşturucu",
        //            "select": "Seçimler",
        //            "title": "Yeni Görünüm Oluştur",
        //            "toggleLabel": "Kaydedilecek Olanlar"
        //        },
        //        "duplicateError": "Bu Görünüm Daha Önce Tanımlanmış",
        //        "emptyError": "Görünüm Boş Olamaz",
        //        "emptyStates": "Herhangi Bir Görünüm Yok",
        //        "removeJoiner": "ve",
        //        "removeSubmit": "Sil",
        //        "removeTitle": "Görünüm Sil",
        //        "renameButton": "Değiştir",
        //        "renameLabel": "Görünüme Yeni İsim Ver -&gt; %s:",
        //        "renameTitle": "Görünüm İsmini Değiştir",
        //        "removeConfirm": "Görünümü silmek istediğinize emin misiniz?",
        //        "removeError": "Görünüm silinemedi"
        //    }
        //},
        //        "footerCallback": function (row, data, start, end, display) {
        //            var api = this.api(), data;

        //            // converting to interger to find total
        //            var intVal = function (i) {
        //                return typeof i === 'string' ?
        //                    i.replace(/[\$,]/g, '') * 1 :
        //                    typeof i === 'number' ?
        //                        i : 0;
        //            };

        //            // computing column Total of the complete result
        //            var Total = api
        //                .column(2)
        //                .data()
        //                .reduce(function (a, b) {
        //                    return intVal(a) + intVal(b);
        //                }, 0);
        //            $(api.column(1).footer()).html('Total');
        //            $(api.column(2).footer()).html(Total);
        //        },
    });
});
//---------------DATATABLE-------------------------------//

//#endregion

//#region IsStringKey & IsNumberKey Functions
//Rakam ve harf için = ((e.keyCode <= 93 && e.keyCode >= 65) || (e.keyCode <= 122 && e.keyCode >= 97) || e.keyCode == 8) || e.keyCode == 350 || e.keyCode == 351 || e.keyCode == 304 || e.keyCode == 286 || e.keyCode == 287 || e.keyCode == 231 || e.keyCode == 199 || e.keyCode == 305 || e.keyCode == 214 || e.keyCode == 246 || e.keyCode == 220 || e.keyCode == 252 || e.keyCode == 223 || e.keyCode == 189 || (e.keyCode >= 48 && e.keyCode <= 57)

//-letter and digit control scripts-//
//-kullanımı  onkeypress="return isNumberKey(event)"   -//
//-kullanımı  onkeypress="return isStringKey(event)"   -//

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;
    return true;
}

function isStringKey(evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode
    if (((charCode <= 93 && charCode >= 65) || (charCode <= 122 && charCode >= 97) || charCode == 8) || charCode == 350 || charCode == 351 || charCode == 304 || charCode == 286 || charCode == 287 || charCode == 231 || charCode == 199 || charCode == 305 || charCode == 214 || charCode == 246 || charCode == 220 || charCode == 252 || charCode == 32) {
        return true;
    }
    return false;
}
//-letter and digit control scripts-//

//#endregion

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
//#endregion

//#region AskBeforeFunctions
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
                            //$('#loader').addClass('hidden')
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
//---------------ASK FOR ADD-------------------------------//

//---------------ASK FOR DELETE-------------------------------//
//-kullanım   onsubmit="return askBeforeDelete(this,'divid');"    -//
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
                            //$('#loader').addClass('hidden')
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
//---------------ASK FOR DELETE-------------------------------//
//#endregion

//#region VirtualSelect

//---------------VIRTUAL SELECT-------------------------------//
$(document).ready(function () {
    VirtualSelect.init({
        ele: '.virtualMultiple',
        multiple: true, search: true,
        autoSelectFirstOption: false,
        /*   required: true,*/
        selectAllOnlyVisible: true,
        /*hideValueTooltipOnSelectAll: true,*/
    });
    VirtualSelect.init({
        placeholder: 'Select',
        ariaLabelText:'Select',
        ele: '.virtualSingle',
        autoSelectFirstOption:false,
        multiple: true, search: true,
        /*   required: true,*/
        selectAllOnlyVisible: true,
        /*hideValueTooltipOnSelectAll: true,*/
    });
});
//---------------VIRTUAL SELECT-------------------------------//
//#endregion

//#region Select2
$(document).ready(function () {
    $('.customSelect2').select2({
        placeholder: "Seçiniz",
        allowClear: false,
        focus: false,
        closeOnSelect: true,
        dropdownCssClass: 'select2-info',
        multiple: false,

    })
});
//---------------SELECT2-------------------------------//

//#endregion

//#region SubmitFormAndOpenPopUp
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
                            //$('#customModal').modal({ show: true });
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

 //#endregion