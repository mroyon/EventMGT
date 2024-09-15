/******************************************
 * My Login
 *
 * Bootstrap 4 Login Page
 *
 ******************************************/

'use strict';

$(function () {




    $('body').on('click', '#btnlogin', function (e) {
        try {
            event.preventDefault();

            
            if (connectionusercontextQR != null ) {
                connectionusercontextQR.stop().then(function () {
                    console.log('Closed');
                    connectionusercontextQR = null;

                });
            }

            if (connectionusercontextCivil != null) {
                connectionusercontextCivil.stop().then(function () {
                    console.log('Closed');
                    connectionusercontextCivil = null;

                });
            }

            if (_cusFormValidate('frmlogin')) {
                var dataobject = { emailaddress: $("#emailaddress").val(), password: $("#password").val() };
                ajaxPostObjectHandler("/Account/Login", dataobject, function (response) {

                    console.log($.parseJSON(response.Content)._ajaxresponse.responsetext)

                    if (response.StatusCode == "200") {
                        showSuccessAlert("Success", $.parseJSON(response.Content)._ajaxresponse.responsetext, "OK");
                        window.location.reload();
                    }
                    else {
                        showErrorAlert($.parseJSON(response.Content)._ajaxresponse.responsetitle, $.parseJSON(response.Content)._ajaxresponse.responsetext, "OK");
                    }

                }, true);

            }
        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });


    $('body').on('click', '#btnforgetpassword', function (e) {
        try {
            event.preventDefault();

            if (_cusFormValidate('frmforgetpassword')) {
                var dataobject = { emailaddress: $("#emailaddress").val() };
                ajaxPostObjectHandler("/Account/ForgetPassword", dataobject, function (response) {
                }, true);
            }
        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });

    $('body').on('click', '#btnforgetpasswordCancel', function (e) {
        try {
            event.preventDefault();
            window.location.href = "/Account/Login";
        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });

    $('body').on('click', '#btnresetpassword', function (e) {
        try {
            event.preventDefault();
            if (_cusFormValidate('frmresetpassword')) {
                var dataobject = {
                    emailaddress: $("#emailaddress").val(),
                    newpassword: $("#newpassword").val(),
                    confirmpassword: $("#confirmpassword").val(),
                    password: $("#code").val()
                };

                ajaxPostObjectHandler("/Account/PasswordResetPost", dataobject, function (response) {

                }, true);
            }
        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });


    var fullHeight = function () {

        $('.js-fullheight').css('height', $(window).height());
        $(window).resize(function () {
            $('.js-fullheight').css('height', $(window).height()+100);
        });
    };
    fullHeight();

    $(".toggle-password").click(function () {
       
        $(this).toggleClass("fa-eye fa-eye-slash");
        var input = $($(this).attr("toggle"));
        if (input.attr("type") == "password") {
            input.attr("type", "text");
        } else {
            input.attr("type", "password");
        }
    });
    $("button").click(function () {
        $("p").toggle();
    });
    //$(".my-forgetpass-validation").submit(function () {

    //	var form = $(this);
    //	if (form[0].checkValidity() === false) {
    //		event.preventDefault();
    //		event.stopPropagation();
    //	}
    //	form.addClass('was-validated');
    //});

});

(function ($) {

    "use strict";


})(jQuery);

