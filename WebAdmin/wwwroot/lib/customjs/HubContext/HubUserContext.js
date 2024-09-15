
///*!
// * Ajax HubUserContext functions JavaScript Library v1.0
// *
// * Copyright Mahmudur rahman Foundation and other contributors
// * Released under the MIT license
// * https://jquery.org/license
// * Date: 2021-03-02T17:08Z
// */

'use strict';
var userList;
var selfconnid;
var selfemail;

// reviewed
function loadConnectedUsers(data) {

    userList = JSON.parse(data);
    $('#activeuserlist').empty();
    $.each(userList, function (key, value) {

        $("#activeuserlist").append("<tr><td>" + value.UserName + "</td></tr>");
        $("#activeuserlist").append("<tr><td>" + value.ConnectionId + "</td></tr>");
        $("#activeuserlist").append("<br />");

    });
}

// reviewed
function executesendmsgtospecificclient(msg, fromemail) {
    alert(msg + " from: " + fromemail);
}

// reviewed
var connectionusercontext = new signalR.HubConnectionBuilder()
    .withUrl("/HubUserContext")
    .configureLogging(signalR.LogLevel.Information)
    .build();


$(function () {

    try {

        connectToHub();

        connectionusercontext.on("ParticipantConnectedSuccessfully", (data, useremail) => {
            //console.log(data);
            selfconnid = data;
            selfemail = useremail;
            console.log("ParticipantConnectedSuccessfully-new_connecttionid_" + data + "_Email=" + useremail);
        });

        connectionusercontext.on("CompleteConnectionParticipantList", (data) => {
            loadConnectedUsers(data);
        });

        connectionusercontext.on("DeletedConnectedParticipant", (data) => {
            loadConnectedUsers(data);
        });

        connectionusercontext.on("SendMsgtoSpecificClient", (msg, fromemail) => {

            executesendmsgtospecificclient(msg, fromemail);

        });//


    } catch (e) {
        showErrorAlert("Error", e.message, "موافق");
    }
});


function SendClientSpecificMessage(toemail, message) {
    try {

        connectionusercontext.invoke("SendClientSpecificMsg", toemail, message).then(function () {
            //objelement.parent().parent().parent().find(".chatmsg").val('');
        });

    } catch (e) {
        showErrorAlert("Error", e.message, "موافق");
    }
}


function connectToHub() {
    connectionusercontext.start({ transport: ['webSockets', 'longPolling'] }).catch(function (err) {
        return console.error(err.toString());
    }).then(function () {
        try {

            connectionusercontext.invoke("GetEnlistedClientsList");

        } catch (err) {
            console.error(err);
        }
    });
}

