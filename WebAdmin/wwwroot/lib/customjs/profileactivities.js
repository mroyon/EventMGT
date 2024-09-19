/******************************************
 * profile activities 
 * All function related with Change Password
 ******************************************/
/*!
 * profileactivities JavaScript Library v1.0
 *
 *
 * Copyright KAF Foundation and other contributors
 * https://jquery.org/license
 *
 * Date: 2021-03-02T17:08Z
 */

'use strict';

function updateLanguage(culture, returnUrl) {
    var dataobject = { culture: culture, returnUrl: returnUrl };

    console.log(dataobject)

    if (culture == 'bn-BD') {
        $('input').css("font-family", "'Kalpurush','SutonnyMJ','AdarshaLipiNormal','Helvetica Neue', Helvetica, Arial, sans-serif");
        $('.banglafont').css("font-family", "'Kalpurush','SutonnyMJ','AdarshaLipiNormal','Helvetica Neue', Helvetica, Arial, sans-serif");

    } else {
        $('input').css("font-family", "'Helvetica Neue', Helvetica, Arial, sans-serif");
        $('.banglafont').css("font-family", "'Helvetica Neue', Helvetica, Arial, sans-serif");
    }
    //ajaxPostObjectHandler("/Home/SetLanguage", dataobject, function (response) {
    //    if (response !== "INVALID_PARAMETERS") {
    //        window.location.reload();
    //    }
    //}, true);
}

function signOut() {
    var dataobject = {  };
    ajaxPostObjectHandler("/Account/Logout", dataobject, function (response) {
        window.location.reload();
    }, true);
}

$(function () {
    $('body').on('click', '#ahrefchange_password', function (e) {
        ajaxGetHandler("/Account/ChangePassword", { returnUrl: "/" }, function (response) {
            _cusTriggerModal("modal-common", response);
        }, false, false);
    });

    $('body').on('click', '#btn-common-modal-close', function (event) {
        try {
            event.preventDefault();
            _cusCloseModal('modal-common');
        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });


    $('body').on('click', '#btnchangepassword', function (event) {
        try {
            event.preventDefault();
            
            if (_cusFormValidate('frmchangepassword')) {
                var dataobject = {
                    emailaddress: $("#emailaddress").val(),
                    password: $("#password").val(),
                    newpassword: $("#newpassword").val(),
                    confirmpassword: $("#confirmpassword").val()
                };
                /*console.log(dataobject)*/
                ajaxPostObjectHandler("/Account/ChangePasswordPost", dataobject, function (response) {
                    var res = $.parseJSON(response);
                    if (res._ajaxresponse.responsestatus == "success") {
                        showSuccessAlert("Success", res._ajaxresponse.responsetext, "OK");
                        window.location.reload();
                    }
                    else {
                        showErrorAlert(res._ajaxresponse.responsetitle, res._ajaxresponse.responsetext, "OK");
                    }
                }, true);
            }

        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });

});
