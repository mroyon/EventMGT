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

            console.log(strServiceDetailsId)

            if (strServiceDetailsId.length == 0) {
                $("span.servicedetailids").html("<span id='servicedetailids-error'>Please check at least one service</span>");
                return;
            }
            else {
                $("span.servicedetailids").html("");
            }

            //if ($(".txtcivilid").val().length == 0 || $(".txtcivilid").val().length > 12) {
            //    $("span.civilid").html("<span id='civilid-error'>Please enter valid civil Id</span>");
            //    return;
            //}
            //else {
            //    $("span.civilid").html("");
            //}


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
        ajaxGetHandler("/MinistryServiceDataByDateRange/GetAllGen_ServiceDetailMappedInfoByUserID", null, function (data) {
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

    //alert("1")

    $("#tblPAAETStatusContainer tr:gt(0)").remove();
    var newRowContent = "<tr  class='loadingrow dataRow'><td colspan='8' style='text-align: center;' class='rownum'><span  class='WordWrap'><img src='/img/loading_small.gif' alt='loading data'/></span></td> </tr>";
    $("#tblPAAETStatusContainer tbody").append(newRowContent);

    //alert("2")

    var dataobject = {
        fromdate: $('input[name="daterange"]').data('daterangepicker').startDate.format('YYYY-MM-DD'),
        todate: $('input[name="daterange"]').data('daterangepicker').endDate.format('YYYY-MM-DD'),
    };
    console.log(dataobject)
    //alert("3")

    ajaxPostObjectHandler("/MINServices/GetPAAETDataByDateRange", dataobject, function (response) {
        console.log(response)
        $("#tblPAAETStatusContainer tr:gt(0)").remove();
        if (response != null && response.data[0] != null) {
            var resp = response.data;
            var rowIndex = 1;
            $.each(resp, function (key, val) {
                console.log(val)
                var newRowContent = "<tr  class='rowListView dataRow'>" +
                    //"<td class='rownum'><span  class='WordWrap'>" + rowIndex + "</span></td>" +
                    "<td class='rownum'><span  class='WordWrap'>" + val.civlid + "</span></td>" +
                    "<td class='rownum'><span  class='WordWrap'>" + val.studentname + " </span></td>" +
                    "<td class='rownum'><span  class='WordWrap'>" + val.instname + " </span></td>" +
                    "<td  class='rownum' style='direction: ltr;'><span class='WordWrap'>" + val.smstridadmit + " </span></td>" +
                    "<td  class='rownum' style='direction: ltr;'><span class='WordWrap'>" + val.phoneNo + " </span></td>" +
                    "<td  class='rownum'> <span class='WordWrap'>" + val.statuscategorydesc + "</span></td>" +
                    "<td class='rownum'  style='direction: ltr;' > <span  class='WordWrap'>" + getformatteddate(val.statusdate) + "</span> </td>" +
                    "</tr>";
                $("#tblPAAETStatusContainer tbody").append(newRowContent);
                rowIndex++;
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
        fromdate: $('input[name="daterange"]').data('daterangepicker').startDate.format('YYYY-MM-DD'),
        todate: $('input[name="daterange"]').data('daterangepicker').endDate.format('YYYY-MM-DD'),
    };
    ajaxPostObjectHandler("/MINServices/GetDepartedDataByDateRangeByBirthDate", dataobject, function (response) {
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
        fromdate: $('input[name="daterange"]').data('daterangepicker').startDate.format('YYYY-MM-DD'),
        todate: $('input[name="daterange"]').data('daterangepicker').endDate.format('YYYY-MM-DD'),
    };
    ajaxPostObjectHandler("/MINServices/GetCivilServiceCommDataByDateRange", dataobject, function (response) {
        console.log(response)
        $("#tblCivilServiceCommStatusContainer tr:gt(0)").remove();
        if (response != null && response.data[0] != null) {
            var resp = response.data;

            $.each(resp, function (key, val) {

                show_hide_column('tblCivilServiceCommStatusContainer', 5, false); //hide finishReson col

                var newRowContent = "<tr  class='rowListView dataRow'>" +
                    "<td class='rownum'><span  class='WordWrap'>" + val.civilId + "</span></td>" +
                    "<td class='rownum'><span  class='WordWrap'>" + val.empName + " </span></td>" +
                    "<td class='rownum'><span  class='WordWrap'>" + val.category + " </span></td>" +
                    "<td class='rownum'><span  class='WordWrap'>" + val.job + " </span></td>" +
                    "<td  class='rownum' ><span class='WordWrap'>" + val.groupName + " </span></td>" +

                    /*"<td class='rownum'> <span  class='WordWrap'>" + val.finishReson + "</span> </td>" +*/
                    "<td  class='rownum' > <span class='WordWrap'>" + val.min + "</span></td>" +
                    "</tr>";
                $("#tblCivilServiceCommStatusContainer tbody").append(newRowContent);
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
        fromdate: $('input[name="daterange"]').data('daterangepicker').startDate.format('YYYY-MM-DD'),
        todate: $('input[name="daterange"]').data('daterangepicker').endDate.format('YYYY-MM-DD'),
    };
    ajaxPostObjectHandler("/MINServices/GetKuwaitUniDataByDateRange", dataobject, function (response) {
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
        fromdate: $('input[name="daterange"]').data('daterangepicker').startDate.format('YYYY-MM-DD'),
        todate: $('input[name="daterange"]').data('daterangepicker').endDate.format('YYYY-MM-DD'),
    };
    ajaxPostObjectHandler("/MINServices/GetPUCDataByDateRange", dataobject, function (response) {
        console.log(response)
        $("#tblPUCInfo tr:gt(0)").remove();
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
                    $("#tblPUCInfo tbody").append(newRowContent);
                    index++;
                })


                //for (index = 0; index < resp.length; index++) {
                //    var newRowContent = "<tr  class='" + (index % 2 == 0 ? "rowListView" : "altrow") + " dataRow'>" +
                //        "<td class='rownum'><span  class='WordWrap'>" + (index + 1) + "</span></td>" +
                //        "<td class='rownum'><span  class='WordWrap'>" + resp[index].civilid + "</span></td>" +
                //        "<td class='rownum'><span  class='WordWrap'>" + resp[index].name + " </span></td>" +
                //        "<td class='rownum'><span  class='WordWrap'>" + resp[index].studentcase + " </span></td>" +
                //        "<td  class='rownum'><span  class='WordWrap'>" + resp[index].college + " </span> </td>" +
                //        "<td  class='rownum' ><span class='WordWrap'>" + resp[index].firstsemister + " </span></td>" +
                //        "<td  class='rownum'> <span class='WordWrap'>" + resp[index].certificate + "</span></td>" +
                //        "<td class='rownum'> <span  class='WordWrap'>" + resp[index].secondsemister + "</span> </td>" +
                //        "</tr>";

                //    $("#tblPUCInfo tbody").append(newRowContent);
                //}

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
        fromdate: $('input[name="daterange"]').data('daterangepicker').startDate.format('YYYY-MM-DD'),
        todate: $('input[name="daterange"]').data('daterangepicker').endDate.format('YYYY-MM-DD'),
    };
    ajaxPostObjectHandler("/MINServices/GetMinOfEduDataByDateRange", dataobject, function (response) {
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
        fromdate: $('input[name="daterange"]').data('daterangepicker').startDate.format('YYYY-MM-DD'),
        todate: $('input[name="daterange"]').data('daterangepicker').endDate.format('YYYY-MM-DD'),
    };
    ajaxPostObjectHandler("/MINServices/GetMinOHEduDataByDateRange", dataobject, function (response) {
        console.log(response)
        $("#tbldvMOHEInfo tr:gt(0)").remove();
        if (response != null && response.data[0] != null) {
            var resp = response.data;
            if (resp != null) {

                var index = 0;
                $.each(resp, function (key, val) {
                    var date = [padTo2Digits(val.day1), padTo2Digits(val.month1), val.year1].join('-');
                    var date = moment(val.column1).format('DD-MMM-YYYY');
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
        fromdate: $('input[name="daterange"]').data('daterangepicker').startDate.format('YYYY-MM-DD'),
        todate: $('input[name="daterange"]').data('daterangepicker').endDate.format('YYYY-MM-DD'),
    };
    //KAFMiscServices
    ajaxPostObjectHandler("/MINServices/GetMOIDataByDateRange", dataobject, function (response) {
        console.log(response)
        $("#tblMOItatusContainer tr:gt(0)").remove();
        if (response != null && response.data[0] != null) {
            var resp = response.data;
            if (resp != null) {
                var index = 0;

                document.getElementById("tblMOItatusContainer").getElementsByTagName('tr')[0].getElementsByTagName('th')[10].innerText = " Issue Date ";

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
                        "<td class='rownum'><span  class='WordWrap'>" + getformatteddate(val.issueDate) + " </span></td>" +

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
        fromdate: $('input[name="daterange"]').data('daterangepicker').startDate.format('YYYY-MM-DD'),
        todate: $('input[name="daterange"]').data('daterangepicker').endDate.format('YYYY-MM-DD'),
    };
    ajaxPostObjectHandler("/MINServices/GetMOIDataNewServiceByDateRange", dataobject, function (response) {
        console.log(response)
        $("#tblMOINewServiceStatusContainer tr:gt(0)").remove();
        if (response != null ) {
            var resp = response.data;
            if (resp != null) {
                var index = 0;

                //Change Existing column name of the table
                document.getElementById("tblMOINewServiceStatusContainer").getElementsByTagName('tr')[0].getElementsByTagName('th')[2].innerText = "Type";
                document.getElementById("tblMOINewServiceStatusContainer").getElementsByTagName('tr')[0].getElementsByTagName('th')[3].innerText = "Birth Date";
                show_hide_column('tblMOINewServiceStatusContainer', 4, false); //hide employmentDays col
                show_hide_column('tblMOINewServiceStatusContainer', 5, false); //hide statusMessage col
                //******************//

                $.each(resp, function (key, val) {
                    var newRowContent = "<tr  class='" + (index % 2 == 0 ? "rowListView" : "altrow") + " dataRow'>" +

                        "<td class='rownum'><span  class='WordWrap'>" + val.civilIdNumber + "</span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.personName + " </span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.type + " </span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + getformatteddate(val.birthDate) + " </span></td>" +
                        //"<td class='rownum'><span  class='WordWrap'>" + val.employmentDays + " </span></td>" +
                        //"<td class='rownum'><span  class='WordWrap'>" + val.statusMessage + " </span></td>" +
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
        fromdate: $('input[name="daterange"]').data('daterangepicker').startDate.format('YYYY-MM-DD'),
        todate: $('input[name="daterange"]').data('daterangepicker').endDate.format('YYYY-MM-DD'),
    };
    ajaxPostObjectHandler("/MINServices/GetKSFDDataByDateRange", dataobject, function (response) {
        console.log(response)
        $("#tbldvKFSDInfo tr:gt(0)").remove();
        if (response != null && response.data[0] != null) {
            var resp = response.data;
            if (resp != null) {
               
                var index = 0;
                $.each(resp, function (key, val) {
                        var newRowContent = "<tr  class='" + (index % 2 == 0 ? "rowListView" : "altrow") + " dataRow'>" +
                            "<td class='rownum'><span  class='WordWrap'>" + val.emp_civil_id + "</span></td>" +
                            "<td class='rownum'><span  class='WordWrap'>" + val.emp_name + " </span></td>" +
                            "<td class='rownum'><span  class='WordWrap'>" + getformatteddate(val.emp_birthdate) + "</span></td>" +
                            "<td class='rownum'><span  class='WordWrap'>" + val.hire_status_desc + "</span></td>" +
                            "</tr>";
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
function loadDisabledData() {
    var dataobject = {
        fromdate: $('input[name="daterange"]').data('daterangepicker').startDate.format('YYYY-MM-DD'),
        todate: $('input[name="daterange"]').data('daterangepicker').endDate.format('YYYY-MM-DD'),
    };
    ajaxPostObjectHandler("/MINServices/GetDisabledDataDateRange", dataobject, function (response) {
        console.log(response)
        $("#tbldvDisabledDataContainer tr:gt(0)").remove();
        if (response != null && response.data[0] != null) {
            var resp = response.data;
            if (resp != null) {
                var index = 0;
                $.each(resp, function (key, val) {
                    //console.log(val)

                    show_hide_column('tbldvDisabledDataContainer', 2, false); //hide sex col
                    show_hide_column('tbldvDisabledDataContainer', 3, false); //hide nationality col
                    show_hide_column('tbldvDisabledDataContainer', 7, false); //hide fileStatus col
                    show_hide_column('tbldvDisabledDataContainer', 10, false); //hide mobile col
                    show_hide_column('tbldvDisabledDataContainer', 11, false); //hide telephone col

                    if (val.wsMessage == "OK") {
                        var newRowContent = "<tr  class='rowListView dataRow'>" +
                            "<td class='rownum'><span  class='WordWrap'>" + val.civilNumber + "</span></td>" +
                            "<td class='rownum'><span  class='WordWrap'>" + val.disabledName + " </span></td>" +
                            "<td  class='rownum' style='direction: ltr;'><span class='WordWrap'>" + val.birthDate + " </span></td>" +
                            "<td class='rownum'><span  class='WordWrap'>" + val.disabilityType + " </span></td>" +
                            "<td class='rownum'><span  class='WordWrap'>" + val.disabilitySeverity + " </span></td>" +
                            "<td  class='rownum' style='direction: ltr;'> <span class='WordWrap'>" + val.disabilityDate + "</span></td>" +
                            "<td class='rownum'><span  class='WordWrap'>" + val.disabilityValidity + " </span></td>" +
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
function loadKPCData() {
    $("#tblkpcServiceContainer tr:gt(0)").remove();
    var newRowContent = "<tr  class='loadingrow dataRow'><td colspan='12' style='text-align: center;' class='rownum'><span  class='WordWrap'><img src='/img/loading_small.gif' alt='loading data'/></span></td> </tr>";
    $("#tblkpcServiceContainer tbody").append(newRowContent);

    var dataobject = {
        fromdate: $('input[name="daterange"]').data('daterangepicker').startDate.format('YYYY-MM-DD'),
        todate: $('input[name="daterange"]').data('daterangepicker').endDate.format('YYYY-MM-DD'),
    };
    ajaxPostObjectHandler("/MINServices/GetKPCDataByDateRange", dataobject, function (response) {
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
        fromdate: $('input[name="daterange"]').data('daterangepicker').startDate.format('YYYY-MM-DD'),
        todate: $('input[name="daterange"]').data('daterangepicker').endDate.format('YYYY-MM-DD'),
    };

    //PUC Financial Info Start
    ajaxPostObjectHandler("/MINServices/GetPUCFinDataByDateRange", dataobject, function (response) {
        console.log(response)
        $("#tblPUCFinancialInfo tr:gt(0)").remove();
        if (response != null && response.data[0] != null) {
            var resp = response.data;

            if (resp != null) {

                var index = 0;

                document.getElementById("tblPUCFinancialInfo").getElementsByTagName('tr')[0].getElementsByTagName('th')[4].innerText = " تاريخ الميلاد ";

                $.each(resp, function (key, val) {
                    var newRowContent = "<tr  class='" + (index % 2 == 0 ? "rowListView" : "altrow") + " dataRow'>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.civilid + "</span></td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.name + " </span></td>" +
                        "<td  class='rownum' ><span class='WordWrap'>" + val.speciality + " </span></td>" +
                        "<td  class='rownum'><span  class='WordWrap'>" + val.universityname + " </span> </td>" +
                        "<td class='rownum'><span  class='WordWrap'>" + val.bdate + " </span></td>" +
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
        fromdate: $('input[name="daterange"]').data('daterangepicker').startDate.format('YYYY-MM-DD'),
        todate: $('input[name="daterange"]').data('daterangepicker').endDate.format('YYYY-MM-DD'),
    };
    console.log(dataobject)

    ajaxPostObjectHandler("/MINServices/GetPIFSSDataByDateRange", dataobject, function (response) {
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
function loadKNG() {

    $("#dbkng_summary").addClass("hidden");

    $(".dvKNGInfo").css("overflow-y", "").css("overflow-x", "hidden").css("height", "300px");

    $("#dbkng_summary").before("<div id='dvClear_KNG' style='margin-top: 15px;margin-bottom: 15px; margin-left: 15px;width: 30%;float: left;text-align: left;'>" +
        "<button  onclick='return cancel_ajax_req(\"btnkng\");'><i class='fa fa-remove' style='color:red'></i> Cancel Request</button></div>");

    $("#tbldvKNGInfo tr:gt(0)").remove();
    var newRowContent = "<tr  class='loadingrow dataRow'><td colspan='8' style='text-align: center;' class='rownum'><span  class='WordWrap'><img src='https://uploads.kns.gov.kw/NSUploadFolder/StaticUrlKns/Admin/loading_small.gif' alt='loading data'/></span></td> </tr>";

    $("#tbldvKNGInfo tbody").append(newRowContent);

    var dataobject = {
        fromdate: $('input[name="daterange"]').data('daterangepicker').startDate.format('YYYY-MM-DD'),
        todate: $('input[name="daterange"]').data('daterangepicker').endDate.format('YYYY-MM-DD'),
    };

    ajaxPostObjectHandler("/MINServices/GetKNGDataByDateRange", dataobject, function (response) {
        console.log(response)
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


function show_hide_column(id_of_table, col_no, do_show) {
    var stl;
    if (do_show) stl = 'block'
    else stl = 'none';


    //document.getElementById(id_of_table).getElementsByTagName('tr')[0].getElementsByTagName('th')
    var tbl = document.getElementById(id_of_table);
    var rows = tbl.getElementsByTagName('tr');

    /*for (var row = 0; row < rows.length; row++) {*/
    var cels = rows[0].getElementsByTagName('th')
    cels[col_no].style.display = stl;
    //}
}