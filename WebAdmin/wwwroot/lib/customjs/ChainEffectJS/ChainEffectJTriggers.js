/*!
 * Entity Model Wise : ConfigSMSGateway : functions JavaScript Library v1.0 
 * Copyright Kuwait Armed Forces and other contributors
 * Released under the MIT license
 * https://jquery.org/license
 * Date: 12/19/2021 10:42:19 AM
 * PC: Major Mahmud
 */

'use strict';


//Load View Components

function PostNotificationNewToMongoDB(popmessage, objpopmsgstr, callback) {
    try {

        var obj = JSON.parse(objpopmsgstr);

        var dataobject = {
            id: obj.Id,
            from: obj.From,
            to: obj.To,
            subject: obj.Subject,
            entrydate: obj.EntryDate,
            isread: obj.IsRead,
            msgbox: popmessage,
            DocType: obj.DocType
        };

        ajaxPostObjectHandler("/MsgPushPop/AddPushPopMSG", dataobject, function (response) {
            callback(response);
        }, true);

    } catch (e) {
        showErrorAlert("Error", e.message, "موافق");
    }
}

function PostNotificationNewToMongoDBOfflineUser(listtuplelist, popmessage, objpopmsgstr, callback) {
    try {

        var obj = JSON.parse(objpopmsgstr);

        var dataobjectList =  new Array();

        $.each(listtuplelist, function (index, value) {
            var dataobject = {
                id: obj.Id,
                from: obj.From,
                to: value,
                subject: obj.Subject,
                entrydate: obj.EntryDate,
                isread: obj.IsRead,
                msgbox: popmessage
            };
            dataobjectList.push(dataobject);
        });

        var PopMsgJsonExt = {
            serial: "objlist",
            objlist: dataobjectList
        };


        ajaxPostObjectHandler("/MsgPushPop/AddPushPopMSGOffLine", PopMsgJsonExt, function (response) {
            callback(response);
        }, true);

    } catch (e) {
        showErrorAlert("Error", e.message, "موافق");
    }

}



function PostNotificationReadToMongoDB(BsonID) {

    try {
        var dataobject = {
            id: BsonID
        };

        ajaxPostObjectHandler("/MsgPushPop/UpdatePushPopMSG", dataobject,
            function (response) {

            }, true);

        swal.close();

    } catch (e) {
        showErrorAlert("Error", e.message, "موافق");
    }

}

function Load_InboxContainer() {
    try {

        ajaxGetHandler("/DashboardHome/GetInboxContainer",
            null,
            function (data) {
                if ($('#dvInboxContainer').length > 0 && data.trim().length > 0) {
                    $('#dvInboxContainer').html(data);
                }
                else {
                    $('#dvInboxContainer').html("");
                }

            }, false, false);

    } catch (e) {
        showErrorAlert("Error", e.message, "موافق");
    }
}

function Load_OutboContainer() {
    try {

        ajaxGetHandler("/DashboardHome/GetOutboContainer",
            null,
            function (data) {
                if ($('#dvOutboxContainer').length > 0 && data.trim().length > 0) {
                    $('#dvOutboxContainer').html(data);
                }
                else {
                    $('#dvOutboxContainer').html("");
                }

            }, false, false);

    } catch (e) {
        showErrorAlert("Error", e.message, "موافق");
    }
}

function Load_DraftContainer() {
    try {

        ajaxGetHandler("/DashboardHome/GetDraftContainer",
            null,
            function (data) {
                if ($('#dvDratContainer').length > 0 && data.trim().length > 0) {
                    $('#dvDratContainer').html(data);
                }
                else {
                    $('#dvDratContainer').html("");
                }

            }, false, false);

    } catch (e) {
        showErrorAlert("Error", e.message, "موافق");
    }
}

function Load_MemoStatContainer() {
    try {

        ajaxGetHandler("/DashboardHome/GetMemoStatContainer",
            null,
            function (data) {
                if ($('#dvMemoStatContainer').length > 0 && data.trim().length > 0) {
                    $('#dvMemoStatContainer').html(data);
                }
                else {
                    $('#dvMemoStatContainer').html("");
                }

            }, false, false);

    } catch (e) {
        showErrorAlert("Error", e.message, "موافق");
    }
}

function Load_KitabStatContainer() {
    try {

        ajaxGetHandler("/DashboardHome/GetKitabStatContainer",
            null,
            function (data) {
                if ($('#dvKitabStatContainer').length > 0 && data.trim().length > 0) {
                    $('#dvKitabStatContainer').html(data);
                }
                else {
                    $('#dvKitabStatContainer').html("");
                }

            }, false, false);

    } catch (e) {
        showErrorAlert("Error", e.message, "موافق");
    }
}

function Load_BarChartContainer() {
    try {

        ajaxGetHandler("/DashboardHome/GetBarChartContainer",
            null,
            function (data) {
                if ($('#dvBarChartContainer').length > 0 && data.trim().length > 0) {
                    $('#dvBarChartContainer').html(data);
                }
                else {
                    $('#dvBarChartContainer').html("");
                }

            }, false, false);

    } catch (e) {
        showErrorAlert("Error", e.message, "موافق");
    }
}

function Load_PieChartContainer() {
    try {

        ajaxGetHandler("/DashboardHome/GetPieChartContainer",
            null,
            function (data) {
                if ($('#dvPieChartContainer').length > 0 && data.trim().length > 0) {
                    $('#dvPieChartContainer').html(data);
                }
                else {
                    $('#dvPieChartContainer').html("");
                }

            }, false, false);

    } catch (e) {
        showErrorAlert("Error", e.message, "موافق");
    }
}

function Load_EmailClassification() {
    try {

        ajaxGetHandler("/DashboardHome/GetEmailClassification",
            null,
            function (data) {
                if ($('#dvEmailClassification').length > 0 && data.trim().length > 0) {
                    $('#dvEmailClassification').html(data);
                }
                else {
                    $('#dvEmailClassification').html("");
                }

            }, false, false);

    } catch (e) {
        showErrorAlert("Error", e.message, "موافق");
    }
}

//Bottom part
function LoadBottomViewComponents() {

    Load_InboxContainer();

    Load_OutboContainer();

    Load_DraftContainer();

    Load_MemoStatContainer();

    Load_KitabStatContainer();

    Load_BarChartContainer();

    Load_PieChartContainer();

    Load_EmailClassification();
}

function Load_InboxTopMenuContainer() {
    try {

        ajaxGetHandler("/DashboardHome/GetInboxTopMenuContainer",
            null,
            function (data) {
                if ($('#dvtoplinkinbox').length > 0 && $(data).find("#lnktoplinkinbox").parent().length > 0) {
                    if ($(data).find("#lnktoplinkinbox").parent().html().length > 0) {
                        $('#dvtoplinkinbox').html($(data).find("#lnktoplinkinbox").parent().html());
                    }
                    else {
                        $('#dvtoplinkinbox').html('');
                    }
                }
                else {
                    $('#dvtoplinkinbox').html('');
                }

            }, false, false);

    } catch (e) {
        showErrorAlert("Error", e.message, "موافق");
    }
}

function Load_OutboxTopMenuContainer() {
    try {
        ajaxGetHandler("/DashboardHome/GetOutboxTopMenuContainer",
            null,
            function (data) {
                if ($('#dvtoplinkoutbox').length > 0 && $(data).find("#lnktoplinkoutbox").parent().length > 0) {
                    if ($(data).find("#lnktoplinkoutbox").parent().html().length > 0) {
                        $('#dvtoplinkoutbox').html($(data).find("#lnktoplinkoutbox").parent().html());
                    }
                    else {
                        $('#dvtoplinkoutbox').html('');
                    }
                }
                else {
                    $('#dvtoplinkoutbox').html('');
                }

            }, false, false);

    } catch (e) {
        showErrorAlert("Error", e.message, "موافق");
    }
}

function Load_DraftTopMenuContainer() {
    try {
        ajaxGetHandler("/DashboardHome/GetDraftTopMenuContainer",
            null,
            function (data) {
                if ($('#dvtoplinkdraftbox').length > 0 && data.trim().length > 0 && $(data).find("#lnktoplinkdraftbox").parent().length > 0) {
                    if ($(data).find("#lnktoplinkdraftbox").parent().html().length > 0) {
                        $('#dvtoplinkdraftbox').html($(data).find("#lnktoplinkdraftbox").parent().html());
                    }
                    else {
                        $('#dvtoplinkdraftbox').html('');
                    }
                }
                else {
                    $('#dvtoplinkdraftbox').html('');
                }

            }, false, false);

    } catch (e) {
        showErrorAlert("Error", e.message, "موافق");
    }
}

//Top part
function LoadTopViewComponents() {
    Load_InboxTopMenuContainer();

    Load_OutboxTopMenuContainer();

    Load_DraftTopMenuContainer();
}

function SetSelectedSharedTypeAndSelectedMailViewBagsNull() {
    try {
        var radioSeleted = $(".ddlSelectionType:checked").val();

        ajaxGetHandler("/DashboardHome/SetSelectedSharedTypeAndSelectedMailViewBagsNull", {
            ShareTypeID: radioSeleted
        }, function (data) {
            if (radioSeleted == "1") {
                setTimeout(function () {
                    window.location = "/DashboardHome";
                }, 500);
            }
        }, false, false);

    } catch (e) {
        showErrorAlert("Error", e.message, "موافق");
    }
}

function SetSelfProfile() {
    try {
        var ddpmenuloggedinuserademail = $("#ddpmenuloggedinuserademail").attr("data");//logged in user email address
        var radioSeleted = $(".ddlSelectionType:checked").val();

        ajaxGetHandler("/DashboardHome/SetSelfProfile", {
            ShareTypeID: radioSeleted,
            SelectedProfileEmail: ddpmenuloggedinuserademail
        }, function (data) {
            //forsignalR to register delegate email
            setSelectedProfileforDelegate(ddpmenuloggedinuserademail, data);


        }, false, false);

    } catch (e) {
        showErrorAlert("Error", e.message, "موافق");
    }
}

function LoadSelect2DropDownDataToCache() {

    try {
        var radioSeleted = $(".ddlSelectionType:checked").val();

        ajaxGetHandler("/DashboardHome/LoadSelect2DropDownDataToCache", {
            ShareTypeID: radioSeleted
        }, function (data) {
        }, false, false);

    } catch (e) {
        showErrorAlert("Error", e.message, "موافق");
    }

}

function ShowDropdownSelect2ProfileSelection() {

    try {
        var radioSeleted = $(".ddlSelectionType:checked").val();

        ajaxGetHandler("/DashboardHome/ShowDropdownSelect2ProfileSelection", {
            ShareTypeID: radioSeleted
        }, function (data) {

            $('#dvProfileList').html(data);
            RegenerateSelect2DropDown();
            //$('#s2ddlselectprofile').val('').trigger('change');
        }, false, false);

    } catch (e) {
        showErrorAlert("Error", e.message, "موافق");
    }

}

function GetSelect2DropDownValueFromCache() {

    try {
        var radioSeleted = $(".ddlSelectionType:checked").val();

        if (radioSeleted == 1) { }
        else if (radioSeleted > 1) {

            ajaxGetHandler("/DashboardHome/GetSelect2DropDownValueFromCache", {}, function (data) {
                const myJSON = JSON.stringify(data);
                if (myJSON.length > 0) {
                    ShowDropdownSelect2ProfileSelection();
                    SetSelect2DropDown(data.SelectedProfileEmail);
                }

            }, false, false);
        }

    } catch (e) {
        showErrorAlert("Error", e.message, "موافق");
    }

}

function SetSelect2DropDownToCache(SelectedProfileEmail) {

    try {
        SetSelect2DropDownToCache_Phase_1(SelectedProfileEmail).then((data) => {
            window.location = "/DashboardHome";
        }).catch((error) => {
            showErrorAlert("Error", error, "موافق");
        })

    } catch (e) {
        showErrorAlert("Error", e.message, "موافق");
    }

}

function SetSelect2DropDownToCache_Phase_1(SelectedProfileEmail) {
    return new Promise((resolve, reject) => {
        try {
            var ddpmenuloggedinuserademail = SelectedProfileEmail;
            var radioSeleted = $(".ddlSelectionType:checked").val();
            //alert(ddpmenuloggedinuserademail)
            ajaxGetHandler("/DashboardHome/SetOtherProfile", {
                ShareTypeID: radioSeleted,
                SelectedProfileEmail: ddpmenuloggedinuserademail
            }, function (data) {

                console.log("phase 1");
                setSelectedProfileforDelegate(SelectedProfileEmail, data);
                resolve(data)

            }, false, false);

        } catch (e) {
            showErrorAlert("Error", e.message, "موافق");
            reject(error)
        }

    })
}

function SetSelect2DropDownToCache_Phase_2() { }

function ReloadPage() {
    location.reload();
}

function ReloadPageAfterPopNotificationCounterUdpate() {
    try {
        LoadBottomViewComponents();
        //LoadTopViewComponents();

        if (window.location.pathname.indexOf("Inbox") > -1) {
            loadInboxData();
        }
        else if (window.location.pathname.indexOf("Outbox") > -1) {
            LoadOutbox();
        }
        else if (window.location.pathname.indexOf("Draftbox") > -1) {
            LoadDraftBox();
        }
    } catch (e) {

    }
}
function setAllReadAndRedirect() {
    try {
        ajaxGetHandler("/MsgPushPop/GetPushPopMSGByToUserSetAllViewed",
            null,
            function (data) {
                if (data.newItems > 0) {
                    $("#notificationcounterbadge").text(data.newItems.toString());
                    $("#spninboxtotal").text(data.newItems.toString());
                }
                else {
                    $("#notificationcounterbadge").text('');
                    $("#spninboxtotal").text('');
                }
                document.location = "/InboxLanding";

            }, false, false);
    } catch (e) {
        showErrorAlert("Error", e.message, "موافق");
    }
}
function setAllRead() {
    try {
        ajaxGetHandler("/MsgPushPop/GetPushPopMSGByToUserSetAllViewed",
            null,
            function (data) {
                if (data.newItems > 0) {
                    $("#notificationcounterbadge").text(data.newItems.toString());
                    $("#spninboxtotal").text(data.newItems.toString());
                }
                else {
                    $("#notificationcounterbadge").text('');
                    $("#spninboxtotal").text('');
                }

            }, false, false);
    } catch (e) {
        showErrorAlert("Error", e.message, "موافق");
    }
}

function Load_MongoNotification() {
    try {
        $("#divnotificationcontainer").empty();

        $("#notificationcounterbadge").hide();
        $("#notificationcounterbadge").text('');

        $("#spninboxtotal").hide();
        $("#spninboxtotal").text('');

        $("#dvtoplinkinboxbtn").attr('data-kt-menu-trigger', '');

        ajaxGetHandler("/MsgPushPop/GetPushPopMSGByToUser",
            null,
            function (data) {
                var str = '';
                if (data.data.length > 0) {
                    $("#dvtoplinkinboxbtn").attr('data-kt-menu-trigger', 'click');
                  

                    if (data.newItems > 0) {
                        $("#notificationcounterbadge").show();
                        $("#spninboxtotal").show();
                        $("#notificationcounterbadge").text(data.newItems.toString());
                        $("#spninboxtotal").text(data.newItems.toString());
                    }


                    str += '<div class="menu-item vertical-menu p-2" style="max-height: 200px; overflow-y: scroll;">';

                    $.each(data.data, function (key, value) {
                        //console.log(key);
                        //console.log(value.fullname);

                        var isNew = '';
                        if (!value.IsRead)
                            isNew = '<i class="fa-regular fa fa-star"  style="color:green"></i>   ';

                        str += '';

                        str += '<div class="media">';
                        str += '<img src="' + value.photourl + '" alt="User Avatar" class="img-size-50 mr-3 img-circle">';
                        str += '<div class="media-body">';
                        str += '<h3 class="dropdown-item-title">' + value.positionname + '<span class="float-right text-sm text-danger">' + isNew + '</span></h3>';

                        str += '<h3 class="dropdown-item-title">' + value.fullname + '</h3>';
                        str += '<p class="text-sm">' + value.Subject + '</p>';
                        //str += '<p class="text-sm text-muted"><i class="far fa-clock mr-1"></i>' + value.EntryDate +'</p>';
                        str += '</div>';
                        str += '</div>';

                        str += '<div class="separator my-2"></div>';
                    });

                    str += '</div>';



                    $("#divnotificationcontainer").append(str);
                }
            }, false, false);

    } catch (e) {
        showErrorAlert("Error", e.message, "موافق");
    }
}


$(function () {
    Load_MongoNotification();
    ///checi if data is already set in the cache
    GetSelect2DropDownValueFromCache();
    //radio event to load if there is any share or Delegate
    $(".ddlSelectionType").change(function () {



        //clean dropdown select2
        $('#dvProfileList').html("");
        //set initialize viewbags values to selected profile cache
        SetSelectedSharedTypeAndSelectedMailViewBagsNull();
        //set logged in user profile as default cache and bags values to selected profile cache
        SetSelfProfile();

        if ($(this).val() == 1) {
            LoadBottomViewComponents();
            LoadTopViewComponents();

            if (window.location.pathname.indexOf("Inbox") > -1) {
                loadInboxData();
            }
            else if (window.location.pathname.indexOf("Outbox") > -1) {
                LoadOutbox();
            }
            else if (window.location.pathname.indexOf("Draftbox") > -1) {
                LoadDraftBox();
            }
        }
        else if ($(this).val() > 1) {
            LoadSelect2DropDownDataToCache();
            ShowDropdownSelect2ProfileSelection();
        }



    });

});