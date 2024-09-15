
///*!
// * Ajax HubUserTrackingContext functions JavaScript Library v1.0
// *
// * Copyright Mahmudur rahman Foundation and other contributors
// * Released under the MIT license
// * https://jquery.org/license
// * Date: 2021-03-02T17:08Z
// */

//'use strict';

//var _onlineUserList;

//const connectionusercontext = "";// new signalR.HubConnectionBuilder()
//    //.withUrl("/HubUserTrackingContext")
//    //.withUrl("http://localhost:56025/HubUserContext",
//         //{
//           //accessTokenFactory: () => ""
//        //}
//    //)
//    //.configureLogging(signalR.LogLevel.Information)
//    //.build();

//let updateCountCallback = function (message) {
//    if (!message) return;
//    console.log('updateCount = ' + message);
//};

////connectionusercontext.on('UserConnectedJS', updateCountCallback);
//connectionusercontext.on("UserConnectedJS", (data) => {
//    _onlineUserList = data;
//    if (_onlineUserList != null) {
//        ShowDataOnlineUserList();
//    }
//    $("#HeaserNotificationsOnlineUserCounter").text(data.length);
//});

//connectionusercontext.on("ReceiveMessageHandler", (msg, fromuser) => {
//    swal({
//        title: "<h5 style='color:blue'>From: " + fromuser +  "</h5>",
//        html: true,
//        text: msg,
//        icon: "info",
//        button: "موافق",
//    });
//});

//connectionusercontext.on("EmailNotification", (fromuser) => {
//    console.log("Email sent by " + fromuser);
//    swal({
//        title: "<h5 style='color:blue'>From: " + fromuser + "</h5>",
//        html: true,
//        text: msg,
//        icon: "info",
//        button: "موافق",
//    });
//});

//connectionusercontext.start().catch(function (err) {
//    return console.error(err.toString());
//}).then(function () {
//    //connection.invoke('GetConnectionObject').then(function (objHubEntity) {
//    //    var conobj = JSON.parse(objHubEntity);
//    //    console.log(conobj.UserId);

//    //    if (objHubEntity.UserId != "") {
//    //        ajaxGetHandler("/Home/Gettransferdata", { UserId: conobj.UserId }, function (data) {
//    //            console.log(data);

//    //        }, false, false);
//    //    }
//    //    //.5665/document.getElementById('signalRConnectionId').innerHTML = connectionId;
//    //})
//});

//function ShowDataOnlineUserList() {
//    var dt = $("#dtonlineuser").DataTable({
//        data: _onlineUserList,
//        "lengthMenu": [[10, 25, 50, 100], [10, 25, 50, 100]],
//        "bDestroy": true,
//        "processing": true, // for show progress bar
//        "serverSide": false, // for process server side
//        "filter": true, // this is for disable filter (search box)
//        "orderMulti": false, // for disable multiple column at once
//        "responsive": true,
//        "bAutoWidth": true,
//        "autoWidth": true,
//        //"pagingType": "full_numbers"
//        "pagingType": "",
//        "stripeClasses": [],
//        //lengthChange:false,
//        //"dom": 'C<"clear">Blfrtip<>',
//        dom: '',
//        "buttons": ['print', 'copy', 'excel', 'pdf'],
//        "language":
//        {
//            "url": (dir == 'rtl' ? "//cdn.datatables.net/plug-ins/1.10.20/i18n/Arabic.json" : ""),
//            "processing": "<div class='overlay custom-loader-background'><i class='fa fa-cog fa-spin custom-loader-color'></i></div>",
//            "infoFiltered": ""
//        },
//        "drawCallback": function (settings) {
//        },
//        "buttons": {},
//        columnDefs: [
//            { targets: 0, "visible": true, searchable: false },    // Fix the column width
//            { targets: 1, "visible": true, searchable: true },
//            { targets: 2, "visible": true, "sortable": false, "className": "text-center" }
//        ],
//        "columns": [
//            { "data": "userId", "name": "userId", "autoWidth": true },
//            { "data": "userEmail", "name": "userEmail", "autoWidth": true },
//            {
//                "data": "userId", render: function (data, type, full, row) {
//                    if ($("#UserIdentityName").text() == full.userEmail)
//                        return '';
//                    else
//                        return "<button id='btnsendmsgtouser'  onclick='sendMessage(\"" + data + "\",\"" + full.userEmail + "\" )' class='btn btn-primary btn-md'>Send Message </button>";
//                }
//            }
//        ]
//    });
//}

//function sendMessage(userid, emailaddress) {
//    event.preventDefault();
//    swal({
//        title: "<h5 style='color:blue'>Send Message to: " + emailaddress + "</h5>",
//        text: '<input type="hidden" id="userid" name="userid" value="' + userid + '"><input id="txtmsgonline" name="txtmsgonline" type="text" tabIndex="1" class="form-control" placeholder="your message">',
//        html: true,
//        showCancelButton: true,
//        closeOnConfirm: true,
//        animation: "slide-from-top",
//        inputPlaceholder: "Write something",
//        onOpen: function () {
//            alert('onOpen');
//        }
//    }, function (result) {
//        if (result) {
//            if ($('#txtmsgonline').val() == '')
//                alert('result blanck');
//            else {
//                connectionusercontext.invoke("SendMessage", userid, $('#txtmsgonline').val()).catch(function (err) {
//                    return console.error(err.toString());
//                });
//            }
//        }
//    });
//    return;
//}

//$(function () {

//    $('body').on('click', '#ahrefchange_onlineusershow', function (e) {

//        //$.get("https://crmtesttoken.azurewebsites.net/PocCRMAzure", function (data, status) {
//        //    alert("Data: " + data + "\nStatus: " + status);
//        //});

//        ajaxGetHandler("/OnlineUser/ShowUserList", { returnUrl: "/" }, function (response) {
//            _cusTriggerModal("modal-common", response);
//        }, false, false);
//    });

//});
