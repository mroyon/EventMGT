

'use strict';

$(function () {
    var LandingKns_Batch = "/RolePermission/LandingOwin_RolePermission";
    function RedirectToLanding(params) {
        if (typeof params != 'undefined')
            window.location.href = params;
    }
    LoadActionList();

    $('body').on('change', '#roleid', function (e) {
        try {
            //console.log($('#roleid').val());
            $('.dvActionPanel').html('');

            var dataobject = {
                roleid: $("#roleid").val()
            };
            ajaxPostObjectHandler("/RolePermission/LoadRolePermission", dataobject, function (response) {
                //if (response._ajaxresponse.responsestatus == "success") {
                //showSuccessAlert("Success", response._ajaxresponse.responsetext, "OK", RedirectToLanding, LandingKns_Batch);
                //console.log($.parseJSON(response.ContentResult.Content)._menuwiseform);
                var res = $.parseJSON(response.ContentResult.Content)._menuwiseform;

                var root = 0;
                for (var i = 0; i < res.length; i++) {
                    var d = "<div id='accordion" + ++root + "' class='accordion permissionCard'>" +
                        "<div class='card'>" +
                        "<div class='card-header' id='mheading" + root + "'>" +
                        "<h5>" +
                        "<a role='button' class='btn btn-link root collapsed col-md-4' data-bs-toggle='collapse' data-bs-target='#mcollapse" + root + "' aria-expanded='false' aria-controls='mcollapse" + root + "' style='text-align: left;'>" + "<span class='px-1'></span>" + res[i].formname + "</a>" +
                        "<label class=''><input type='checkbox' id='rootCheckAll' />" + "Select All" + "</label>" +
                        "</h5>" +
                        "</div>" +
                        "<div id='mcollapse" + root + "' class='collapse ' aria-labelledby='mheading" + root + "' data-parent='#mheading" + root + "'>" +
                        "<div class='card-body'>";
                    var formlist = res[i].formList;
                    for (var j = 0; j < formlist.length; j++) {
                        d += "<div class='card'>" +
                            "<div class='card-header' id='heading" + formlist[j].appformid + "'>" +
                            "<h6> " +
                            "<a role='button' class='btn btn-link root collapsed col-md-4' data-bs-toggle='collapse' data-bs-target='#collapse" + formlist[j].appformid + "' aria-expanded='false' aria-controls='collapse" + formlist[j].appformid + "' style='text-align: left;'>" + "<span class='px-1'></span>" + formlist[j].formname + "</a>" +
                            "<label class=''><input type='checkbox' id='checkAll' />" + "Select All" + "</label>" +
                            "</h6>" +
                            "</div>" +
                            "<div id='collapse" + formlist[j].appformid + "' class='collapse' aria-labelledby='heading" + formlist[j].appformid + "' data-parent='#accordion" + root + "'>" +
                            "<div class='card-body'>" +
                            "<div class='row'>";
                        var formActionList = formlist[j].formActionList;
                        for (var k = 0; k < formActionList.length; k++) {
                            var isview = (formActionList[k].isview) ? "checked" : "";

                            d += "<div class='col-md-4'>" +
                                "<label class='text-break'>" +
                                "<input type='checkbox' class='actionid' value='" + formActionList[k].formactionid + "' " + isview + ">" + formActionList[k].actionname +
                                "</label>" +
                                "</div>";
                        }
                        d += "</div>" +
                            "</div>" +
                            "</div>" +
                            "</div>";
                    }
                    d += "</div>" +
                        "</div>" +
                        "</div>" +
                        "</div>" +
                        "</div>";

                    //console.log(d);
                    //console.log("next");

                    $('.dvActionPanel').append(d);
                }
            }, true);

        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });

    $('body').on('click', '#btnAddOwin_RolePermission', function (e) {
        try {
            event.preventDefault();
            if (_cusFormValidate('frmAddOwin_RolePermission')) {

                var actionlistArray = [];
                $("div[class*='permissionCard']").each(function () {
                    $(this).find("div[class*='card']").each(function () {
                        var formid = $(this).find(".formid").attr("data-val");

                        $(this).find('input.actionid[type="checkbox"]:checked').each(function (index) {
                            var actionid = $(this).val();
                            actionlistArray.push(parseInt(actionid));
                        });
                    });
                });
                var strActionList = JSON.stringify(actionlistArray);
                console.log(strActionList.substring(1, strActionList.length - 1));

                var dataobject = {
                    roleid: $("#roleid").val(),
                    ActionName: strActionList.substring(1, strActionList.length - 1)
                };

                ajaxPostObjectHandler("/RolePermission/AssignOwin_RolePermission", dataobject, function (response) {
                    if (response._ajaxresponse.responsestatus == "success") {
                        showSuccessAlert("Success", response._ajaxresponse.responsetext, "OK", RedirectToLanding, LandingKns_Batch);
                    }
                }, true);
            }

        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });

    $('body').on('change', '#checkAll', function (event) {
        if ($(this).is(':checked')) {
            //var t = $(this).parent().parent().parent().parent().parent();
            $(this).parent().parent().parent().parent().find('input[type="checkbox"]').each(function () {
                $(this).prop('checked', true);
            })
        }
        else {
            $(this).parent().parent().parent().parent().find('input[type="checkbox"]').each(function () {
                $(this).prop('checked', false);
            })

        }
    });
    $('body').on('change', '#rootCheckAll', function (event) {
        if ($(this).is(':checked')) {
            //var t = $(this).parent().parent().parent().parent().parent();
            $(this).parent().parent().parent().parent().parent().find('input[type="checkbox"]').each(function () {
                $(this).prop('checked', true);
            })
        }
        else {
            $(this).parent().parent().parent().parent().parent().find('input[type="checkbox"]').each(function () {
                $(this).prop('checked', false);
            })

        }
    });
});

function LoadActionList() {
    //console.log($('#roleid').val());
    $('.dvActionPanel').html('');

    var dataobject = {
        roleid: $("#roleid").val()
    };
    ajaxPostObjectHandler("/RolePermission/LoadRolePermission", dataobject, function (response) {
        //if (response._ajaxresponse.responsestatus == "success") {
        //showSuccessAlert("Success", response._ajaxresponse.responsetext, "OK", RedirectToLanding, LandingKns_Batch);
        //console.log($.parseJSON(response.ContentResult.Content)._menuwiseform);
        var res = $.parseJSON(response.ContentResult.Content)._menuwiseform;

        var root = 0;
        for (var i = 0; i < res.length; i++) {
            var d = "<div id='accordion" + ++root + "' class='accordion permissionCard'>" +
                "<div class='card'>" +
                "<div class='card-header' id='mheading" + root + "'>" +
                "<h5>" +
                "<a role='button' class='btn btn-link root collapsed col-md-4' data-bs-toggle='collapse' data-bs-target='#mcollapse" + root + "' aria-expanded='false' aria-controls='mcollapse" + root + "' style='text-align: left;'>" + "<span class='px-1'></span>" + res[i].formname + "</a>" +
                "<label class=''><input type='checkbox' id='rootCheckAll' />" + "Select All" + "</label>" +
                "</h5>" +
                "</div>" +
                "<div id='mcollapse" + root + "' class='collapse ' aria-labelledby='mheading" + root + "' data-parent='#mheading" + root + "'>" +
                "<div class='card-body'>";
            var formlist = res[i].formList;
            for (var j = 0; j < formlist.length; j++) {
                d += "<div class='card'>" +
                    "<div class='card-header' id='heading" + formlist[j].appformid + "'>" +
                    "<h6> " +
                    /*"<button class='btn btn-link' data-toggle='collapse' data-target='#collapse" + formlist[j].appformid + "' aria-expanded='true' aria-controls='collapse" + formlist[j].appformid + "'>" + formlist[j].formname + "</button>" +*/
                    "<a role='button' class='btn btn-link root collapsed col-md-4' data-bs-toggle='collapse' data-bs-target='#collapse" + formlist[j].appformid + "' aria-expanded='false' aria-controls='collapse" + formlist[j].appformid + "'style='text-align: left;'>" + "<span class='px-1'></span>" + formlist[j].formname + "</a>" +
                    "<label class=''><input type='checkbox' id='checkAll' />" + "Select All" + "</label>" +
                    "</h6>" +
                    "</div>" +
                    "<div id='collapse" + formlist[j].appformid + "' class='collapse' aria-labelledby='heading" + formlist[j].appformid + "' data-parent='#accordion" + root + "'>" +
                    "<div class='card-body'>" +
                    "<div class='row'>";
                var formActionList = formlist[j].formActionList;
                for (var k = 0; k < formActionList.length; k++) {
                    var isview = (formActionList[k].isview) ? "checked" : "";

                    d += "<div class='col-md-4'>" +
                        "<label class='text-break'>" +
                        "<input type='checkbox' class='actionid' value='" + formActionList[k].formactionid + "' " + isview + ">" + formActionList[k].actionname +
                        "</label>" +
                        "</div>";
                }
                d += "</div>" +
                    "</div>" +
                    "</div>" +
                    "</div>";
            }
            d += "</div>" +
                "</div>" +
                "</div>" +
                "</div>" +
                "</div>";

            //console.log(d);
            //console.log("next");

            $('.dvActionPanel').append(d);
        }
    }, true);
}