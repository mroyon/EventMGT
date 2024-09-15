/*!
 * Entity Model Wise : Owin_Role : functions JavaScript Library v1.0 
 * Copyright Kuwait Armed Forces and other contributors
 * Released under the MIT license
 * https://jquery.org/license
 * Date: 2022/08/14 10:37:07 AM
 * PC: Major Mahmud
 */
 
'use strict';





$(function () {
    var LandingOwin_Role = "/Owin_Role/LandingOwin_Role";
    function RedirectToLanding(params) {
        if (typeof params != 'undefined')
            window.location.href = params;
    }
    
    $('body').on('click', '#btnAddOwin_Role', function (e) {
        try {
            event.preventDefault();
            if (_cusFormValidate('frmAddOwin_Role')) {
            
                
            
                var dataobject = {
                    roleid: $("#roleid").val(),
					rolename: $("#rolename").val(),
                    isactive: $("#isactive").val(),
					description: tinymce.get("description").getContent()
                };
                console.log(dataobject);
                ajaxPostObjectHandler("/Owin_Role/AddOwin_Role", dataobject, function (response) {
                    if (response._ajaxresponse.responsestatus == "success") {
                        showSuccessAlert("Success", response._ajaxresponse.responsetext, "OK", RedirectToLanding, LandingOwin_Role);
                    }
                }, true);
            }

        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });

    $('body').on('click', '#btnEditOwin_Role', function (e) {
        try {
            event.preventDefault();
            if (_cusFormValidate('frmEditOwin_Role')) {
            
                
                
                var dataobject = {
                     roleid: $("#roleid").val(),
                    rolename: $("#rolename").val(),
                    isactive: $("#isactive").val(),
					description: tinymce.get("description").getContent()
                };

                ajaxPostObjectHandler("/Owin_Role/EditOwin_Role", dataobject, function (response) {
                    console.log(response);
                    if (response._ajaxresponse.responsestatus == "success") {
                        showSuccessAlert("Success", response._ajaxresponse.responsetext, "OK", RedirectToLanding, LandingOwin_Role);
                    }
                }, true);
            }

        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });

    $('body').on('click', '#btnDeleteOwin_Role', function (e) {
        try {
            event.preventDefault();
            if (_cusFormValidate('frmDeleteOwin_Role')) {
                var dataobject = {
                   roleid: $("#roleid").val(),
                    rolename: $("#rolename").val(),
                    isactive: $("#isactive").val(),
					description: tinymce.get("description").getContent()
                };
                ajaxPostObjectHandler("/Owin_Role/DeleteOwin_Role", dataobject, function (response) {
                    if (response._ajaxresponse.responsestatus == "success") {                        
                        showSuccessAlert("Success", response._ajaxresponse.responsetext, "OK", RedirectToLanding, LandingOwin_Role);
                    }
                }, true);
            }
        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });

    $('body').on('click', '#btnGoBackOwin_Role', function (e) {
        try {
            event.preventDefault();
            window.location.href = LandingOwin_Role;
        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });
});