
///*!
// * Ajax HubUserContext CIVILID functions JavaScript Library v1.0
// *
// * Copyright Mahmudur rahman Foundation and other contributors
// * Released under the MIT license
// * https://jquery.org/license
// * Date: 2023-03-02T17:08Z
// */

'use strict';

var connectionusercontextCivil;
var progressCivilTimeOut;

var pleaseWaitCivilAuth = $('#modalcontainerWaitForMobileAuthenticated');
var pleaseWaitCivilVal = $('#modalcontainerWaitForCivilIdValidation');

var codecivil = '';
var hubconcivilid = '';
var isValidCivilId = false;

$(function () {

    $('#progressBarCivil').hide();


    $("#textCivilId").on("blur", function () {
        ValiidateCivilID();
    });


    function ValiidateCivilID() {
        try {
            var ajaxResponse = null;

            $("#textCivilId").css('border', '');
            var _civilid = $("#textCivilId").val();
            if (_civilid != "" && _civilid.length == 12) {
                try {

                    var dataobject = { pkeyex: $("#textCivilId").val() };
                    ajaxPostObjectHandler("/Account/GetCivilIDValidated", dataobject, function (response) {

                        if (response != null && response.Content != null) {
                            ajaxResponse = JSON.parse(response.Content);
                        }

                        if (response.StatusCode == "200") {
                            isValidCivilId = true;
                            CallMobileIDAuthticate();
                        }
                        else {
                            $("#textCivilId").css('border', '1px solid red');
                            isValidCivilId = false;
                            WarningMessage(ajaxResponse._ajaxresponse.responsetext);
                        }
                    }, true);

                } catch (e) {
                    isValidCivilId = false;
                    showErrorAlert("Error", e.message, "موافق");
                }
            }
            else {
                $("#textCivilId").css('border', '1px solid red');
                WarningMessage("Please enter valid civil id");
            }
        } catch (e) {
            showErrorAlert("Error", e.message, "موافق");
        }
    }


    function CallMobileIDAuthticate() {

        if (isValidCivilId == true) {

            showPleaseWaitCivilAuth();

            $("#textCivilId").prop('disabled', true);

            try {

                if (connectionusercontextQR != null) {
                    connectionusercontextQR.stop().then(function () {
                        connectionusercontextQR = null;
                    });
                }

                if (connectionusercontextCivil != null) {
                    connectionusercontextCivil.stop().then(function () {
                        connectionusercontextCivil = null;
                    });
                }

                connectHubAndMiscCivil().then((data) => {

                    var dataobject = {
                        servicename: "Sahel Admin",
                        hubsessionid: data.code,
                        hubcnnectionid: data.connectionid,
                        civilid: hubconcivilid
                    };

                    ajaxPostObjectHandler("/Account/PaciAuthRequestByCivilId", dataobject, function (response) {

                        console.log(response);
                        console.log(response.data);
                        console.log(response.data.KeyParam);

                        $('#progressBarCivil').show();
                        progressCivil(90, 90, $('#progressBarCivil'));

                        try {
                            if (connectionusercontextCivil != null) {
                                connectionusercontextCivil.invoke("UpdateExistingConnectionData", response.data.KeyParam, data.connectionid, data.code, hubconcivilid);
                            }

                        } catch (err) {
                            console.error(err);
                        }

                    }, true);

                }).catch((error) => {
                    showErrorAlert("Error", error, "موافق");
                })

            } catch (e) {
                showErrorAlert("Error", e.message, "موافق");
                hidePleaseWaitCivilAuth();
                $("#textCivilId").prop('disabled', false);
            }
        }
    }

    function progressCivil(timeleft, timetotal, $element) {
        var progressBarWidth = timeleft * $element.width() / timetotal;
        $element.find('div').animate({ width: progressBarWidth }, 500).html(Math.floor(timeleft / 60) + ":" + timeleft % 60);
        if (timeleft > 0) {

            progressCivilTimeOut = setTimeout(function () {
                progressCivil(timeleft - 1, timetotal, $element);
            }, 1000);
        }
        else
            location.reload();
    };

    function showPleaseWaitCivilAuth() {
        pleaseWaitCivilAuth.modal({ backdrop: 'static', keyboard: false })
        pleaseWaitCivilAuth.modal('show');
    };

    function hidePleaseWaitCivilAuth() {
        pleaseWaitCivilAuth.modal('hide');
    };

});




function connectHubAndMiscCivil() {
    try {

        codecivil = $("#code").val();
        hubconcivilid = $("#textCivilId").val();

        return new Promise((resolve, reject) => {
            try {

                connectionusercontextCivil = new signalR.HubConnectionBuilder()
                    .withUrl("/HubCivilUserContext?code=" + codecivil + "&civilid=" + hubconcivilid)
                    .configureLogging(signalR.LogLevel.Information)
                    .build();

                connectionusercontextCivil.onclose(async () => {
                    await connectToHubCivil();
                });

                connectToHubCivil();

                connectionusercontextCivil.on("ParticipantConnectedSuccessfullyCivil", (data, temidentifiercode) => {
                    var dataobject = { connectionid: data, code: temidentifiercode };
                    resolve(dataobject);
                });

                connectionusercontextCivil.on("PostAuthenticationProcessCallCivil", (civilid, keyparam, resultdetails, personaldata, pacipersonaldata) => {
                    //showInformationAlert("نجاح", "المصادقة بنجاح ", "موافق", PostToLogin, keyparam + "_,_" + resultdetails + "_,_" + personaldata + "_,_" + civilid);
                    PostToLoginCivil(keyparam + "_,_" + resultdetails + "_,_" + personaldata + "_,_" + civilid + "_,_" + pacipersonaldata);
                });

                connectionusercontextCivil.on("PostUnAuthorizedProcessCallCivil", (keyparam, civilid) => {
                    showInformationAlert("معلومة", "تم رفض الطلب", "موافق", ReloadWindow, "");
                });

                connectionusercontextCivil.on("PostMsgToClientForConnectionIDUpdated", (codecivilid, keyparam, connectionid, oldccnnectionid) => {
                    console.log("new connection id: " + connectionid);
                    console.log("old connection id: " + oldccnnectionid);
                });


            } catch (e) {
                showErrorAlert("Error", e.message, "موافق");
                reject(error)
            }

        })

    } catch (e) {
        showErrorAlert("Error", e.message, "موافق");
    }
}


function PostToLoginCivil(allvalues) {
    try {
        var keyparam = "";
        var resultdetails = "";
        var personaldata = "";
        var civilid = "";
        var pacipersonaldata = "";
        var allvaluesarray = allvalues.split("_,_");
        if (allvaluesarray.length > 0) {
            keyparam = allvaluesarray[0];
            resultdetails = allvaluesarray[1];
            personaldata = allvaluesarray[2];
            civilid = allvaluesarray[3];
            pacipersonaldata = allvaluesarray[4];
        }

        var dataobject = { userprofilephoto: keyparam, concurrencystamp: resultdetails, securitystamp: personaldata, masprivatekey: civilid, newemailaddress: pacipersonaldata };
        ajaxPostObjectHandler("/Account/LoginQR", dataobject, function (response) {

            console.log($.parseJSON(response.Content)._ajaxresponse.responsetext)

            if (response.StatusCode == "200") {
                showSuccessAlert("Success", $.parseJSON(response.Content)._ajaxresponse.responsetext, "OK");
                window.location.reload();
            }
            else {
                showErrorAlert($.parseJSON(response.Content)._ajaxresponse.responsetitle, $.parseJSON(response.Content)._ajaxresponse.responsetext, "OK");
            }

        }, true);

    } catch (e) {
        showErrorAlert("Error", e.message, "موافق");
    }
}
function ReloadWindow() {
    location.reload(true);
}

function connectToHubCivil() {
    connectionusercontextCivil.start({ transport: ['webSockets', 'longPolling'] }).catch(function (err) {
        return console.error(err.toString());
    }).then(function () {

    });
}

window.addEventListener("blur", function (event) {
    event.preventDefault();
    if ((/^((?!chrome|android).)*safari/i.test(navigator.userAgent)) && (connectionusercontext != undefined)) {
        //alert("مصدق");
    }
});



$(function () {
    try {


    } catch (e) {
        showErrorAlert("Error", e.message, "موافق");
    }
});