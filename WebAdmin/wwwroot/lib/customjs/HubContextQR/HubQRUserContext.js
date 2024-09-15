
///*!
// * Ajax HubUserContext QR functions JavaScript Library v1.0
// *
// * Copyright Mahmudur rahman Foundation and other contributors
// * Released under the MIT license
// * https://jquery.org/license
// * Date: 2021-03-02T17:08Z
// */

'use strict';

var connectionusercontextQR;
var progressQRTimeOut;
var code = '';

$(function () {

    $('#progressBarQR').hide();

    $('body').on('click', '#btnGenerateQR', function (e) {
        try {

            event.preventDefault();

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

            $("#btnGenerateQR").prop('disabled', true);

            connectHubAndMisc().then((data) => {

                var dataobject = { servicename: "Sahel Admin", HUBCnnectionId: data.connectionid, HUBSessionid: data.code };
                //console.log(dataobject);

                ajaxPostObjectHandler("/Account/GetQRCodeFromPACILogin", dataobject, function (response) {
                    var DSet = $.parseJSON(response.Content);
                    $('#progressBarQR').show();
                    progressQR(90, 90, $('#progressBarQR'));
                    $('#qrimageprime').attr('src', "data:image/png;base64," + DSet._ajaxresponse.data.data.result.qrCodeImage);
                    $('#KeyParam').val(DSet._ajaxresponse.data.data.keyParam);
                    var KeyParam = DSet._ajaxresponse.data.data.keyParam;
                    try {
                        if (connectionusercontextQR != null) {
                            connectionusercontextQR.invoke("UpdateExistingConnectionData", KeyParam, data.connectionid, data.code);
                        }

                    } catch (err) {
                        console.log(err);
                    }
                }, true);



            }).catch((error) => {
                showErrorAlert("Error", error, "موافق");
            })

        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });

    function progressQR(timeleft, timetotal, $element) {
        var progressBarWidth = timeleft * $element.width() / timetotal;
        $element.find('div').animate({ width: progressBarWidth }, 500).html(Math.floor(timeleft / 60) + ":" + timeleft % 60);
        if (timeleft > 0) {

            progressQRTimeOut = setTimeout(function () {
                progressQR(timeleft - 1, timetotal, $element);
            }, 1000);
        }
        else
            location.reload();
    };

});



function connectHubAndMisc() {
    try {

        code = $("#code").val();

        return new Promise((resolve, reject) => {
            try {
                connectionusercontextQR = new signalR.HubConnectionBuilder()
                    .withUrl("/HubQRUserContext?code=" + code)
                    .configureLogging(signalR.LogLevel.Information)
                    .build();

                connectionusercontextQR.onclose(async () => {
                    await connectToHubQR();
                });

                connectToHubQR();

                connectionusercontextQR.on("ParticipantConnectedSuccessfullyQR", (data, temidentifiercode) => {
                    var dataobject = { connectionid: data, code: temidentifiercode };
                    resolve(dataobject);
                });

                connectionusercontextQR.on("PostAuthenticationProcessCallQR", (civilid, keyparam, resultdetails, personaldata, pacipersonaldata) => {
                    //showInformationAlert("نجاح", "المصادقة بنجاح ", "موافق", PostToLogin, keyparam + "_,_" + resultdetails + "_,_" + personaldata + "_,_" + civilid);
                    PostToLoginQR(keyparam + "_,_" + resultdetails + "_,_" + personaldata + "_,_" + civilid + "_,_" + pacipersonaldata);
                });

                connectionusercontextQR.on("PostUnAuthorizedProcessCallQR", (keyParam, paciauthresponseinfo, userdata) => {
                    showInformationAlert("معلومة", "تم رفض الطلب", "موافق", ReloadWindow, "");
                });
                  
                connectionusercontextQR.on("PostMsgToClientForConnectionIDUpdated", (keyparam, connectionid, oldccnnectionid) => {
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




function PostToLoginQR(allvalues) {
    try {
        var keyparam = "";
        var resultdetails = "";
        var civilid = "";
        var personaldata = "";
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

function connectToHubQR() {
    connectionusercontextQR.start({ transport: ['webSockets', 'longPolling'] }).catch(function (err) {
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