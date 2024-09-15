/*!
 * Entity Model Wise : Gen_EventInfo : functions JavaScript Library v1.0 
 * Copyright Kuwait Armed Forces and other contributors
 * Released under the MIT license
 * https://jquery.org/license
 * Date: 9/11/2024 1:36:34 PM
 * PC: Major Mahmud
 */

'use strict';

function validateRequiredfldeventname() {
    $('#eventnameerror').hide();
    $('#eventnameerror').html('');
    if (tinymce.get("eventname").getContent() == '') {
        var eventnameMsg = $('#eventname').attr('data-val-required');
        $('#eventnameerror').show();
        $('#eventnameerror').html(eventnameMsg);
        return false;
    }

}





$(function () {
    var LandingGen_EventInfo = "/Gen_EventInfo/LandingGen_EventInfo";
    function RedirectToLanding(params) {
        if (typeof params != 'undefined')
            window.location.href = params;
    }

    //$('body').on('click', '#btnAddGen_EventInfo', function (e) {
    //    try {
    //        event.preventDefault();
    //        if (_cusFormValidate('frmAddGen_EventInfo')) {
    //            var dataobject = {
    //                eventid: $("#eventid").val(),
    //                eventcategoryid: $("#eventcategoryid").val(),
    //                eventcode: $("#eventcode").val(),
    //                eventname: $("#eventname").val(),
    //                eventstartdate:GetDateFromTextBox( $("#eventstartdate").val()),
    //                eventenddate:GetDateFromTextBox( $("#eventenddate").val()),
    //                eventdescription: tinymce.get("eventdescription").getContent(),
    //                eventdescription1: tinymce.get("eventdescription1").getContent(),
    //                eventdescription2: tinymce.get("eventdescription2").getContent(),
    //                eventspecialnote: tinymce.get("eventspecialnote").getContent(),
    //                eventorganizedby: $("#eventorganizedby").val(),
    //            };
    //            ajaxPostObjectHandler("/Gen_EventInfo/AddGen_EventInfo", dataobject, function (response) {
    //                if (response._ajaxresponse.responsestatus == "success") {
    //                    showSuccessAlert("Success", response._ajaxresponse.responsetext, "OK", RedirectToLanding, LandingGen_EventInfo);
    //                }
    //            }, true);
    //        }
    //    }

    //    catch (e) {
    //        showErrorAlert("Error", e.message, "OK");
    //    }
    //});

    //$('body').on('click', '#btnEditGen_EventInfo', function (e) {
    //    try {
    //        event.preventDefault();
    //        if (_cusFormValidate('frmEditGen_EventInfo')) {


    //            var dataobject = {
    //                eventid: $("#eventid").val(),
    //                eventcategoryid: $("#eventcategoryid").val(),
    //                eventcode: $("#eventcode").val(),
    //                eventname: $("#eventname").val(),
    //                eventstartdate:GetDateFromTextBox( $("#eventstartdate").val()),
    //                eventenddate:GetDateFromTextBox( $("#eventenddate").val()),
    //                eventdescription: tinymce.get("eventdescription").getContent(),
    //                eventdescription1: tinymce.get("eventdescription1").getContent(),
    //                eventdescription2: tinymce.get("eventdescription2").getContent(),
    //                eventspecialnote: tinymce.get("eventspecialnote").getContent(),
    //                eventorganizedby: $("#eventorganizedby").val(),
    //            };

    //            ajaxPostObjectHandler("/Gen_EventInfo/EditGen_EventInfo", dataobject, function (response) {
    //                console.log(response);
    //                if (response._ajaxresponse.responsestatus == "success") {
    //                    showSuccessAlert("Success", response._ajaxresponse.responsetext, "OK");
    //                }
    //            }, true);
    //        }
    //    } catch (e) {
    //        showErrorAlert("Error", e.message, "OK");
    //    }
    //});

    $('body').on('click', '#btnDeleteGen_EventInfo', function (e) {
        try {
            event.preventDefault();
            if (_cusFormValidate('frmDeleteGen_EventInfo')) {
                var dataobject = {
                     eventid: $("#eventid").val(),
                    eventcategoryid: $("#eventcategoryid").val(),
                    eventcode: $("#eventcode").val(),
                    eventname: $("#eventname").val(),
                    eventstartdate:GetDateFromTextBox( $("#eventstartdate").val()),
                    eventenddate:GetDateFromTextBox( $("#eventenddate").val()),
                    eventdescription: tinymce.get("eventdescription").getContent(),
                    eventdescription1: tinymce.get("eventdescription1").getContent(),
                    eventdescription2: tinymce.get("eventdescription2").getContent(),
                    eventspecialnote: tinymce.get("eventspecialnote").getContent(),
                    eventorganizedby: $("#eventorganizedby").val(),
                };
                ajaxPostObjectHandler("/Gen_EventInfo/DeleteGen_EventInfo", dataobject, function (response) {
                    if (response._ajaxresponse.responsestatus == "success") {
                        showSuccessAlert("Success", response._ajaxresponse.responsetext, "OK", RedirectToLanding, LandingGen_EventInfo);
                    }
                }, true);
            }
        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });

    $('body').on('click', '#btnGoBackGen_EventInfo', function (e) {
        try {
            event.preventDefault();
            window.location.href = LandingGen_EventInfo;
        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });
});