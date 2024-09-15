var webroot = $("#webapi").val();
var token = $("#token").val();


webroot = "/";


$(function () {
    _Controlhide();
    _getServiceDetailsData();
    $('body').on('click', '#btnServiceDataSearch', function (e) {
        try {
            event.preventDefault();
            _Controlhide();

            var userid = "";
            var strServiceDetailsId = "";
            $.each($("#servicedetailids input.singleservice"), function (key, val) {
                if ($(val).prop("checked") == true) {
                    strServiceDetailsId += + $(val).attr("servicedetailid") + ",";
                }
            });

            if (strServiceDetailsId.length == 0) {
                $("span.servicedetailids").html("<span id='servicedetailids-error'>Please check at least one service</span>");
                return;
            }
            else {
                $("span.servicedetailids").html("");
            }

            if ($(".txtcivilid").val().length == 0 || $(".txtcivilid").val().length > 12) {
                $("span.civilid").html("<span id='civilid-error'>Please enter valid civil Id</span>");
                return;
            }
            else {
                $("span.civilid").html("");
            }


            $.blockUI({
                message: '<div><img src="/img/loader.png"> Please wait....</div>',
                css: {
                    border: 'none',
                    backgroundColor: 'transparent',
                    opacity: 0.9,
                    textAlign: 'center',
                    color: '#fff',
                    textSize: '20px'
                },
                fadeIn: 1000,
                timeout: 2000,
                onBlock: function () {
                    _loadServiceData();
                }
            }); 

        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });



    
});
function _getServiceDetailsData() {
    try {
        ajaxGetHandler("/MinistryServiceDataByCivilID/GetAllGen_ServiceDetailMappedInfoByUserID", null, function (data) {
            console.log(data);
            if (data != null && data.Code != "404") {
                $.each(data, function (key, val) {
                    var text = val.titleen + '/' + val.titlear;

                    $("#servicedetailids").append(
                        "<li class= 'list-group-item rounded-0 list-group-item rounded-0 col-lg-4' >" +
                        "<div class='custom-control custom-checkbox' > " +
                        "<div class='row'>" +
                        "<div class='col-lg-8'>" +
                        "<input name='chkService' class= 'custom-control-input singleservice' id='chkservice-" + val.servicedetailid + "' servicedetailid='" + val.servicedetailid + "' desc='" + val.descriptionen + "' descar='" + val.descriptionar + "' serviceurl='" + val.serviceurl + "'  type = 'checkbox' > " +
                        "<label class= 'cursor-pointer font-italic d-block custom-control-label' for='chkservice-" + val.servicedetailid + "' servicedetailid='" + val.servicedetailid + "'> " + text + " </label>" +
                        "</div>" +
                        "</div>" +
                        "</div>" +
                        "</li> ");
                });
            }
            else {
                $(".dvServiceDetail").html("");
                showErrorAlert("Error", "Service Detail is not configured", "OK");
            }
        }, false, false);
    }
    catch (e) {
        showErrorAlert("Error", e.message, "OK");
    }
}
function _loadServiceData() {
    try {
        $.each($("input[name='chkService']:checked"), function () {

            if ($(this).attr('descar') == "PAAET") {
                $(".dvPAAETService").css("display", "block");
                loadPAEETData();
            }
            else if ($(this).attr('descar') == "Departed") {
                $(".dvDepartedService").css("display", "block");
                loadDepartedPersonData();
            }
            else if ($(this).attr('descar') == "CivilServiceComm") {
                $(".dvCivilServiceComm").css("display", "block");
                loadCivilServiceCommData();
            }
            else if ($(this).attr('descar') == "KuwaitUni") {
                $(".dvKuwaitUniService").css('display', 'block');
                loadKuwaitUniData();
            }
            else if ($(this).attr('descar') == "PUC") {
                $(".dvPUCService").css("display", "block");
                loadPUCStatus();
            }
            else if ($(this).attr('descar') == "PUCFin") {
                $(".dvPUCFinancialService").css("display", "block");
                loadPUCFinancialStatus();
            }
            else if ($(this).attr('descar') == "MOE") {
                $(".dvMOEService").css('display', 'block');
                loadMOE();
            }
            else if ($(this).attr('descar') == "MOHE") {
                $(".dvMOHEService").css("display", "block");
                loadMOHE();
            }
            else if ($(this).attr('descar') == "MOI") {
                $(".dvMOIService").css('display', 'block');
                loadMOI();
            }
            else if ($(this).attr('descar') == "MOINewService") {
                $(".dvMOINewService").css('display', 'block');
                loadMOINewService();
            }
            else if ($(this).attr('descar') == "KFSD") {
                $(".dvKFSDService").css('display', 'block');
                loadKFSD();
            }
            else if ($(this).attr('descar') == "PACI") {
                $(".dvPACIService").css('display', 'block');
                loadPACIData();
            }
            else if ($(this).attr('descar') == "KNG") {
                $(".dvKNGService").css('display', 'block');
                loadKNG();
            }
            else if ($(this).attr('descar') == "Disabled") {
                $(".dvDisabledService").css('display', 'block');
                loadDisabledData();
            }
            else if ($(this).attr('descar') == "Manpower") {
                $(".dvManpowerService").css('display', 'block');
                loadManpowerData();
            }
            else if ($(this).attr('descar') == "KPC") {
                $(".dvKPCService").css('display', 'block');
                loadKPCData();
            }
            else if ($(this).attr('descar') == "PIFSS") {
                $(".dvPIFSSService").css("display", "block");
                loadPIFSSData();
            }
        });
    }
    catch (e) {
        showErrorAlert("Error", e.message, "OK");
    }
}

function loadPAEETData() {
    $("#tblPAAETStatusContainer tr:gt(0)").remove();
    var newRowContent = "<tr  class='loadingrow dataRow'><td colspan='8' style='text-align: center;' class='rownum'><span  class='WordWrap'><img src='/img/loading_small.gif' alt='loading data'/></span></td> </tr>";
    $("#tblPAAETStatusContainer tbody").append(newRowContent);

    var dataobject = {
        civilid: $(".txtcivilid").val()
    };
    ajaxPostObjectHandler("/MINServices/GetPAAETDataByCivilID", dataobject, function (response) {

        console.log(response)
        $("#tblPAAETStatusContainer tr:gt(0)").remove();
        if (response != null && response.data[0] != null) {
            var resp = response.data;
            $.each(resp, function (key, val) {
                console.log(val)


                var newRowContent = "<tr  class='rowListView dataRow'>" +
                    "<td class='rownum'><span  class='WordWrap'>" + val.civlid + "</span></td>" +
                    "<td class='rownum'><span  class='WordWrap'>" + val.studentname + " </span></td>" +
                    "<td class='rownum'><span  class='WordWrap'>" + val.instname + " </span></td>" +
                    "<td  class='rownum' style='direction: ltr;'><span class='WordWrap'>" + val.smstridadmit + " </span></td>" +
                    "<td  class='rownum' style='direction: ltr;'><span class='WordWrap'>" + val.phoneNo + " </span></td>" +
                    "<td  class='rownum'> <span class='WordWrap'>" + val.statuscategorydesc + "</span></td>" +
                    "<td class='rownum'  style='direction: ltr;' > <span  class='WordWrap'>" + getformatteddate(val.statusdate) + "</span> </td>" +
                    "</tr>";
                $("#tblPAAETStatusContainer tbody").append(newRowContent);
            });
        }
        else {
            var newRowContent = "<tr  class='rowListView dataRow'>" +
                "<td colspan='9' class='rownum'><span  class='WordWrap'>لا توجد بيانات.</span></td>" +
                "</tr>";
            $("#tblPAAETStatusContainer tbody").append(newRowContent);
        }
    }, true);
}
function loadDepartedPersonData() {
    $("#tbldvDepartedPersonStatusContainer tr:gt(0)").remove();
    var newRowContent = "<tr  class='loadingrow dataRow'><td colspan='8' style='text-align: center;' class='rownum'><span  class='WordWrap'><img src='/img/loading_small.gif' alt='loading data'/></span></td> </tr>";
    $("#tbldvDepartedPersonStatusContainer tbody").append(newRowContent);

    var dataobject = {
        civilid: $(".txtcivilid").val()
    };
    ajaxPostObjectHandler("/MINServices/GetDepartedDataByCivilID", dataobject, function (response) {
        console.log(response)
        $("#tbldvDepartedPersonStatusContainer tr:gt(0)").remove();
        if (response != null && response.data[0] != null) {
            var resp = response.data;
            
            $.each(resp, function (key, val) {
                if (val.wvInfo == "OK") {
                    var newRowContent = "<tr  class='rowListView dataRow'>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.civilNumber + "</span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.firstNameAr + " </span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.firstNameEng + " </span></td>" +
                        "<td  class='rownum' style='direction: ltr;'><span class='WordWrap'>" + val.sex + " </span></td>" +
                        "<td  class='rownum' style='direction: ltr;'> <span class='WordWrap'>" + val.statusDate + "</span></td>" +
                        "<td class='rownum'> <span  class='WordWrap'>" + val.statusCode + "</span> </td>" +
                        "<td class='rownum'> <span  class='WordWrap'>" + val.deathReferenceNo + "</span> </td>" +
                        "</tr>";

                    $("#tbldvDepartedPersonStatusContainer tbody").append(newRowContent);
                }
                else {
                    var newRowContent = "<tr  class='rowListView dataRow'>" +
                        "<td colspan='9' class='rownum'><span  class='WordWrap'>لا توجد بيانات.</span></td>" +
                        "</tr>";
                    $("#tbldvDepartedPersonStatusContainer tbody").append(newRowContent);
                }
            });
        }
        else {
            var newRowContent = "<tr  class='rowListView dataRow'>" +
                "<td colspan='9' class='rownum'><span  class='WordWrap'>لا توجد بيانات.</span></td>" +
                "</tr>";
            $("#tbldvDepartedPersonStatusContainer tbody").append(newRowContent);
        }
    }, true);
}
function loadCivilServiceCommData() {
    $("#tblCivilServiceCommStatusContainer tr:gt(0)").remove();
    var newRowContent = "<tr  class='loadingrow dataRow'><td colspan='8' style='text-align: center;' class='rownum'><span  class='WordWrap'><img src='/img/loading_small.gif' alt='loading data'/></span></td> </tr>";
    $("#tblCivilServiceCommStatusContainer tbody").append(newRowContent);

    var dataobject = {
        civilid: $(".txtcivilid").val()
    };
    ajaxPostObjectHandler("/MINServices/GetCivilServiceCommDataByCivilID", dataobject, function (response) {
        console.log(response)
        $("#tblCivilServiceCommStatusContainer tr:gt(0)").remove();
        if (response != null && response.data[0] != null) {
            var resp = response.data;

            $.each(resp, function (key, val) {
                if (val.civilId != null) {
                    var newRowContent = "<tr  class='rowListView dataRow'>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.civilId + "</span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.empName + " </span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.category + " </span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.job + " </span></td>" +
                        "<td  class='rownum' ><span class='WordWrap'>" + val.groupName + " </span></td>" +

                        "<td class='rownum'> <span  class='WordWrap'>" + (val.finishReson != null ? val.finishReson : "-")+ "</span> </td>" +
                        "<td  class='rownum' > <span class='WordWrap'>" + val.min + "</span></td>" +
                        "</tr>";
                    $("#tblCivilServiceCommStatusContainer tbody").append(newRowContent);
                }
                else {
                    var newRowContent = "<tr  class='rowListView dataRow'>" +
                        "<td colspan='7' class='rownum'><span  class='WordWrap'>" + val.msg + "</span></td></tr>";
                    $("#tblCivilServiceCommStatusContainer tbody").append(newRowContent);
                }
            });
        }
        else {
            var newRowContent = "<tr  class='rowListView dataRow'>" +
                "<td colspan='9' class='rownum'><span  class='WordWrap'>لا توجد بيانات.</span></td>" +
                "</tr>";
            $("#tblCivilServiceCommStatusContainer tbody").append(newRowContent);
        }
    }, true);
}
function loadKuwaitUniData() {

    $("#tblStudentInfo tr:gt(0)").remove();
    var newRowContent = "<tr  class='loadingrow dataRow'><td colspan='8' style='text-align: center;' class='rownum'><span  class='WordWrap'><img src='/img/loading_small.gif' alt='loading data'/></span></td> </tr>";
    $("#tblStudentInfo tbody").append(newRowContent);
    var dataobject = {
        civilid: $(".txtcivilid").val()
    };
    ajaxPostObjectHandler("/MINServices/GetKuwaitUniDataByCivilID", dataobject, function (response) {
        console.log(response)
        $("#tblStudentInfo tr:gt(0)").remove();
        if (response != null && response.data[0] != null) {
            var resp = response.data;

            $.each(resp, function (key, val) {
                var newRowContent = "<tr  class='rowListView dataRow'>" +
                    "<td class='rownum'><span  class='WordWrap'>" + val.civilId + "</span></td>" +
                    "<td class='rownum'><span  class='WordWrap'>" + val.name + " </span></td>" +
                    "<td class='rownum'><span  class='WordWrap'>" + val.studentId + " </span></td>" +
                    "<td class='rownum'><span  class='WordWrap'>" + val.college + " </span></td>" +
                    "<td  class='rownum' style='direction: ltr;' ><span class='WordWrap'>" + val.graduationDate + " </span></td>" +
                    "<td  class='rownum' > <span class='WordWrap'>" + val.textualStatus + "</span></td>" +
                    "</tr>";

                $("#tblStudentInfo tbody").append(newRowContent);
            });
        }
        else {
            var newRowContent = "<tr  class='rowListView dataRow'>" +
                "<td colspan='9' class='rownum'><span  class='WordWrap'>لا توجد بيانات.</span></td>" +
                "</tr>";
            $("#tblStudentInfo tbody").append(newRowContent);
        }
    }, true);
}
function loadPUCStatus() {
    $("#tblPUCInfo tr:gt(0)").remove();
    var newRowContent = "<tr  class='loadingrow dataRow'><td colspan='8' style='text-align: center;' class='rownum'><span  class='WordWrap'><img src='/img/loading_small.gif' alt='loading data'/></span></td> </tr>";
    $("#tblPUCInfo tbody").append(newRowContent);

    //PUC Info Start
    var dataobject = {
        civilid: $(".txtcivilid").val()
    };
    ajaxPostObjectHandler("/MINServices/GetPUCDataByCivilID", dataobject, function (response) {
        console.log(response)
        $("#tblPUCInfo tr:gt(0)").remove();
        if (response != null && response.data[0] != null) {
            var resp = response.data;
            if (resp != null) {

                var index = 0;
                for (index = 0; index < resp.length; index++) {
                    var newRowContent = "<tr  class='" + (index % 2 == 0 ? "rowListView" : "altrow") + " dataRow'>" +
                        "<td class='rownum'><span  class='WordWrap'>" + (index + 1) + "</span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + resp[index].civilid + "</span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + resp[index].name + " </span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + resp[index].studentcase + " </span></td>" +
                        "<td  class='rownum'><span  class='WordWrap'>" + resp[index].college + " </span> </td>" +
                        "<td  class='rownum' ><span class='WordWrap'>" + resp[index].firstsemister + " </span></td>" +
                        "<td  class='rownum'> <span class='WordWrap'>" + resp[index].certificate + "</span></td>" +
                        "<td class='rownum'> <span  class='WordWrap'>" + resp[index].secondsemister + "</span> </td>" +
                        "</tr>";

                    $("#tblPUCInfo tbody").append(newRowContent);
                }

            }
            else {
                var newRowContent = "<tr  class='rowListView dataRow'>" +
                    "<td colspan='8' class='rownum'><span  class='WordWrap'>لا توجد بيانات.</span></td>" +

                    "</tr>";

                $("#tblPUCInfo tbody").append(newRowContent);

            }
        }
        else {
            var newRowContent = "<tr  class='rowListView dataRow'>" +
                "<td colspan='9' class='rownum'><span  class='WordWrap'>لا توجد بيانات.</span></td>" +
                "</tr>";
            $("#tblPUCInfo tbody").append(newRowContent);
        }
    }, true);
}
function loadMOE() {
    $("#tbldvMOEInfo tr:gt(0)").remove();
    var newRowContent = "<tr  class='loadingrow dataRow'><td colspan='8' style='text-align: center;' class='rownum'><span  class='WordWrap'><img src='/img/loading_small.gif' alt='loading data'/></span></td> </tr>";
    $("#tbldvMOEInfo tbody").append(newRowContent);

    var dataobject = {
        civilid: $(".txtcivilid").val()
    };
    ajaxPostObjectHandler("/MINServices/GetMinOfEduDataByCivilID", dataobject, function (response) {
        console.log(response)
        $("#tbldvMOEInfo tr:gt(0)").remove();
        if (response != null && response.data[0] != null) {
            var resp = response.data;
            if (resp != null) {
                var index = 0;
                $.each(resp, function (key, val) {
                    var newRowContent = "<tr  class='" + (index % 2 == 0 ? "rowListView" : "altrow") + " dataRow'>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.cid + "</span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.studentName + " </span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.strbirthDate + " </span></td>" +
                        "<td  class='rownum'><span  class='WordWrap'>" + val.studentgrade + " </span> </td>" +
                        "<td  class='rownum' ><span class='WordWrap'>" + val.studentlevel + " </span></td>" +
                        "<td  class='rownum'> <span class='WordWrap'>" + val.studentschool + "</span></td>" +
                        "<td class='rownum'> <span  class='WordWrap'>" + val.studentstatus + "</span> </td>" +
                        "<td class='rownum'> <span  class='WordWrap'>" + val.year + "</span> </td>" +
                        "</tr>";

                    $("#tbldvMOEInfo tbody").append(newRowContent);
                    index++;
                });
            }
            else {
                var newRowContent = "<tr  class='rowListView dataRow'>" +
                    "<td colspan='8' class='rownum'><span  class='WordWrap'>لا توجد بيانات.</span></td>" +

                    "</tr>";

                $("#tbldvMOEInfo tbody").append(newRowContent);
            }
        }
        else {
            var newRowContent = "<tr  class='rowListView dataRow'>" +
                "<td colspan='9' class='rownum'><span  class='WordWrap'>لا توجد بيانات.</span></td>" +
                "</tr>";
            $("#tbldvMOEInfo tbody").append(newRowContent);
        }
    }, true);
}
function loadMOHE() {
    $("#tbldvMOHEInfo tr:gt(0)").remove();
    var newRowContent = "<tr  class='loadingrow dataRow'><td colspan='8' style='text-align: center;' class='rownum'><span  class='WordWrap'><img src='/img/loading_small.gif' alt='loading data'/></span></td> </tr>";
    $("#tbldvMOHEInfo tbody").append(newRowContent);

    var dataobject = {
        civilid: $(".txtcivilid").val()
    };
    ajaxPostObjectHandler("/MINServices/GetMinOHEduDataByCivilID", dataobject, function (response) {
        console.log(response)
        $("#tbldvMOHEInfo tr:gt(0)").remove();
        if (response != null && response.data[0] != null) {
            var resp = response.data;
            if (resp != null) {

                var index = 0;
                $.each(resp, function (key, val) {
                    var date = [padTo2Digits(val.day1), padTo2Digits(val.month1), val.year1].join('-');
                    var newRowContent = "<tr  class='" + (index % 2 == 0 ? "rowListView" : "altrow") + " dataRow'>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.studentCid + "</span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.name1 + " </span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.country1 + " </span></td>" +
                        "<td  class='rownum'><span  class='WordWrap'>" + date + " </span> </td>" +
                        "</tr>";

                    $("#tbldvMOHEInfo tbody").append(newRowContent);
                    index++;
                });
            }
            else {
                var newRowContent = "<tr  class='rowListView dataRow'>" +
                    "<td colspan='8' class='rownum'><span  class='WordWrap'>لا توجد بيانات.</span></td>" +

                    "</tr>";

                $("#tbldvMOHEInfo tbody").append(newRowContent);

            }
        }
        else {
            var newRowContent = "<tr  class='rowListView dataRow'>" +
                "<td colspan='9' class='rownum'><span  class='WordWrap'>لا توجد بيانات.</span></td>" +
                "</tr>";
            $("#tbldvMOHEInfo tbody").append(newRowContent);
        }
    }, true);
}
function loadMOI() {
    $("#tblMOItatusContainer tr:gt(0)").remove();
    var newRowContent = "<tr  class='loadingrow dataRow'><td colspan='12' style='text-align: center;' class='rownum'><span  class='WordWrap'><img src='/img/loading_small.gif' alt='loading data'/></span></td> </tr>";
    $("#tblMOItatusContainer tbody").append(newRowContent);
    var dataobject = {
        civilid: $(".txtcivilid").val(),
    };
    //KAFMiscServices
    ajaxPostObjectHandler("/MINServices/GetMOIDataByCivilID", dataobject, function (response) {
        console.log(response)
        $("#tblMOItatusContainer tr:gt(0)").remove();
        if (response != null && response.data[0] != null) {
            var resp = response.data;
            if (resp != null) {
                var index = 0;
                $.each(resp, function (key, val) {
                    var newRowContent = "<tr  class='" + (index % 2 == 0 ? "rowListView" : "altrow") + " dataRow'>" +

                        "<td class='rownum'><span  class='WordWrap'>" + val.civilId + "</span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.firstName + val.secondName + val.thirdName + val.forthName + val.familyName + " </span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.nationalNumber + " </span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.sex + " </span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.type + " </span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.description + " </span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.nationalityType + " </span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.article + " </span></td>" +

                        "<td class='rownum'><span  class='WordWrap'>" + getformatteddate(val.birthDate) + " </span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + getformatteddate(val.kuwaitIssueDate) + " </span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.issueCriteria + " </span></td>" +

                        "</tr>";

                    $("#tblMOItatusContainer tbody").append(newRowContent);
                    index++;
                });
            }
            else {
                var newRowContent = "<tr  class='rowListView dataRow'>" +
                    "<td colspan='8' class='rownum'><span  class='WordWrap'>لا توجد بيانات.</span></td>" +

                    "</tr>";

                $("#tblMOItatusContainer tbody").append(newRowContent);

            }
        }
        else {
            var newRowContent = "<tr  class='rowListView dataRow'>" +
                "<td colspan='9' class='rownum'><span  class='WordWrap'>لا توجد بيانات.</span></td>" +
                "</tr>";
            $("#tblMOItatusContainer tbody").append(newRowContent);
        }
    }, true);
}
function loadMOINewService() {
    $("#tblMOINewServiceStatusContainer tr:gt(0)").remove();
    var newRowContent = "<tr  class='loadingrow dataRow'><td colspan='12' style='text-align: center;' class='rownum'><span  class='WordWrap'><img src='/img/loading_small.gif' alt='loading data'/></span></td> </tr>";
    $("#tblMOINewServiceStatusContainer tbody").append(newRowContent);
    var dataobject = {
        civilid: $(".txtcivilid").val()
    };
    ajaxPostObjectHandler("/MINServices/GetMOIDataNewServiceByCivilID", dataobject, function (response) {
        console.log(response)
        $("#tblMOINewServiceStatusContainer tr:gt(0)").remove();
        if (response != null ) {
            var resp = response.data;
            if (resp != null) {
                var index = 0;
                $.each(resp, function (key, val) {
                    var newRowContent = "<tr  class='" + (index % 2 == 0 ? "rowListView" : "altrow") + " dataRow'>" +

                        "<td class='rownum'><span  class='WordWrap'>" + val.civilId + "</span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.personName + " </span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.employmentYears + " </span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.employmentMonths + " </span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.employmentDays + " </span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.statusMessage + " </span></td>" +
                        "</tr>";

                    $("#tblMOINewServiceStatusContainer tbody").append(newRowContent);
                    index++;
                });
            }
            else {
                var newRowContent = "<tr  class='rowListView dataRow'>" +
                    "<td colspan='8' class='rownum'><span  class='WordWrap'>لا توجد بيانات.</span></td>" +
                    "</tr>";
                $("#tblMOINewServiceStatusContainer tbody").append(newRowContent);

            }
        }
        else {
            var newRowContent = "<tr  class='rowListView dataRow'>" +
                "<td colspan='9' class='rownum'><span  class='WordWrap'>لا توجد بيانات.</span></td>" +
                "</tr>";
            $("#tblMOINewServiceStatusContainer tbody").append(newRowContent);
        }
    }, true);
}
function loadKFSD() {
    $("#tbldvKFSDInfo tr:gt(0)").remove();
    var newRowContent = "<tr  class='loadingrow dataRow'><td colspan='8' style='text-align: center;' class='rownum'><span  class='WordWrap'><img src='/img/loading_small.gif' alt='loading data'/></span></td> </tr>";
    $("#tbldvKFSDInfo tbody").append(newRowContent);
    var dataobject = {
        civilid: $(".txtcivilid").val()
    };
    ajaxPostObjectHandler("/MINServices/GetKSFDDataByCivilID", dataobject, function (response) {
        console.log(response)
        $("#tbldvKFSDInfo tr:gt(0)").remove();
        if (response != null && response.data[0] != null) {
            var resp = response.data;
            if (resp != null) {
               
                var index = 0;
                $.each(resp, function (key, val) {
                    if (val.prespflagOut == "1") {
                        var newRowContent = "<tr  class='" + (index % 2 == 0 ? "rowListView" : "altrow") + " dataRow'>" +
                            "<td class='rownum'><span  class='WordWrap'>" + val.pempcivilOut + "</span></td>" +
                            "<td class='rownum'><span  class='WordWrap'>" + val.pempnameOut + " </span></td>" +
                            "<td class='rownum'><span  class='WordWrap'>" + getformatteddate(val.pempbirthOut) + "</span></td>" +
                            "<td class='rownum'><span  class='WordWrap'>" + val.pemporgnameOut + "</span></td>" +
                            "</tr>";
                    }
                    else {
                        var newRowContent = "<tr  class='rowListView dataRow'>" +
                            "<td colspan='7' class='rownum'><span  class='WordWrap'>" + val.prespnoteOut + "</span></td>" +
                            "</tr>";
                    }

                    $("#tbldvKFSDInfo tbody").append(newRowContent);
                    index++;
                });
            }
            else {
                var newRowContent = "<tr  class='rowListView dataRow'>" +
                    "<td colspan='8' class='rownum'><span  class='WordWrap'>لا توجد بيانات.</span></td>" +

                    "</tr>";

                $("#tbldvKFSDInfo tbody").append(newRowContent);

            }
        }
        else {
            var newRowContent = "<tr  class='rowListView dataRow'>" +
                "<td colspan='9' class='rownum'><span  class='WordWrap'>لا توجد بيانات.</span></td>" +
                "</tr>";
            $("#tbldvKFSDInfo tbody").append(newRowContent);
        }
    }, true);
}
function loadPACIData() {

    $(".pnlpacidetails").addClass("hidden");
    $(".pacimsg").empty();
    var newRowContent = "<div style='text-align: center;' class='rownum'><span  class='WordWrap'><img src='/img/loading_small.gif' alt='loading data'/></span> </div>";
    $(".pacimsg").append(newRowContent);

    var dataobject = {
        civilid: $(".txtcivilid").val()
    };
    ajaxPostObjectHandler("/MINServices/GetPACIB2B_ByCivilID", dataobject, function (response) {
        console.log(response)
        //console.log(response.data.pacI_Single)
        //console.log(response.data.pacI_Single.data)
        $(".pacimsg").empty();
        if (response != null && response.data.pacI_Single != null) {
            var resp = response.data.pacI_Single.data;
            if (resp != null) {
                $(".pnlpacidetails").css("display", "block");
                $(".pnlpacidetails").removeClass("hidden");

                $("#txtpacivilid").val(resp.civno);
                $("#txtpacifullname").val(resp.araB_FULL_NAME);
                $("#txtpacidob").val(resp.birtH_DATE);

                $("#txtpacipersonstatus").val(resp.persoN_STATUS);
                $("#txtpacijobstatus").val(resp.joB_STATUS);
                $("#txtpacieducation").val(resp.educatioN_TEXT);

                $("#txtpacipersonfathercivilid").val(resp.fatheR_CIVNO);
                $("#txtpacifatherstatus").val(resp.fatheR_STATUS_TEXT);

                $("#txtpacimothercivilid").val(resp.motheR_CIVNO);
                $("#txtpacimotherfullname").val(resp.motheR_ARAB_NAME_1 + ' ' + resp.motheR_ARAB_NAME_2 + ' ' + resp.motheR_ARAB_NAME_3 + ' ' + resp.motheR_ARAB_NAME_4);
                $("#txtpacimotherstatus").val(resp.motheR_STATUS_TEXT);

                $("#txtpacigovernorate").val(resp.governoratE_NAME);
                $("#txtpacidistrict").val(resp.districtname);
                $("#txtpaciblock").val(resp.block);
                $("#txtpaciplot").val(resp.plot);
                $("#txtpacistreet").val(resp.streeT_NAME);
                $("#txtpacibuilding").val(resp.buildinG_NO);
                $("#txtpaciunitno").val(resp.uniT_NO);
                $("#txtpaciunittype").val(resp.uniT_TYPE);
                $("#txtpacifloorno").val(resp.motheR_CIVNO);
                $("#txtpacitelephone1").val(resp.teL_1);
                $("#txtpacitelephone2").val(resp.teL_2);
            }
            else {
                var msg = resp.Info != null ? resp.Info : "لا توجد بيانات.";
                var newRowContent = "<div colspan='6' class='rownum'><span  class='WordWrap'>" + msg + "</span></div>";
                $(".pacimsg").append(newRowContent);
            }
        }
        else {
            var msg = resp.Info != null ? resp.Info : "لا توجد بيانات.";
            var newRowContent = "<div colspan='6' class='rownum'><span  class='WordWrap'>" + msg + "</span></div>";
            $(".pacimsg").append(newRowContent);
        }
    }, true);
}
function loadKNG() {
    $("#tbldvKNGInfo tr:gt(0)").remove();
    var newRowContent = "<tr  class='loadingrow dataRow'><td colspan='8' style='text-align: center;' class='rownum'><span  class='WordWrap'><img src='/img/loading_small.gif' alt='loading data'/></span></td> </tr>";
    $("#tbldvKNGInfo tbody").append(newRowContent);

    var dataobject = {
        civilid: $(".txtcivilid").val()
    };
    ajaxPostObjectHandler("/MINServices/GetKNGDataByCivilID", dataobject, function (response) {
        console.log(response)
        $("#tbldvKNGInfo tr:gt(0)").remove();
        if (response != null && response.data[0] != null) {
            var resp = response.data;
            if (resp != null) {

                //$("#tbldvKNGInfo tr:gt(0)").remove();
                var index = 0;
                $.each(resp, function (key, val) {
                    var newRowContent = "<tr  class='" + (index % 2 == 0 ? "rowListView" : "altrow") + " dataRow'>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.CIVILIDNO + "</span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.FULLNAME + " </span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.MILITARYNO + " </span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + getformatteddate(val.DOB) + " </span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + getformatteddate(val.JOININGDATE) + " </span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.JOBSTATUS + " </span></td>" +
                        "</tr>";
                    $("#tbldvKNGInfo tbody").append(newRowContent);
                    index++;
                });
            }
            else {
                var newRowContent = "<tr  class='rowListView dataRow'>" +
                    "<td colspan='8' class='rownum'><span  class='WordWrap'>لا توجد بيانات.</span></td>" +
                    "</tr>";
                $("#tbldvKNGInfo tbody").append(newRowContent);
            }
        }
        else {
            var newRowContent = "<tr  class='rowListView dataRow'>" +
                "<td colspan='9' class='rownum'><span  class='WordWrap'>لا توجد بيانات.</span></td>" +
                "</tr>";
            $("#tbldvKNGInfo tbody").append(newRowContent);
        }
    }, true);
}
function loadDisabledData() {
    var dataobject = {
        civilid: $(".txtcivilid").val()
    };
    ajaxPostObjectHandler("/MINServices/GetDisabledData", dataobject, function (response) {
        console.log(response)
        $("#tbldvDisabledDataContainer tr:gt(0)").remove();
        if (response != null && response.data[0] != null) {
            var resp = response.data;
            if (resp != null) {

                
                var index = 0;
                $.each(resp, function (key, val) {
                    console.log(val)
                    if (val.wsMessage == "OK. ") {

                        var birthDate = moment(val.birthDate, "YYYYMMDD").format('DD-MMM-YYYY');
                        var disabilityDate = moment(val.disabilityDate, "YYYYMMDD").format('DD-MMM-YYYY');


                        var newRowContent = "<tr  class='rowListView dataRow'>" +
                            "<td class='rownum'><span  class='WordWrap'>" + val.civilNumber + "</span></td>" +
                            "<td class='rownum'><span  class='WordWrap'>" + val.disabledName + " </span></td>" +
                            "<td class='rownum'><span  class='WordWrap'>" + val.sex + " </span></td>" +
                            "<td class='rownum'><span  class='WordWrap'>" + val.nationality + " </span></td>" +
                            "<td  class='rownum' style='direction: ltr;'><span class='WordWrap'>" + birthDate + " </span></td>" +
                            "<td class='rownum'><span  class='WordWrap'>" + val.disabilityType + " </span></td>" +
                            "<td class='rownum'><span  class='WordWrap'>" + val.disabilityValidity + " </span></td>" +
                            "<td class='rownum'><span  class='WordWrap'>" + val.fileStatus + " </span></td>" +
                            "<td  class='rownum' style='direction: ltr;'> <span class='WordWrap'>" + disabilityDate + "</span></td>" +
                            "<td class='rownum'><span  class='WordWrap'>" + val.disabilityValidity + " </span></td>" +
                            "<td class='rownum'> <span  class='WordWrap'>" + val.mobile + "</span> </td>" +
                            "<td class='rownum'> <span  class='WordWrap'>" + val.telephone + "</span> </td>" +
                            "</tr>";

                        $("#tbldvDisabledDataContainer tbody").append(newRowContent);
                    }
                    else {
                        var newRowContent = "<tr  class='rowListView dataRow'>" +
                            "<td colspan='12' class='rownum'><span  class='WordWrap'>" + val.wsMessage + "</span></td>" +
                            "</tr>";
                        $("#tbldvDisabledDataContainer tbody").append(newRowContent);
                    }
                });
            }
            else {
                var newRowContent = "<tr  class='rowListView dataRow'>" +
                    "<td colspan='8' class='rownum'><span  class='WordWrap'>لا توجد بيانات.</span></td>" +
                    "</tr>";
                $("#tbldvDisabledDataContainer tbody").append(newRowContent);
            }
        }
        else {
            var newRowContent = "<tr  class='rowListView dataRow'>" +
                "<td colspan='9' class='rownum'><span  class='WordWrap'>لا توجد بيانات.</span></td>" +
                "</tr>";
            $("#tbldvDisabledDataContainer tbody").append(newRowContent);
        }
    }, true);
}
function loadManpowerData() {
    $("#tblManpowerData tr:gt(0)").remove();
    var newRowContent = "<tr  class='loadingrow dataRow'><td colspan='8' style='text-align: center;' class='rownum'><span  class='WordWrap'><img src='/img/loading_small.gif' alt='loading data'/></span></td> </tr>";
    $("#tblManpowerData tbody").append(newRowContent);

    var dataobject = {
        civilid: $(".txtcivilid").val()
    };
    ajaxPostObjectHandler("/MINServices/GetManpowerDataByCivilID", dataobject, function (response) {
        console.log(response)
        $("#tblManpowerData tr:gt(0)").remove();
        if (response != null && response.data[0] != null) {
            var resp = response.data;
            if (resp != null) {
               

                $.each(resp, function (key, val) {
                    var newRowContent = "<tr  class='rowListView dataRow'>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.laboursupportstatusdesc + "</span></td>" +
                        "</tr>";
                    $("#tblManpowerData tbody").append(newRowContent);
                });
            }
            else {
                var newRowContent = "<tr  class='rowListView dataRow'>" +
                    "<td colspan='8' class='rownum'><span  class='WordWrap'>لا توجد بيانات.</span></td>" +
                    "</tr>";
                $("#tblManpowerData tbody").append(newRowContent);
            }
        }
        else {
            var newRowContent = "<tr  class='rowListView dataRow'>" +
                "<td colspan='9' class='rownum'><span  class='WordWrap'>لا توجد بيانات.</span></td>" +
                "</tr>";
            $("#tblManpowerData tbody").append(newRowContent);
        }
    }, true);
}
function loadKPCData() {
    $("#tblkpcServiceContainer tr:gt(0)").remove();
    var newRowContent = "<tr  class='loadingrow dataRow'><td colspan='12' style='text-align: center;' class='rownum'><span  class='WordWrap'><img src='/img/loading_small.gif' alt='loading data'/></span></td> </tr>";
    $("#tblkpcServiceContainer tbody").append(newRowContent);

    var dataobject = {
        civilid: $(".txtcivilid").val()
    };
    ajaxPostObjectHandler("/MINServices/GetKPCDataByCivilID", dataobject, function (response) {
        console.log(response)
        $("#tblkpcServiceContainer tr:gt(0)").remove();
        if (response != null && response.data[0] != null) {
            var resp = response.data;
            if (resp != null) {
                var index = 0;
                $.each(resp, function (key, val) {
                    var newRowContent = "<tr  class='" + (index % 2 == 0 ? "rowListView" : "altrow") + " dataRow'>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.personID + "</span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.displayName + " </span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.nationalId + " </span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.status + " </span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.dateOfBirth + " </span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.leaveType + " </span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.leaveDuration + " </span></td>" +
                        "</tr>";
                    $("#tblkpcServiceContainer tbody").append(newRowContent);
                });
            }
            else {
                var newRowContent = "<tr  class='rowListView dataRow'>" +
                    "<td colspan='8' class='rownum'><span  class='WordWrap'>لا توجد بيانات.</span></td>" +
                    "</tr>";
                $("#tblkpcServiceContainer tbody").append(newRowContent);
            }
        }
        else {
            var newRowContent = "<tr  class='rowListView dataRow'>" +
                "<td colspan='9' class='rownum'><span  class='WordWrap'>لا توجد بيانات.</span></td>" +
                "</tr>";
            $("#tblkpcServiceContainer tbody").append(newRowContent);
        }
    }, true);
}
function loadPUCFinancialStatus() {
    $("#tblPUCFinancialInfo tr:gt(0)").remove();
    var newRowContent = "<tr  class='loadingrow dataRow'><td colspan='8' style='text-align: center;' class='rownum'><span  class='WordWrap'><img src='/img/loading_small.gif' alt='loading data'/></span></td> </tr>";
    $("#tblPUCFinancialInfo tbody").append(newRowContent);

    var dataobject = {
        civilid: $(".txtcivilid").val()
    };

    //PUC Financial Info Start
    ajaxPostObjectHandler("/MINServices/GetPUCFinDataByCivilID", dataobject, function (response) {
        console.log(response)
        $("#tblPUCFinancialInfo tr:gt(0)").remove();
        if (response != null && response.data[0] != null) {
            var resp = response.data;

            if (resp != null) {

                var index = 0;

                $.each(resp, function (key, val) {
                    var newRowContent = "<tr  class='" + (index % 2 == 0 ? "rowListView" : "altrow") + " dataRow'>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.civilid + "</span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.name + " </span></td>" +
                        "<td  class='rownum' ><span class='WordWrap'>" + val.speciality + " </span></td>" +
                        "<td  class='rownum'><span  class='WordWrap'>" + val.college + " </span> </td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.studentcase + " </span></td>" +
                        "</tr>";
                    $("#tblPUCFinancialInfo tbody").append(newRowContent);
                    index++;
                })
            }
            else {
                var newRowContent = "<tr  class='rowListView dataRow'>" +
                    "<td colspan='9' class='rownum'><span  class='WordWrap'>لا توجد بيانات.</span></td>" +
                    "</tr>";
                $("#tblPUCFinancialInfo tbody").append(newRowContent);
            }
        }
        else {
            var newRowContent = "<tr  class='rowListView dataRow'>" +
                "<td colspan='9' class='rownum'><span  class='WordWrap'>لا توجد بيانات.</span></td>" +
                "</tr>";
            $("#tblPUCFinancialInfo tbody").append(newRowContent);
        }
    }, true);
    //PUC Financial Info End
}
function loadPIFSSData() {

    $("#tblPIFSSContainer tr:gt(0)").remove();
    var newRowContent = "<tr  class='loadingrow dataRow'><td colspan='8' style='text-align: center;' class='rownum'><span  class='WordWrap'><img src='/img/loading_small.gif' alt='loading data'/></span></td> </tr>";
    $("#tblPIFSSContainer tbody").append(newRowContent);

    var dataobject = {
        civilid: $(".txtcivilid").val()
    };
    //console.log(dataobject)

    ajaxPostObjectHandler("/MINServices/GetPIFSSDataByCivilID", dataobject, function (response) {
        console.log(response)
        $("#tblPIFSSContainer tr:gt(0)").remove();
        if (response != null && response.data[0] != null) {
            var resp = response.data;
            var rowIndex = 1;
            $.each(resp, function (key, val) {
                console.log(val)
                var newRowContent = "<tr  class='rowListView dataRow'>" +
                    "<td class='rownum'><span  class='WordWrap'>" + val.CID + "</span></td>" +
                    "<td class='rownum'><span  class='WordWrap'>" + val.NAME + " </span></td>" +
                    "<td class='rownum'><span  class='WordWrap'>" + getformatteddate(val.DATE_OF_BIRTH) + " </span></td>" +
                    "<td  class='rownum' style='direction: ltr;'><span class='WordWrap'>" + val.EMPLOYER + " </span></td>" +
                    "</tr>";
                $("#tblPIFSSContainer tbody").append(newRowContent);
                rowIndex++;
            });
        }
        else {
            var newRowContent = "<tr  class='rowListView dataRow'>" +
                "<td colspan='9' class='rownum'><span  class='WordWrap'>لا توجد بيانات.</span></td>" +
                "</tr>";
            $("#tblPIFSSContainer tbody").append(newRowContent);
        }
    }, true);
}
function getformatteddate(objdate) {
    var stdDate = '';
    if (objdate != null) {
        if (objdate.length > 0) {
            if (objdate.indexOf('T') != -1)
                stdDate = objdate.substring(0, objdate.indexOf('T'));
            else if (objdate.indexOf(' ') != -1)
                stdDate = objdate.substring(0, objdate.indexOf(' '));
            else
                stdDate = objdate;
        }

    }

    return stdDate;

}
function padTo2Digits(num) {
    return num.toString().padStart(2, '0');
}

function _Controlhide() {
    $(".dvPAAETService").css("display", "none");
    $(".dvCivilServiceComm").css("display", "none");
    $(".dvDepartedService").css("display", "none");
    $(".dvKuwaitUniService").css('display', 'none');
    $(".dvPUCService").css("display", "none");
    $(".dvPUCFinancialService").css("display", "none");
    $(".dvMOHEService").css("display", "none");
    $(".dvMOEService").css('display', 'none');
    $(".dvMOIService").css('display', 'none');
    $(".dvMOINewService").css('display', 'none');
    $(".dvKFSDService").css('display', 'none');
    $(".dvPACIService").css('display', 'none');
    $(".dvKNGService").css('display', 'none');
    $(".dvDisabledService").css('display', 'none');
    $(".dvManpowerService").css('display', 'none');
    $(".dvKPCService").css('display', 'none');
    $(".dvPIFSSService").css('display', 'none');

}