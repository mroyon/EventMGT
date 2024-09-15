/*!
 * Entity Model Wise : Gen_ServiceStatus : functions JavaScript Library v1.0 
 * Copyright Kuwait Armed Forces and other contributors
 * Released under the MIT license
 * https://jquery.org/license
 * Date: 2023/01/04 9:12:37 AM
 * PC: Major Mahmud
 */
 
'use strict';





$(function () {
    var LandingGen_ServiceStatus = "/Gen_ServiceStatus/LandingGen_ServiceStatus";
    function RedirectToLanding(params) {
        if (typeof params != 'undefined')
            window.location.href = params;
    }
    
    $('body').on('click', '#btnAddGen_ServiceStatus', function (e) {
        try {
            event.preventDefault();
            if (_cusFormValidate('frmAddGen_ServiceStatus')) {
            
                
            
                var dataobject = {
                    servicestatusid: $("#servicestatusid").val(),
					servicestatusar: $("#servicestatusar").val(),
					servicestatusen: $("#servicestatusen").val(),
					descriptionar: $("#descriptionar").val(),
					descriptionen: $("#descriptionen").val(),
					isactive: $("#isactive").val()
                };
                ajaxPostObjectHandler("/Gen_ServiceStatus/AddGen_ServiceStatus", dataobject, function (response) {
                    if (response._ajaxresponse.responsestatus == "success") {
                        showSuccessAlert("Success", response._ajaxresponse.responsetext, "OK", RedirectToLanding, LandingGen_ServiceStatus);
                    }
                }, true);
            }

        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });

    $('body').on('click', '#btnEditGen_ServiceStatus', function (e) {
        try {
            event.preventDefault();
            if (_cusFormValidate('frmEditGen_ServiceStatus')) {
            
                
                
                var dataobject = {
                     servicestatusid: $("#servicestatusid").val(),
					servicestatusar: $("#servicestatusar").val(),
					servicestatusen: $("#servicestatusen").val(),
					descriptionar: $("#descriptionar").val(),
					descriptionen: $("#descriptionen").val(),
					isactive: $("#isactive").val()
                };

                ajaxPostObjectHandler("/Gen_ServiceStatus/EditGen_ServiceStatus", dataobject, function (response) {
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

    $('body').on('click', '#btnDeleteGen_ServiceStatus', function (e) {
        try {
            event.preventDefault();
            if (_cusFormValidate('frmDeleteGen_ServiceStatus')) {
                var dataobject = {
                   servicestatusid: $("#servicestatusid").val(),
					servicestatusar: $("#servicestatusar").val(),
					servicestatusen: $("#servicestatusen").val(),
					descriptionar: $("#descriptionar").val(),
					descriptionen: $("#descriptionen").val(),
					isactive: $("#isactive").val()
                };
                ajaxPostObjectHandler("/Gen_ServiceStatus/DeleteGen_ServiceStatus", dataobject, function (response) {
                    if (response._ajaxresponse.responsestatus == "success") {                        
                        showSuccessAlert("Success", response._ajaxresponse.responsetext, "OK", RedirectToLanding, LandingGen_ServiceStatus);
                    }
                }, true);
            }
        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });

    $('body').on('click', '#btnGoBackGen_ServiceStatus', function (e) {
        try {
            event.preventDefault();
            window.location.href = LandingGen_ServiceStatus;
        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });
});