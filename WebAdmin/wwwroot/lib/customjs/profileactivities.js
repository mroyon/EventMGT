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
            //debugger;
            if (_cusFormValidate('frmchangepassword')) {
                var dataobject = {
                    emailaddress: $("#emailaddress").val(),
                    password: $("#password").val(),
                    newpassword: $("#newpassword").val(),
                    confirmpassword: $("#confirmpassword").val()
                };
                /*console.log(dataobject)*/
                if ($("#password").val() === $("#newpassword").val()) {
                    showErrorAlert("New Password can't be same as Old Password!");
                    return;
                }
                ajaxPostObjectHandler("/Account/ChangePasswordPost", dataobject, function (response) {
                    var res = response;
                    //console.log(response)
                    if (res.responsestatus == "success") {
                        showSuccessAlert("Success", res.responsetext, "OK");
                        setTimeout(function () {
                            window.location.reload();
                        }, 2000);
                        
                    }
                    else {
                        showErrorAlert(res.responsetitle, res.responsetext, "OK");
                    }
                }, true);
            }

        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });

});
