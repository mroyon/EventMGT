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

    //$('body').on('click', '#btnAddGen_Unit', function (e) {
    //    try {
    //        event.preventDefault();
    //        if (_cusFormValidate('frmAddGen_Unit')) {



    //            var dataobject = {
    //                unitid: $("#unitid").val(),
    //                unit: $("#unit").val(),
    //                unitcode: $("#unitcode").val(),
    //                ex_nvarchar3: $("#ex_nvarchar3").val()
    //            };
    //            ajaxPostObjectHandler("/Gen_Unit/AddGen_Unit", dataobject, function (response) {
    //                if (response._ajaxresponse.responsestatus == "success") {
    //                    showSuccessAlert("Success", response._ajaxresponse.responsetext, "OK", RedirectToLanding, LandingGen_Unit);
    //                }
    //            }, true);
    //        }

    //    } catch (e) {
    //        showErrorAlert("Error", e.message, "OK");
    //    }
    //});

    $('body').on('click', '#btnEditGen_Unit', function (e) {
        try {
            event.preventDefault();
            if (_cusFormValidate('frmEditGen_Unit')) {



                var dataobject = {
                    unitid: $("#unitid").val(),
                    unit: $("#unit").val(),
                    unitcode: $("#unitcode").val(),
                    ex_nvarchar3: $("#ex_nvarchar3").val()
                };

                ajaxPostObjectHandler("/Gen_Unit/EditGen_Unit", dataobject, function (response) {
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

    $('body').on('click', '#btnDeleteGen_Unit', function (e) {
        try {
            event.preventDefault();
            if (_cusFormValidate('frmDeleteGen_Unit')) {
                var dataobject = {
                    unitid: $("#unitid").val(),
                    unit: $("#unit").val(),
                    unitcode: $("#unitcode").val(),
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
            event.preventDefault();
            window.location.href = LandingGen_Unit;
        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });
});