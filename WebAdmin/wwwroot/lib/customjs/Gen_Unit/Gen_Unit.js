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
    var LandingGen_Unit = "/Gen_Unit/LandingGen_Unit";
    function RedirectToLanding(params) {
        if (typeof params != 'undefined')
            window.location.href = params;
    }

    $('body').on('click', '#btnAddGen_Unit', function (e) {
        try {
            e.preventDefault();
            if (_cusFormValidate('frmAddGen_Unit')) {               
                var formData = new FormData();
                formData.append('unitid', $('#unitid').val());
                formData.append('unit', $('#unit').val());
                formData.append('unitcode', $('#unitcode').val());
                formData.append('file', $('#file')[0].files[0]);
                
                ajaxPostObjectHandlerWithFiles("/Gen_Unit/AddGen_Unit", formData, function (response) {
                    if (response._ajaxresponse.responsestatus == "success") {
                        showSuccessAlert("Success", response._ajaxresponse.responsetext, "OK", RedirectToLanding, LandingGen_Unit);
                    }
                }, false);
            }

        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });

    $('body').on('click', '#btnEditGen_Unit', function (e) {
        try {
            e.preventDefault();
            if (_cusFormValidate('frmEditGen_Unit')) {


                var formData = new FormData();
                formData.append('unitid', $('#unitid').val());
                formData.append('unit', $('#unit').val());
                formData.append('unitcode', $('#unitcode').val());
                formData.append('ex_nvarchar3', $('#ex_nvarchar3').val());
                formData.append('file', $('#file')[0].files[0]);

                ajaxPostObjectHandlerWithFiles("/Gen_Unit/EditGen_Unit", formData, function (response) {
                    console.log(response);
                    if (response._ajaxresponse.responsestatus == "success") {
                        showSuccessAlert("Success", response._ajaxresponse.responsetext, "OK", RedirectToLanding, LandingGen_Unit);
                    }
                }, false);
            }

        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });

    $('body').on('click', '#btnDeleteGen_Unit', function (e) {
        try {
            e.preventDefault();
            if (_cusFormValidate('frmDeleteGen_Unit')) {
                var dataobject = {
                    unitid: $("#unitid").val(),
                    unit: $("#unit").val(),
                    unitcode: $("#unitcode").val(),
                    ex_nvarchar1: $('#myImage').attr('src'),
                    ex_nvarchar3: $("#ex_nvarchar3").val()
                };
                ajaxPostObjectHandler("/Gen_Unit/DeleteGen_Unit", dataobject, function (response) {
                    if (response._ajaxresponse.responsestatus == "success") {
                        showSuccessAlert("Success", response._ajaxresponse.responsetext, "OK", RedirectToLanding, LandingGen_Unit);
                    }
                }, true);
            }
        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });

    $('body').on('click', '#btnGoBackGen_Unit', function (e) {
        try {
            e.preventDefault();
            window.location.href = LandingGen_Unit;
        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });
});