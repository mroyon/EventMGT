/*!
 * Entity Model Wise : Owin_User : functions JavaScript Library v1.0 
 * Copyright Kuwait Armed Forces and other contributors
 * Released under the MIT license
 * https://jquery.org/license
 * Date: 2022/07/17 8:44:46 AM
 * PC: Major Mahmud
 */

'use strict';

function ValidateEmail(email) {
    var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    if (email.value) {
        if (email.value.match(mailformat)) {
            $('#btnAddOwin_User').prop("disabled", false)
            $('#btnEmailResetOwin_User').prop("disabled", false)
            return true;
        }
        else {
            showErrorAlert("Warning!", "You have entered an invalid email address", "OK");
            $('#btnEmailResetOwin_User').prop("disabled", true)
            $('#btnAddOwin_User').prop("disabled", true)
            return false;
        }
    }
}
function ValidateUserName(user) {
    var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    if (user.value) {
        if (user.value.match(mailformat)) {
            return true;
        }
        else {
            showErrorAlert("Warning!", "You have entered an invalid user name", "OK");
            return false;
        }
    }
}
function validateRequiredfldmasprivatekey() {
    $('#masprivatekeyerror').hide();
    $('#masprivatekeyerror').html('');
    if (tinymce.get("masprivatekey").getContent() == '') {
        var masprivatekeyMsg = $('#masprivatekey').attr('data-val-required');
        $('#masprivatekeyerror').show();
        $('#masprivatekeyerror').html(masprivatekeyMsg);
        return false;
    }
}
function validateRequiredfldmaspublickey() {
    $('#maspublickeyerror').hide();
    $('#maspublickeyerror').html('');
    if (tinymce.get("maspublickey").getContent() == '') {
        var maspublickeyMsg = $('#maspublickey').attr('data-val-required');
        $('#maspublickeyerror').show();
        $('#maspublickeyerror').html(maspublickeyMsg);
        return false;
    }
}
function validateRequiredfldpassword() {
    $('#passworderror').hide();
    $('#passworderror').html('');
    if (tinymce.get("password").getContent() == '') {
        var passwordMsg = $('#password').attr('data-val-required');
        $('#passworderror').show();
        $('#passworderror').html(passwordMsg);
        return false;
    }
}
function validateRequiredfldpasswordsalt() {
    $('#passwordsalterror').hide();
    $('#passwordsalterror').html('');
    if (tinymce.get("passwordsalt").getContent() == '') {
        var passwordsaltMsg = $('#passwordsalt').attr('data-val-required');
        $('#passwordsalterror').show();
        $('#passwordsalterror').html(passwordsaltMsg);
        return false;
    }
}
function validateRequiredfldpasswordkey() {
    $('#passwordkeyerror').hide();
    $('#passwordkeyerror').html('');
    if (tinymce.get("passwordkey").getContent() == '') {
        var passwordkeyMsg = $('#passwordkey').attr('data-val-required');
        $('#passwordkeyerror').show();
        $('#passwordkeyerror').html(passwordkeyMsg);
        return false;
    }
}
function validateRequiredfldpasswordvector() {
    $('#passwordvectorerror').hide();
    $('#passwordvectorerror').html('');
    if (tinymce.get("passwordvector").getContent() == '') {
        var passwordvectorMsg = $('#passwordvector').attr('data-val-required');
        $('#passwordvectorerror').show();
        $('#passwordvectorerror').html(passwordvectorMsg);
        return false;
    }

}


$(function () {
    var LandingOwin_User = "/Owin_User/LandingOwin_User";
    function RedirectToLanding(params) {
        if (typeof params != 'undefined')
            window.location.href = params;
    }

    $('body').on('click', '#btnAddOwin_User', function (e) {
        try {
            event.preventDefault();
            if (_cusFormValidate('frmAddOwin_User')) {

                var dataobject = {
                    username: $("#username").val(),
                    emailaddress: $("#emailaddress").val(),
                    loweredusername: $("#username").val().toLowerCase(),
                    password: $("#newpassword").val(),
                    pkeyex: $("#pkeyex").val(),
                    confirmpassword: $("#confirmpassword").val(),
                    roleid: $("#roleid").val(),
                    mobilenumber: $("#mobilenumber").val(),
                    //approved: true,
                };
                ajaxPostObjectHandler("/Owin_User/AddOwin_User", dataobject, function (response) {

                    //console.log(response)
                    //console.log(response.StatusCode)
                    //console.log(response._ajaxresponse.responsetext)
                    //console.log(response._ajaxresponse.responsestatus)

                    if (response.StatusCode == "200") {
                        showSuccessAlert("Success", JSON.parse(response.Content).description, "OK", RedirectToLanding, LandingOwin_User);
                    }
                    else {

                        var msg = JSON.parse(response.Content).description == "Duplicate value can not be saved." ? "User/Email Address already exists" : JSON.parse(response.Content).description;
                        showErrorAlert("Error", msg, "OK");
                    }
                }, true);
            }

        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });

    $('body').on('click', '#btnEditOwin_User', function (e) {
        try {
            event.preventDefault();
            if (_cusFormValidate('frmEditOwin_User')) {

                if (!validateRequiredfldmasprivatekey()) {
                    return false;
                }
                if (!validateRequiredfldmaspublickey()) {
                    return false;
                }
                if (!validateRequiredfldpassword()) {
                    return false;
                }
                if (!validateRequiredfldpasswordsalt()) {
                    return false;
                }
                if (!validateRequiredfldpasswordkey()) {
                    return false;
                }
                if (!validateRequiredfldpasswordvector()) {
                    return false;
                }


                var dataobject = {
                    applicationid: $("#applicationid").val(),
                    userid: $("#userid").val(),
                    masteruserid: $("#masteruserid").val(),
                    username: $("#username").val(),
                    emailaddress: $("#emailaddress").val(),
                    loweredusername: $("#username").val().toLowerCase(),
                    mobilenumber: $("#mobilenumber").val(),
                    userprofilephoto: $("#userprofilephoto").val(),
                    isanonymous: $("#isanonymous").val(),
                    ischildenable: $("#ischildenable").val(),
                    masprivatekey: tinymce.get("masprivatekey").getContent(),
                    maspublickey: tinymce.get("maspublickey").getContent(),
                    pkeyex: $("#pkeyex").val(),
                    password: tinymce.get("password").getContent(),
                    passwordsalt: tinymce.get("passwordsalt").getContent(),
                    passwordkey: tinymce.get("passwordkey").getContent(),
                    passwordvector: tinymce.get("passwordvector").getContent(),
                    mobilepin: $("#mobilepin").val(),
                    passwordquestion: $("#passwordquestion").val(),
                    passwordanswer: $("#passwordanswer").val(),
                    approved: $("#approved").val(),
                    locked: $("#locked").val(),
                    lastlogindate: $("#lastlogindate").val(),
                    lastpasschangeddate: $("#lastpasschangeddate").val(),
                    lastlockoutdate: $("#lastlockoutdate").val(),
                    failedpasswordattemptcount: $("#failedpasswordattemptcount").val(),
                    comment: tinymce.get("comment").getContent(),
                    lastactivitydate: $("#lastactivitydate").val(),
                    isapproved: $("#isapproved").val(),
                    approvedby: $("#approvedby").val(),
                    approvedbyusername: $("#approvedbyusername").val(),
                    approveddate: $("#approveddate").val(),
                    isemailconfirmed: $("#isemailconfirmed").val(),
                    emailconfirmationbyuserdate: $("#emailconfirmationbyuserdate").val(),
                    twofactorenable: $("#twofactorenable").val(),

                };

                ajaxPostObjectHandler("/Owin_User/EditOwin_User", dataobject, function (response) {
                    console.log(response);
                    if (response._ajaxresponse.responsestatus == "success") {
                        showSuccessAlert("Success", response._ajaxresponse.responsetext, "OK");
                    }
                }, true);
            }

        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });

    $('body').on('click', '#btnDeleteOwin_User', function (e) {
        try {
            event.preventDefault();
            if (_cusFormValidate('frmDeleteOwin_User')) {
                var dataobject = {
                    applicationid: $("#applicationid").val(),
                    userid: $("#userid").val(),
                    masteruserid: $("#masteruserid").val(),
                    username: $("#username").val(),
                    emailaddress: $("#emailaddress").val(),
                    loweredusername: $("#loweredusername").val(),
                    mobilenumber: $("#mobilenumber").val(),
                    userprofilephoto: $("#userprofilephoto").val(),
                    isanonymous: $("#isanonymous").val(),
                    ischildenable: $("#ischildenable").val(),
                    masprivatekey: tinymce.get("masprivatekey").getContent(),
                    maspublickey: tinymce.get("maspublickey").getContent(),
                    pkeyex: $("#pkeyex").val(),
                    password: tinymce.get("password").getContent(),
                    passwordsalt: tinymce.get("passwordsalt").getContent(),
                    passwordkey: tinymce.get("passwordkey").getContent(),
                    passwordvector: tinymce.get("passwordvector").getContent(),
                    mobilepin: $("#mobilepin").val(),
                    passwordquestion: $("#passwordquestion").val(),
                    passwordanswer: $("#passwordanswer").val(),
                    approved: $("#approved").val(),
                    locked: $("#locked").val(),
                    lastlogindate: $("#lastlogindate").val(),
                    lastpasschangeddate: $("#lastpasschangeddate").val(),
                    lastlockoutdate: $("#lastlockoutdate").val(),
                    failedpasswordattemptcount: $("#failedpasswordattemptcount").val(),
                    comment: tinymce.get("comment").getContent(),
                    lastactivitydate: $("#lastactivitydate").val(),
                    isapproved: $("#isapproved").val(),
                    approvedby: $("#approvedby").val(),
                    approvedbyusername: $("#approvedbyusername").val(),
                    approveddate: $("#approveddate").val(),
                    isemailconfirmed: $("#isemailconfirmed").val(),
                    emailconfirmationbyuserdate: $("#emailconfirmationbyuserdate").val(),
                    twofactorenable: $("#twofactorenable").val(),
                    ismobilenumberconfirmed: $("#ismobilenumberconfirmed").val(),
                    mobilenumberconfirmedbyuserdate: $("#mobilenumberconfirmedbyuserdate").val(),
                    securitystamp: $("#securitystamp").val(),
                    concurrencystamp: $("#concurrencystamp").val(),
                    webuseronly: $("#webuseronly").val()
                };
                ajaxPostObjectHandler("/Owin_User/DeleteOwin_User", dataobject, function (response) {
                    if (response._ajaxresponse.responsestatus == "success") {
                        showSuccessAlert("Success", response._ajaxresponse.responsetext, "OK", RedirectToLanding, LandingOwin_User);
                    }
                }, true);
            }
        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });

    $('body').on('click', '#btnGoBackOwin_User', function (e) {
        try {
            event.preventDefault();
            window.location.href = LandingOwin_User;
        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });



    $('body').on('click', '#btnReviewOwin_User', function (e) {
        try {
            event.preventDefault();
            if (_cusFormValidate('frmReviewOwin_User')) {

                //if (!validateRequiredfldmasprivatekey()) {
                //    return false;
                //}
                //if (!validateRequiredfldmaspublickey()) {
                //    return false;
                //}
                //if (!validateRequiredfldpassword()) {
                //    return false;
                //}
                //if (!validateRequiredfldpasswordsalt()) {
                //    return false;
                //}
                //if (!validateRequiredfldpasswordkey()) {
                //    return false;
                //}
                //if (!validateRequiredfldpasswordvector()) {
                //    return false;
                //}


                var dataobject = {
                    applicationid: $("#applicationid").val(),
                    userid: $("#userid").val(),
                    masteruserid: $("#masteruserid").val(),
                    username: $("#username").val(),
                    emailaddress: $("#emailaddress").val(),
                    loweredusername: $("#loweredusername").val(),
                    mobilenumber: $("#mobilenumber").val(),
                    userprofilephoto: $("#userprofilephoto").val(),
                    isanonymous: $("#isanonymous").val(),
                    ischildenable: $("#ischildenable").val(),
                    isreviewed: $("#isreviewed").val(),
                    pkeyex: $("#pkeyex").val(),
                    //masprivatekey: tinymce.get("masprivatekey").getContent(),
                    //maspublickey: tinymce.get("maspublickey").getContent(),
                    //password: tinymce.get("password").getContent(),
                    //passwordsalt: tinymce.get("passwordsalt").getContent(),
                    //passwordkey: tinymce.get("passwordkey").getContent(),
                    //passwordvector: tinymce.get("passwordvector").getContent(),
                    mobilepin: $("#mobilepin").val(),
                    passwordquestion: $("#passwordquestion").val(),
                    passwordanswer: $("#passwordanswer").val(),
                    approved: $("#approved").val(),
                    locked: $("#locked").val(),
                    lastlogindate: $("#lastlogindate").val(),
                    lastpasschangeddate: $("#lastpasschangeddate").val(),
                    lastlockoutdate: $("#lastlockoutdate").val(),
                    failedpasswordattemptcount: $("#failedpasswordattemptcount").val(),
                    //comment: tinymce.get("comment").getContent(),
                    lastactivitydate: $("#lastactivitydate").val(),
                    isapproved: $("#isapproved").val(),
                    approvedby: $("#approvedby").val(),
                    approvedbyusername: $("#approvedbyusername").val(),
                    approveddate: $("#approveddate").val(),
                    isemailconfirmed: $("#isemailconfirmed").val(),
                    emailconfirmationbyuserdate: $("#emailconfirmationbyuserdate").val(),
                    twofactorenable: $("#twofactorenable").val(),
                    ismobilenumberconfirmed: $("#ismobilenumberconfirmed").val(),
                    mobilenumberconfirmedbyuserdate: $("#mobilenumberconfirmedbyuserdate").val(),
                    securitystamp: $("#securitystamp").val(),
                    concurrencystamp: $("#concurrencystamp").val(),
                    webuseronly: $("#webuseronly").val()
                };

                ajaxPostObjectHandler("/Owin_User/ReviewOwin_User", dataobject, function (response) {
                    console.log(response);
                    if (response._ajaxresponse.responsestatus == "success") {
                        showSuccessAlert("Success", response._ajaxresponse.responsetext, "OK", RedirectToLanding, LandingOwin_User);
                    }
                }, true);
            }

        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });
    $('body').on('click', '#btnLockOwin_User', function (e) {
        try {
            event.preventDefault();
            if (_cusFormValidate('frmLockOwin_User')) {

                //if (!validateRequiredfldmasprivatekey()) {
                //    return false;
                //}
                //if (!validateRequiredfldmaspublickey()) {
                //    return false;
                //}
                //if (!validateRequiredfldpassword()) {
                //    return false;
                //}
                //if (!validateRequiredfldpasswordsalt()) {
                //    return false;
                //}
                //if (!validateRequiredfldpasswordkey()) {
                //    return false;
                //}
                //if (!validateRequiredfldpasswordvector()) {
                //    return false;
                //}


                var dataobject = {
                    applicationid: $("#applicationid").val(),
                    userid: $("#userid").val(),
                    masteruserid: $("#masteruserid").val(),
                    username: $("#username").val(),
                    emailaddress: $("#emailaddress").val(),
                    loweredusername: $("#loweredusername").val(),
                    mobilenumber: $("#mobilenumber").val(),
                    userprofilephoto: $("#userprofilephoto").val(),
                    isanonymous: $("#isanonymous").val(),
                    ischildenable: $("#ischildenable").val(),
                    pkeyex: $("#pkeyex").val(),
                    //masprivatekey: tinymce.get("masprivatekey").getContent(),
                    //maspublickey: tinymce.get("maspublickey").getContent(),
                    //password: tinymce.get("password").getContent(),
                    //passwordsalt: tinymce.get("passwordsalt").getContent(),
                    //passwordkey: tinymce.get("passwordkey").getContent(),
                    //passwordvector: tinymce.get("passwordvector").getContent(),
                    mobilepin: $("#mobilepin").val(),
                    passwordquestion: $("#passwordquestion").val(),
                    passwordanswer: $("#passwordanswer").val(),
                    approved: $("#approved").val(),
                    locked: $("#locked").val(),
                    lastlogindate: $("#lastlogindate").val(),
                    lastpasschangeddate: $("#lastpasschangeddate").val(),
                    lastlockoutdate: $("#lastlockoutdate").val(),
                    failedpasswordattemptcount: $("#failedpasswordattemptcount").val(),
                    //comment: tinymce.get("comment").getContent(),
                    lastactivitydate: $("#lastactivitydate").val(),
                    isapproved: $("#isapproved").val(),
                    approvedby: $("#approvedby").val(),
                    approvedbyusername: $("#approvedbyusername").val(),
                    approveddate: $("#approveddate").val(),
                    isemailconfirmed: $("#isemailconfirmed").val(),
                    emailconfirmationbyuserdate: $("#emailconfirmationbyuserdate").val(),
                    twofactorenable: $("#twofactorenable").val(),
                    ismobilenumberconfirmed: $("#ismobilenumberconfirmed").val(),
                    mobilenumberconfirmedbyuserdate: $("#mobilenumberconfirmedbyuserdate").val(),
                    securitystamp: $("#securitystamp").val(),
                    concurrencystamp: $("#concurrencystamp").val(),
                    webuseronly: $("#webuseronly").val()
                };

                ajaxPostObjectHandler("/Owin_User/LockOwin_User", dataobject, function (response) {
                    console.log(response);
                    if (response._ajaxresponse.responsestatus == "success") {
                        showSuccessAlert("Success", response._ajaxresponse.responsetext, "OK", RedirectToLanding, LandingOwin_User);
                    }
                }, true);
            }

        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });
    $('body').on('click', '#btnPassResetOwin_User', function (e) {
        try {
            event.preventDefault();
            if (_cusFormValidate('frmPasswordOwin_User')) {

                //if (!validateRequiredfldmasprivatekey()) {
                //    return false;
                //}
                //if (!validateRequiredfldmaspublickey()) {
                //    return false;
                //}
                //if (!validateRequiredfldpassword()) {
                //    return false;
                //}
                //if (!validateRequiredfldpasswordsalt()) {
                //    return false;
                //}
                //if (!validateRequiredfldpasswordkey()) {
                //    return false;
                //}
                //if (!validateRequiredfldpasswordvector()) {
                //    return false;
                //}


                var dataobject = {
                    applicationid: $("#applicationid").val(),
                    userid: $("#userid").val(),
                    masteruserid: $("#masteruserid").val(),
                    username: $("#username").val(),
                    emailaddress: $("#emailaddress").val(),
                    loweredusername: $("#loweredusername").val(),
                    mobilenumber: $("#mobilenumber").val(),
                    userprofilephoto: $("#userprofilephoto").val(),
                    isanonymous: $("#isanonymous").val(),
                    ischildenable: $("#ischildenable").val(),
                    pkeyex: $("#pkeyex").val(),
                    //masprivatekey: tinymce.get("masprivatekey").getContent(),
                    //maspublickey: tinymce.get("maspublickey").getContent(),
                    //password: tinymce.get("password").getContent(),
                    //passwordsalt: tinymce.get("passwordsalt").getContent(),
                    //passwordkey: tinymce.get("passwordkey").getContent(),
                    //passwordvector: tinymce.get("passwordvector").getContent(),
                    mobilepin: $("#mobilepin").val(),
                    passwordquestion: $("#passwordquestion").val(),
                    passwordanswer: $("#passwordanswer").val(),
                    approved: $("#approved").val(),
                    locked: $("#locked").val(),
                    lastlogindate: $("#lastlogindate").val(),
                    lastpasschangeddate: $("#lastpasschangeddate").val(),
                    lastlockoutdate: $("#lastlockoutdate").val(),
                    failedpasswordattemptcount: $("#failedpasswordattemptcount").val(),
                    //comment: tinymce.get("comment").getContent(),
                    lastactivitydate: $("#lastactivitydate").val(),
                    isapproved: $("#isapproved").val(),
                    approvedby: $("#approvedby").val(),
                    approvedbyusername: $("#approvedbyusername").val(),
                    approveddate: $("#approveddate").val(),
                    isemailconfirmed: $("#isemailconfirmed").val(),
                    emailconfirmationbyuserdate: $("#emailconfirmationbyuserdate").val(),
                    twofactorenable: $("#twofactorenable").val(),
                    ismobilenumberconfirmed: $("#ismobilenumberconfirmed").val(),
                    mobilenumberconfirmedbyuserdate: $("#mobilenumberconfirmedbyuserdate").val(),
                    securitystamp: $("#securitystamp").val(),
                    concurrencystamp: $("#concurrencystamp").val(),
                    webuseronly: $("#webuseronly").val(),
                    newpassword: $("#newpassword").val(),
                    confirmpassword: $("#confirmpassword").val()
                };

                ajaxPostObjectHandler("/Owin_User/PasswordResetOwin_User", dataobject, function (response) {

                    if (response._ajaxresponse.responsestatus == "success") {
                        showSuccessAlert("Success", response._ajaxresponse.responsetext, "OK", RedirectToLanding, LandingOwin_User);
                    }
                }, true);
            }

        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });


    


    $('body').on('click', '#btnEmailResetOwin_User', function (e) {
        try {
            event.preventDefault();
            if (_cusFormValidate('frmEmailOwin_User')) {

                //if (!validateRequiredfldmasprivatekey()) {
                //    return false;
                //}
                //if (!validateRequiredfldmaspublickey()) {
                //    return false;
                //}
                //if (!validateRequiredfldpassword()) {
                //    return false;
                //}
                //if (!validateRequiredfldpasswordsalt()) {
                //    return false;
                //}
                //if (!validateRequiredfldpasswordkey()) {
                //    return false;
                //}
                //if (!validateRequiredfldpasswordvector()) {
                //    return false;
                //}


                var dataobject = {
                    applicationid: $("#applicationid").val(),
                    userid: $("#userid").val(),
                    masteruserid: $("#masteruserid").val(),
                    username: $("#username").val(),
                    emailaddress: $("#emailaddress").val(),
                    newemailaddress: $("#newemailaddress").val(),
                    loweredusername: $("#loweredusername").val(),
                    mobilenumber: $("#mobilenumber").val(),
                    userprofilephoto: $("#userprofilephoto").val(),
                    isanonymous: $("#isanonymous").val(),
                    ischildenable: $("#ischildenable").val(),
                    pkeyex: $("#pkeyex").val(),
                    //masprivatekey: tinymce.get("masprivatekey").getContent(),
                    //maspublickey: tinymce.get("maspublickey").getContent(),
                    //password: tinymce.get("password").getContent(),
                    //passwordsalt: tinymce.get("passwordsalt").getContent(),
                    //passwordkey: tinymce.get("passwordkey").getContent(),
                    //passwordvector: tinymce.get("passwordvector").getContent(),
                    mobilepin: $("#mobilepin").val(),
                    passwordquestion: $("#passwordquestion").val(),
                    passwordanswer: $("#passwordanswer").val(),
                    approved: $("#approved").val(),
                    locked: $("#locked").val(),
                    lastlogindate: $("#lastlogindate").val(),
                    lastpasschangeddate: $("#lastpasschangeddate").val(),
                    lastlockoutdate: $("#lastlockoutdate").val(),
                    failedpasswordattemptcount: $("#failedpasswordattemptcount").val(),
                    //comment: tinymce.get("comment").getContent(),
                    lastactivitydate: $("#lastactivitydate").val(),
                    isapproved: $("#isapproved").val(),
                    approvedby: $("#approvedby").val(),
                    approvedbyusername: $("#approvedbyusername").val(),
                    approveddate: $("#approveddate").val(),
                    isemailconfirmed: $("#isemailconfirmed").val(),
                    emailconfirmationbyuserdate: $("#emailconfirmationbyuserdate").val(),
                    twofactorenable: $("#twofactorenable").val(),
                    ismobilenumberconfirmed: $("#ismobilenumberconfirmed").val(),
                    mobilenumberconfirmedbyuserdate: $("#mobilenumberconfirmedbyuserdate").val(),
                    securitystamp: $("#securitystamp").val(),
                    concurrencystamp: $("#concurrencystamp").val(),
                    webuseronly: $("#webuseronly").val()
                };

                ajaxPostObjectHandler("/Owin_User/EmailResetOwin_User", dataobject, function (response) {
                    console.log(response);
                    if (response._ajaxresponse.responsestatus == "success") {
                        showSuccessAlert("Success", response._ajaxresponse.responsetext, "OK", RedirectToLanding, LandingOwin_User);
                    }
                }, true);
            }

        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });
    $('body').on('click', '#btnUpdateRoleOwin_User', function (e) {
        try {
            event.preventDefault();
            if (_cusFormValidate('frmUpdateRoleOwin_User')) {

                //if (!validateRequiredfldmasprivatekey()) {
                //    return false;
                //}
                //if (!validateRequiredfldmaspublickey()) {
                //    return false;
                //}
                //if (!validateRequiredfldpassword()) {
                //    return false;
                //}
                //if (!validateRequiredfldpasswordsalt()) {
                //    return false;
                //}
                //if (!validateRequiredfldpasswordkey()) {
                //    return false;
                //}
                //if (!validateRequiredfldpasswordvector()) {
                //    return false;
                //}


                var dataobject = {
                    applicationid: $("#applicationid").val(),
                    userid: $("#userid").val(),
                    masteruserid: $("#masteruserid").val(),
                    username: $("#username").val(),
                    emailaddress: $("#emailaddress").val(),
                    loweredusername: $("#loweredusername").val(),
                    mobilenumber: $("#mobilenumber").val(),
                    userprofilephoto: $("#userprofilephoto").val(),
                    isanonymous: $("#isanonymous").val(),
                    ischildenable: $("#ischildenable").val(),
                    pkeyex: $("#pkeyex").val(),
                    //masprivatekey: tinymce.get("masprivatekey").getContent(),
                    //maspublickey: tinymce.get("maspublickey").getContent(),
                    //password: tinymce.get("password").getContent(),
                    //passwordsalt: tinymce.get("passwordsalt").getContent(),
                    //passwordkey: tinymce.get("passwordkey").getContent(),
                    //passwordvector: tinymce.get("passwordvector").getContent(),
                    mobilepin: $("#mobilepin").val(),
                    passwordquestion: $("#passwordquestion").val(),
                    passwordanswer: $("#passwordanswer").val(),
                    approved: $("#approved").val(),
                    locked: $("#locked").val(),
                    lastlogindate: $("#lastlogindate").val(),
                    lastpasschangeddate: $("#lastpasschangeddate").val(),
                    lastlockoutdate: $("#lastlockoutdate").val(),
                    failedpasswordattemptcount: $("#failedpasswordattemptcount").val(),
                    //comment: tinymce.get("comment").getContent(),
                    lastactivitydate: $("#lastactivitydate").val(),
                    isapproved: $("#isapproved").val(),
                    approvedby: $("#approvedby").val(),
                    approvedbyusername: $("#approvedbyusername").val(),
                    approveddate: $("#approveddate").val(),
                    isemailconfirmed: $("#isemailconfirmed").val(),
                    emailconfirmationbyuserdate: $("#emailconfirmationbyuserdate").val(),
                    twofactorenable: $("#twofactorenable").val(),
                    ismobilenumberconfirmed: $("#ismobilenumberconfirmed").val(),
                    mobilenumberconfirmedbyuserdate: $("#mobilenumberconfirmedbyuserdate").val(),
                    securitystamp: $("#securitystamp").val(),
                    concurrencystamp: $("#concurrencystamp").val(),
                    webuseronly: $("#webuseronly").val(),
                    roleid: $("#roleid").val(),
                };

                ajaxPostObjectHandler("/Owin_User/UpdateRoleOwin_User", dataobject, function (response) {
                    console.log(response);
                    if (response._ajaxresponse.responsestatus == "success") {
                        showSuccessAlert("Success", response._ajaxresponse.responsetext, "OK", RedirectToLanding, LandingOwin_User);
                    }
                }, true);
            }

        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });
});