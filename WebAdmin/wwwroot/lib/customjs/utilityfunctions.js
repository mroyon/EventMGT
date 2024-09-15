/*!
 * Utility functions JavaScript Library v1.0
 *
 * Copyright Mahmudur rahman Foundation and other contributors
 * Released under the MIT license
 * https://jquery.org/license
 * Date: 2021-03-02T17:08Z
 */
'use strict';

var dir = $("html").attr("dir");
$(function () {
    $("[requiredmarkup]").after($("<span>", {
        class: "required"
    }).html("*"));
});

$(document).ready(function () {
    //ShowTime();
    //dateEnglish();
    //dateArabic();

       console.log("trye")

    tinymce.init({
        mode: "textareas",
        directionality: dir,
        base_url: '/lib/tinymce',
        skin: 'oxide-dark',
        content_css: 'dark',
        menubar: false,
        statusbar: false,
        toolbar: 'undo redo | bold italic underline strikethrough | fontselect fontsizeselect formatselect | alignleft aligncenter alignright alignjustify | outdent indent |  numlist bullist checklist | forecolor backcolor casechange permanentpen formatpainter removeformat | pagebreak | charmap emoticons | fullscreen  preview save print | insertfile image media pageembed template link anchor codesample | a11ycheck ltr rtl | showcomments addcomment',
        quickbars_selection_toolbar: 'bold italic | quicklink h2 h3 blockquote quickimage quicktable',
        plugins: 'lists',

        setup: function (editor) {
            editor.on('change', function () {
                tinymce.triggerSave();
                //validateRequiredfldTM();
            });
        }
    });


    window.history.pushState(null, "", window.location.href);
    window.onpopstate = function () {
        window.history.pushState(null, "", window.location.href);
    };

    $('body').on('click', '#btnGoBacktoLanding', function (event) {
        event.preventDefault();
        var data = $("#btnGoBacktoLanding").attr("data");
        if (data === undefined) {
            alert("Back URL to Landing is not specified.");
            return;
        }
        window.location.href = data;
    });
});


function NotifyMessage(text) {
    swal({
        position: 'bottom-end',
        title: "Success",
        text: text,
        type: "info",
        showConfirmButton: false,
        timer: 1000
    });
};

function WarningMessage(textMsg) {
    swal({
        position: 'bottom-end',
        title: "Warning",
        text: textMsg,
        type: "warning",
        showConfirmButton: false,
        timer: 1000
    });
};


function base64ArrayBuffer(arrayBuffer) {
    var base64 = ''
    var encodings = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/'

    var bytes = new Uint8Array(arrayBuffer)
    var byteLength = bytes.byteLength
    var byteRemainder = byteLength % 3
    var mainLength = byteLength - byteRemainder

    var a, b, c, d
    var chunk
    for (var i = 0; i < mainLength; i = i + 3) {
        chunk = (bytes[i] << 16) | (bytes[i + 1] << 8) | bytes[i + 2]
        a = (chunk & 16515072) >> 18 // 16515072 = (2^6 - 1) << 18
        b = (chunk & 258048) >> 12 // 258048   = (2^6 - 1) << 12
        c = (chunk & 4032) >> 6 // 4032     = (2^6 - 1) << 6
        d = chunk & 63               // 63       = 2^6 - 1
        base64 += encodings[a] + encodings[b] + encodings[c] + encodings[d]
    }

    if (byteRemainder == 1) {
        chunk = bytes[mainLength]
        a = (chunk & 252) >> 2 // 252 = (2^6 - 1) << 2
        b = (chunk & 3) << 4 // 3   = 2^2 - 1
        base64 += encodings[a] + encodings[b] + '=='
    } else if (byteRemainder == 2) {
        chunk = (bytes[mainLength] << 8) | bytes[mainLength + 1]
        a = (chunk & 64512) >> 10 // 64512 = (2^6 - 1) << 10
        b = (chunk & 1008) >> 4 // 1008  = (2^6 - 1) << 4
        c = (chunk & 15) << 2 // 15    = 2^4 - 1
        base64 += encodings[a] + encodings[b] + encodings[c] + '='
    }

    return base64
}

$(function () {
    $("[requiredmarkup]").after($("<span>", {
        class: "required"
    }).html("*"));
});

function takeTwoInput(title, text, btntext) {
    //swal({ title: 'Test', input: 'text' });

    swal({
        title: "An input!",
        text: '<h2>Login details for waybill generation</h2><input id="txtmsgonline" name="txtmsgonline" type="text" tabIndex="1" class="form-control" placeholder="your message">',
        html: true,
        showCancelButton: true,
        closeOnConfirm: false,
        animation: "slide-from-top",
        inputPlaceholder: "Write something",
        preConfirm: function () {
            return new Promise(function (resolve, reject) {
                setTimeout(function () {

                    var msg = $('#txtmsgonline').val();
                    if (msg === '') {
                        reject('This email is already taken.')
                    } else {
                        resolve([
                            $('#txtmsgonline').val(),
                            $('#swal-input2').val()
                        ])
                    }
                }, 2000)

            })
        },
        onOpen: function () {
            $('#txtmsgonline').focus()
        }
    }).then(function (result) {
        swal(JSON.stringify(result))
    }).catch(swal.noop)

}
function showErrorAlert(title, text, btntext, callbackfunction, params) {
    swal({
        title: title,
        text: text,
        type: "error",
        html: true,
        showCancelButton: false,
        allowOutsideClick: false,
        allowEscapeKey: false,
        //confirmButtonClass: 'btn-danger',
        confirmButtonText: btntext
    }, function () {
        if (typeof callbackfunction != 'undefined')
            callbackfunction(params);
    });
};
function showConfirmationAlert(title, text, btntext, callbackfunction, params) {
    swal({
        title: title,
        text: text,
        html: true,
        showCancelButton: true,
        allowOutsideClick: false,
        allowEscapeKey: false,
        //confirmButtonClass: 'btn-danger',
        confirmButtonText: btntext
    }, function () {
        if (typeof callbackfunction != 'undefined')
            callbackfunction(params);
    });
};
function showSuccessAlert(title, text, btntext, callbackfunction, params) {
    swal({
        title: title,
        text: text,
        html: true,
        type: "success",
        showCancelButton: false,
        allowOutsideClick: false,
        allowEscapeKey: false,
        //confirmButtonClass: 'btn-success',
        confirmButtonText: btntext
    }, function () {
        if (typeof callbackfunction != 'undefined')
            callbackfunction(params);
    });
};
function showInformationAlert(title, text, btntext, callbackfunction, params) {
    swal({
        title: title,
        text: text,
        type: "info",
        html: true,
        showCancelButton: false,
        allowOutsideClick: false,
        allowEscapeKey: false,        //confirmButtonClass: 'btn-info',
        confirmButtonText: btntext
    }, function () {
        if (typeof callbackfunction != 'undefined')
            callbackfunction(params);
    });
};
function showWarningAlert(title, text, btntext, cancelButtonText, callbackfunction) {

    swal({
        title: title,
        text: text,
        icon: "warning",
        html: true,
        showCancelButton: true,
        cancelButtonColor: "#d33",
        confirmButtonText: btntext,
        cancelButtonText: cancelButtonText
    },

        function () {
            if (typeof callbackfunction != 'undefined')
                callbackfunction();
        });

    //swal("A wild Pikachu appeared! What do you want to do?", {
    //    buttons: {
    //        cancel: "Run away!",
    //        catch: {
    //            text: "Throw Pokéball!",
    //            value: "catch",
    //        },
    //        defeat: true,
    //    },
    //})
    //    .then((value) => {
    //        switch (value) {

    //            case "defeat":
    //                swal("Pikachu fainted! You gained 500 XP!");
    //                break;

    //            case "catch":
    //                swal("Gotcha!", "Pikachu was caught!", "success");
    //                break;

    //            default:
    //                swal("Got away safely!");
    //        }
    //    });

};

function _cusTriggerModal(modalID, htmldata) {

    $.fn.modal.Constructor.prototype._enforceFocus = function () { };

    var modid = modalID + '-content';
    var modcontainerid = modalID + '-container';

    $('#' + modid).html('');
    $('#' + modid).html(htmldata);
    // $('#' + modcontainerid).modal({ backdrop: 'static', keyboard: false });
    let modal = bootstrap.Modal.getOrCreateInstance(document.getElementById(modcontainerid))
    modal.show({ backdrop: 'static', keyboard: false });
}

function _cusCloseModal(modalID) {
    var modid = modalID + '-content';
    var modcontainerid = modalID + '-container';

    $('#' + modid).html('');
    $('#' + modcontainerid).modal('hide');
}

function _cusFormValidate(formID) {

    var flg = false;
    var form = $('#' + formID);
    jQuery.validator.unobtrusive.parse();
    jQuery.validator.unobtrusive.parse(form);

    if (form.valid()) {
        flg = true;
    }
    else {
        flg = false;
    }

    return flg;
}
function redirectToLandingView(url) {
    try {
        window.location.href = url;
    } catch (e) {
        showErrorAlert("Error", e.message, "OK");
    }
}

$(document).ready(function () {
    $('#divprogress').hide();
    var url = window.location;
    // for sidebar menu entirely but not cover treeview
    $('ul.nav-sidebar a').filter(function () {
        //if (this.href == url)
        //return this.href.slice(0, -1) == url;
        return this.href == url;
    }).addClass('active');

    // for treeview
    $('ul.nav-treeview a').filter(function () {
        return this.href == url;
    }).parentsUntil(".nav-sidebar > .nav-treeview").addClass('menu-open').prev('a').addClass('active');
});
//$("input[required]").parent("label").addClass("required");

function dateEnglish() {
    var today = new Date();
    var h = today.getHours();
    var m = today.getMinutes();
    var s = today.getSeconds();
    var d = new Date();
    var n = d.getDate();
    var month = new Array();
    month[0] = "يناير";
    month[1] = "فبراير";
    month[2] = "مارس";
    month[3] = "أبريل";
    month[4] = "مايو";
    month[5] = "يونيو";
    month[6] = "يوليو";
    month[7] = "أغسطس";
    month[8] = "سبتمبر";
    month[9] = "اكتوبر";
    month[10] = "نوفمبر";
    month[11] = "ديسمبر";
    var t = month[d.getMonth()];
    var y = d.getFullYear();
    //m = checkTime(m);
    //s = checkTime(s);
    document.getElementById('date-en')
        .innerHTML = checkTime(n) + " " + t + " " + y;
    var t = setTimeout(function () {
        //startTime()
    }, 1000);
}
//function dateArabic() {
//    //ar-TN-u-ca-islamic
//    var event = new Intl.DateTimeFormat('ar-EG', { day: 'numeric', month: 'long', year: 'numeric' }).format(Date.now());
//    document.getElementById('date-ar')
//        .innerHTML = event;
//    var t = setTimeout(function () {
//        startTime()
//    }, 1000);
//}

function ShowTime() {
    var date = new Date();
    var hours = date.getHours();
    var minutes = date.getMinutes();

    var secs = date.getSeconds();
    var ampm = hours >= 12 ? 'PM' : 'AM';
    hours = hours % 12;
    hours = hours ? hours : 12; // the hour '0' should be '12'
    minutes = minutes < 10 ? '0' + minutes : minutes;
    var strTime = hours + ':' + minutes + ":" + checkTime(secs) + ' ' + ampm;
    document.getElementById("lblShowTime")
        .innerHTML = strTime;
    window.setTimeout("ShowTime()", 1000); // Here 1000(milliseconds) means one 1 Sec
}

function checkTime(i) {
    if (i < 10) {
        i = "0" + i
    }; // add zero in front of numbers < 10
    return i;
}



function GetDateFromTextBox(strdate) {
    if (strdate != "" && typeof strdate !== 'undefined') {

        var retdate = moment(moment(strdate, 'DD-MM-YYYY')).format('YYYY-MM-DD');

        return retdate;
    }
}
