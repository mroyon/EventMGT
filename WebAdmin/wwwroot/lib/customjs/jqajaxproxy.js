
/*!
 * Ajax Get/Post Proxy functions JavaScript Library v1.0
 *
 * Copyright Mahmudur rahman Foundation and other contributors
 * Released under the MIT license
 * https://jquery.org/license
 * Date: 2021-03-02T17:08Z
 */

'use strict';


//const { Alert } = require("bootstrap");

var methodTypePost = "POST";
var methodTypeGet = "GET";


var ajaxPostObjectHandlerWithFiles = function (url, parameters, func, isStringify) {

    function onSuccess(response) {
        if (response.success == true) {
            showInformationAlert(response._ajaxresponse.responsetitle, response._ajaxresponse.responsetext, "OK");
        }
        else if (response.success == false) {
            showErrorAlert(response._ajaxresponse.responsetitle, response._ajaxresponse.responsetext, "OK");
        }

        if (response === 'SESSION_EXPIRED') {
            showInformationAlert("Error", "Your session is expired. Please login to continue.", "OK");
            window.location.href = '/Account/login';
        }
        else if (response === 'SESSION_EXPIRED') {
            showInformationAlert("Error", "Your session is expired. Please login to continue.", "OK");
            window.location.href = '/Account/login';
        }
        else
            func(response);
    };
    try {
        PostObjectProxyWithFiles(url, parameters, onSuccess, isStringify);
    } catch (e) {
        showErrorAlert("Error", e.message, "OK");
    }
};

function PostObjectProxyWithFiles(url, params, successCallback, isStringify = false) {

    if (url == "") {
        return;
    }

    if (params != null) {
        params = isStringify == false ? params : JSON.stringify(params);
    }
    else {
        var params = "";
    }
    var tokenValue = $('#X-CSRF-TOKEN-WEBADMINHEADER').val();

    try {

        $.ajax({
            type: methodTypePost,
            url: url,
            data: params,
            async: true,
            //cache: false,
            dataType: "json",
            processData: false,
            contentType: false,

            headers: {
                'X-CSRF-TOKEN-WEBADMINHEADER': tokenValue
            },
            beforeSend: function () {
                $('#divprogress').show();
            },
            success: successCallback,
            error: function (xhr, textStatus, errorThrown) {
                $('#divprogress').hide();
                showErrorAlert("Error", errorThrown, "OK");
            },
            failure: function (response) {
                showErrorAlert("Error", response, "OK");
            },
            complete: function () {
                $('#divprogress').hide();
            },
        });

    } catch (e) {
        showErrorAlert("Error", e.message, "OK");
    }

};



function PostObjectProxy(url, params, successCallback, isStringify = false) { 

    if (url == "") {
        return;
    }

    if (params != null) {
        params = isStringify == false ? params : JSON.stringify(params);
    }
    else {
        var params = "";
    }
    var tokenValue = $('#X-CSRF-TOKEN-WEBADMINHEADER').val();

    try {

        $.ajax({
            type: methodTypePost,
            url: url,
            data: params,
            async: false,
            cache: false,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            headers: {
                'X-CSRF-TOKEN-WEBADMINHEADER': tokenValue
            },
            beforeSend: function () {
                $('#divprogress').show();
            },
            success: successCallback,
            error: function (xhr, textStatus, errorThrown) {
                $('#divprogress').hide();
                //alert("error");
                showErrorAlert("Error", errorThrown, "OK");
            },
            failure: function (response) {
                //alert("failure");
                showErrorAlert("Error", response, "OK");
            },
            complete: function () {
                $('#divprogress').hide();
            },
        });

    } catch (e) {
        showErrorAlert("Error", e.message, "OK");
    }
};
var ajaxPostObjectHandler = function (url, parameters, func, isStringify) {

    function onSuccess(response) {
        //console.log(response)
        if (response.success == true) {
            showInformationAlert(response._ajaxresponse.responsetitle, response._ajaxresponse.responsetext, "OK");
        }
        else if (response.success == false) {
            showErrorAlert(response._ajaxresponse.responsetitle, response._ajaxresponse.responsetext, "OK");
        }

        if (response === 'SESSION_EXPIRED') {
            showInformationAlert("Error", "Your session is expired. Please login to continue.", "OK");
            window.location.href = '/Account/login';
        }
        else if (response === 'SESSION_EXPIRED') {
            showInformationAlert("Error", "Your session is expired. Please login to continue.", "OK");
            window.location.href = '/Account/login';
        }
        else
            func(response);
    };
    try {
        PostObjectProxy(url, parameters, onSuccess, isStringify);
    } catch (e) {
        showErrorAlert("Error", e.message, "OK");
    }
};

function PostParamsProxy(url, params, successCallback, isStringify = false) {

    if (url == "") {
        return;
    }

    if (params != null) {
        params = isStringify == false ? params : JSON.stringify(params);
    }
    else {
        var params = "";
    }
    var tokenValue = $('#X-CSRF-TOKEN-WEBADMINHEADER').val();

    try {

        $.ajax({
            type: methodTypePost,
            url: url,
            data: params,
            async: false,
            cache: false,
            //dataType: "json",
            //contentType: "application/json; charset=utf-8",
            headers: {
                'X-CSRF-TOKEN-WEBADMINHEADER': tokenValue
            },
            beforeSend: function () {
                $('#divprogress').show();
            },
            success: successCallback,
            error: function (xhr, textStatus, errorThrown) {
                $('#divprogress').hide();
                showErrorAlert("Error", errorThrown, "OK");
            },
            failure: function (response) {
                showErrorAlert("Error", response, "OK");
            },
            complete: function () {
                $('#divprogress').hide();
            },
        });

    } catch (e) {
        showErrorAlert("Error", e.message, "OK");
    }

};
var ajaxPostParamsHandler = function (url, parameters, func, isStringify) {

    function onSuccess(response) {

        if (response.success == true) {
            showInformationAlert(response._ajaxresponse.responsetitle, response._ajaxresponse.responsetext, "OK");
        }
        else if (response.success == false) {
            showErrorAlert(response._ajaxresponse.responsetitle, response._ajaxresponse.responsetext, "OK");
        }

        if (response === 'SESSION_EXPIRED') {
            showInformationAlert("Error", "Your session is expired. Please login to continue.", "OK");
            window.location.href = '/Account/login';
        }
        else
            func(response);
    };
    try {
        PostParamsProxy(url, parameters, onSuccess, isStringify);
    } catch (e) {
        showErrorAlert("Error", e.message, "OK");
    }
};

function GetProxy(url, params, successCallback, isStringify = false) {

    if (url == "") {
        return;
    }

    if (params != null)
        params = isStringify == false ? params : JSON.stringify(params);
    else
        params = "";

    var tokenValue = $('#X-CSRF-TOKEN-WEBADMINHEADER').val();

    try {
        $.ajax({
            type: methodTypeGet,
            url: url,
            data: params,
            contentType: "application/json",
            async: false,
            cache: false,
            headers: {
                'X-CSRF-TOKEN-WEBADMINHEADER': tokenValue
            },
            beforeSend: function () {
                $('#divprogress').show();
            },
            success: successCallback,
            error: function (xhr, textStatus, errorThrown) {
                $('#divprogress').hide();
                showErrorAlert("Error", errorThrown, "OK");
            },
            failure: function (response) {
                showErrorAlert("Error", response, "OK");
            },
            complete: function () {
                $('#divprogress').hide();
            },
        });
    } catch (e) {
        showErrorAlert("Error", e.message, "OK");
    }

};
var ajaxGetHandler = function (url, parameters, func, isStringify) {

    function onSuccess(response) {
        if (response === 'SESSION_EXPIRED') {
            showInformationAlert("Error", "Your session is expired. Please login to continue.", "OK");
            window.location.href = '/Account/login';
        }
        else
            func(response);
    };
    try {
        GetProxy(url, parameters, onSuccess, isStringify);
    } catch (e) {
        showErrorAlert("Error", e.message, "OK");
    }
};


var ajaxPostObjectWebApiHandler = function (url, parameters, func, isStringify, token) {

    function onSuccess(response) {
        //console.log(response)
        if (response.success == true) {
            showInformationAlert(response._ajaxresponse.responsetitle, response._ajaxresponse.responsetext, "OK");
        }
        else if (response.success == false) {
            showErrorAlert(response._ajaxresponse.responsetitle, response._ajaxresponse.responsetext, "OK");
        }

        if (response === 'SESSION_EXPIRED') {
            showInformationAlert("Error", "Your session is expired. Please login to continue.", "OK");
            window.location.href = '/Account/login';
        }
        else if (response === 'SESSION_EXPIRED') {
            showInformationAlert("Error", "Your session is expired. Please login to continue.", "OK");
            window.location.href = '/Account/login';
        }
        else
            func(response);
    };
    try {
        PostObjectProxyWebApi(url, parameters, onSuccess, isStringify, token);
    } catch (e) {
        showErrorAlert("Error", e.message, "OK");
    }
};
function PostObjectProxyWebApi(url, params, successCallback, isStringify = false, tokenValue) {

    if (url == "") {
        return;
    }

    if (params != null) {
        params = isStringify == false ? params : JSON.stringify(params);
    }
    else {
        var params = "";
    }

    try {

        $.ajax({
            type: methodTypePost,
            url: url,
            data: params,
            async: false,
            cache: false,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            headers: {
                //'X-CSRF-TOKEN-WEBADMINHEADER': tokenValue
                Authorization: 'Bearer ' + tokenValue
            },
            beforeSend: function () {
                $('#divprogress').show();
            },
            success: successCallback,
            error: function (xhr, textStatus, errorThrown) {
                $('#divprogress').hide();
                //alert("error");
                showErrorAlert("Error", errorThrown, "OK");
            },
            failure: function (response) {
                //alert("failure");
                showErrorAlert("Error", response, "OK");
            },
            complete: function () {
                $('#divprogress').hide();
            },
        });

    } catch (e) {
        showErrorAlert("Error", e.message, "OK");
    }
};
/// CALLING PROCS
/*
 
// GET 
 ajaxGetHandler("/Account/ChangePassword", { returnUrl: "/"}, function (data) {

            $('#modal-content-common').html('');
                $('#modal-content-common').html(data);
                $('#modal-container-common').modal({ backdrop: 'static', keyboard: false });

        }, false, false);

-------------------

var dataobject = { culture: culture, returnUrl: returnUrl };

// multiple params post
        ajaxPostParamsHandler("/Home/SetLanguage", dataobject, function (data) {
            if (data !== "INVALID_PARAMETERS") {
                window.location.reload();
            }
            else {
                alert("There is a problem on server side. Please try again later.");
            }
        }, false);

//// multiple params post
//ajaxPostParamsHandler("/Home/SetLanguage", dataobject, function (data) {
//    if (data !== "INVALID_PARAMETERS") {
//        alert("There is a problem on server side. Please try again later.");

//        window.location.reload();
//    }
//    else {
//        alert("There is a problem on server side. Please try again later.");
//    }
//}, false);


//single object post
ajaxPostObjectHandler("/Home/SetLanguage2", dataobject, function (data) {
    if (data !== "INVALID_PARAMETERS") {
        alert("There is a problem on server side. Please try again later.");

        window.location.reload();
    }
    else {
        alert("There is a problem on server side. Please try again later.");
    }
}, true);


        /// <summary>
        /// SetLanguage
        /// </summary>
        /// <param name="objlangmodel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SetLanguage2([FromBody] testmodel objlangmodel)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(objlangmodel.culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1), Secure = true, SameSite = SameSiteMode.Strict }
            );
            return LocalRedirect(objlangmodel.returnUrl);
        }
 
 
 */