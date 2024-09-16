/*!
 * Entity Model Wise : Gen_EventCategory : functions JavaScript Library v1.0 
 * Copyright Kuwait Armed Forces and other contributors
 * Released under the MIT license
 * https://jquery.org/license
 * Date: 9/15/2024 8:46:32 PM
 * PC: Major Mahmud
 */
 
'use strict';


$(function () {
    var LandingGen_EventCategory = "/Gen_EventCategory/LandingGen_EventCategory";
    function RedirectToLanding(params) {
        if (typeof params != 'undefined')
            window.location.href = params;
    }
    
    $('body').on('click', '#btnAddGen_EventCategory', function (e) {
        try {
            e.preventDefault();
            if (_cusFormValidate('frmAddGen_EventCategory')) {
                var dataobject = {
                    eventcategoryid: $("#eventcategoryid").val(),
                    eventcategory: $("#eventcategory").val(),
                    description: tinymce.get("description").getContent()
                };
                ajaxPostObjectHandler("/Gen_EventCategory/AddGen_EventCategory", dataobject, function (response) {
                    if (response._ajaxresponse.responsestatus == "success") {
                        showSuccessAlert("Success", response._ajaxresponse.responsetext, "OK", RedirectToLanding, LandingGen_EventCategory);
                    }
                }, true);
            }

        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });

    $('body').on('click', '#btnEditGen_EventCategory', function (e) {
        try {
            e.preventDefault();
            if (_cusFormValidate('frmEditGen_EventCategory')) {
                var dataobject = {
                    eventcategoryid: $("#eventcategoryid").val(),
                    eventcategory: $("#eventcategory").val(),
                    description: tinymce.get("description").getContent()
                };

                ajaxPostObjectHandler("/Gen_EventCategory/EditGen_EventCategory", dataobject, function (response) {
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

    $('body').on('click', '#btnDeleteGen_EventCategory', function (e) {
        try {
            e.preventDefault();
            if (_cusFormValidate('frmDeleteGen_EventCategory')) {
                var dataobject = {
                    eventcategoryid: $("#eventcategoryid").val(),
                    eventcategory: $("#eventcategory").val(),
                    description: tinymce.get("description").getContent()
                };
                ajaxPostObjectHandler("/Gen_EventCategory/DeleteGen_EventCategory", dataobject, function (response) {
                    if (response._ajaxresponse.responsestatus == "success") {                        
                        showSuccessAlert("Success", response._ajaxresponse.responsetext, "OK", RedirectToLanding, LandingGen_EventCategory);
                    }
                }, true);
            }
        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });

    $('body').on('click', '#btnGoBackGen_EventCategory', function (e) {
        try {
            e.preventDefault();
            window.location.href = LandingGen_EventCategory;
        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });
});