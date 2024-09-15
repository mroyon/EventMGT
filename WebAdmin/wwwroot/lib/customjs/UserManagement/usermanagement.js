/******************************************
 * usermanagement
 * All function related with User Management
 ******************************************/
/*!
 * usermanagement JavaScript Library v1.0
 *
 *
 * Copyright KAF Foundation and other contributors
 * https://jquery.org/license
 *
 * Date: 2021-03-02T17:08Z
 */

'use strict';


$(function () {
    $('body').on('click', '#btnAddUser', function (e) {
        try {
            event.preventDefault();

            if (_cusFormValidate('frmadduser')) {

                var dataobject = {
                    applicationid: $('#applicationid').val(),
                    userid: $('#userid').val(),
                    masteruserid: $('#masteruserid').val(),
                    username: $('#username').val(),
                    emailaddress: $('#emailaddress').val(),
                    loweredusername: $('#loweredusername').val(),
                    mobilenumber: $('#mobilenumber').val(),
                    isanonymous: $('#isanonymous').val(),
                    masprivatekey: $('#masprivatekey').val(),
                    maspublickey: $('#maspublickey').val(),

                    password: $('#newpassword').val(),
                    newpassword: $('#newpassword').val(),
                    passwordsalt: $('#passwordsalt').val(),
                    passwordkey: $('#passwordkey').val(),
                    passwordvector: $('#passwordvector').val(),

                    passwordquestion: $('#passwordquestion').val(),
                    passwordanswer: $('#passwordanswer').val(),

                };
                ajaxPostObjectHandler("/Account/CreateUser", dataobject, function (response) {
                    window.location.reload();
                }, true);
            }

        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });

    $('body').on('click', '#btnUpdateUser', function (e) {
        try {
            event.preventDefault();

            if (_cusFormValidate('frmupdateuser')) {

                var dataobject = {
                    applicationid: $('#applicationid').val(),
                    userid: $('#userid').val(),
                    masteruserid: $('#masteruserid').val(),
                    username: $('#username').val(),
                    emailaddress: $('#emailaddress').val(),
                    loweredusername: $('#loweredusername').val(),
                    mobilenumber: $('#mobilenumber').val(),
                    isanonymous: $('#isanonymous').val(),
                };
                ajaxPostObjectHandler("/Account/UpdateAccount", dataobject, function (response) {
                    window.location.reload();
                }, true);
            }

        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });
});