/*!
 * Entity Model Wise : Gen_UserUnit : functions JavaScript Library v1.0 
 * Copyright Kuwait Armed Forces and other contributors
 * Released under the MIT license
 * https://jquery.org/license
 * Date: 9/15/2024 8:46:32 PM
 * PC: Major Mahmud
 */
 
'use strict';





$(function () {
    var LandingGen_UserUnit = "/Gen_UserUnit/LandingGen_UserUnit";
    function RedirectToLanding(params) {
        if (typeof params != 'undefined')
            window.location.href = params;
    }
    
    $('body').on('click', '#btnAddGen_UserUnit', function (e) {
        try {
            e.preventDefault();
            if (_cusFormValidate('frmAddGen_UserUnit')) {
            
                
            
                var dataobject = {
                    serial: $("#serial").val(),
					unitid: $("#unitid").val(),
					//userid: $("#userid").val(),
                    masteruserid: $("#masteruserid").val(),
					//ex_nvarchar3: $("#ex_nvarchar3").val()
                };
                ajaxPostObjectHandler("/Gen_UserUnit/AddGen_UserUnit", dataobject, function (response) {
                    if (response._ajaxresponse.responsestatus == "success") {
                        showSuccessAlert("Success", response._ajaxresponse.responsetext, "OK", RedirectToLanding, LandingGen_UserUnit);
                    }
                }, true);
            }

        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });

    $('body').on('click', '#btnEditGen_UserUnit', function (e) {
        try {
            e.preventDefault();
            if (_cusFormValidate('frmEditGen_UserUnit')) {
            
                
                
                var dataobject = {
                     serial: $("#serial").val(),
					unitid: $("#unitid").val(),
                    //userid: $("#userid").val(),
                    masteruserid: $("#masteruserid").val(),
					//ex_nvarchar3: $("#ex_nvarchar3").val()
                };

                ajaxPostObjectHandler("/Gen_UserUnit/EditGen_UserUnit", dataobject, function (response) {
                    console.log(response);
                    if (response._ajaxresponse.responsestatus == "success") {
                        showSuccessAlert("Success", response._ajaxresponse.responsetext, "OK", RedirectToLanding, LandingGen_UserUnit);
                    }
                }, true);
            }

        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });

    $('body').on('click', '#btnDeleteGen_UserUnit', function (e) {
        try {
            event.preventDefault();
            if (_cusFormValidate('frmDeleteGen_UserUnit')) {
                var dataobject = {
                   serial: $("#serial").val(),
					unitid: $("#unitid").val(),
					userid: $("#userid").val(),
					ex_nvarchar3: $("#ex_nvarchar3").val()
                };
                ajaxPostObjectHandler("/Gen_UserUnit/DeleteGen_UserUnit", dataobject, function (response) {
                    if (response._ajaxresponse.responsestatus == "success") {                        
                        showSuccessAlert("Success", response._ajaxresponse.responsetext, "OK", RedirectToLanding, LandingGen_UserUnit);
                    }
                }, true);
            }
        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });

    $('body').on('click', '#btnGoBackGen_UserUnit', function (e) {
        try {
            event.preventDefault();
            window.location.href = LandingGen_UserUnit;
        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });
});