
(function ($) {

    "use strict";

    var methods = {
        init: function (options) {

        },
        show: function () { },// IS
        hide: function () { },// GOOD
        update: function (content) { }// !!!
    };

    var headerauth = $("#txtwebapitoken").val();
    var baseurl = $('#txtBaseUrl').val();
    var apiURL = $('#txtapiURL').val();
    $.fn.kafCustomUnitListbox = function (options) {
        var defaults = {
            _lebeltext: '_lebeltext',
            _divid: '_divid',
            _data: '_data',
            _readonly: 'true',
            _apiurl: '_apiurl',
            _controllername: '_controllername',
            _actionname: '_actionname',
            _modelname: '_modelname',
            _primkeyname: '_primkeyname',
            _primetextname: '_primetextname',
            _firsttimekeyvaluetoload: '-99',
            _searchbuttontext: '_searchbuttontext',
            _searchgrouplabel: '_searchgrouplabel',
            _callbackmehtodname: '_callbackmehtodname',
            _isrequredtoprocess: false,
            _isrequredtext: '_isrequredtext'
        };

        var options = $.extend({}, defaults, options);


        var stringbuilder = '';
        var dir = $("html").attr("dir");
        this.initialize = function () {

            stringbuilder = '<div class="form-group">';

            if (!options._isrequredtoprocess) {
                stringbuilder += '   <label class="labelNormal " >' + options._lebeltext + '</label>';
            }
            else
                stringbuilder += '   <label class="labelNormal required" >' + options._lebeltext + '</label>';

            stringbuilder += '   <input type="hidden" id="selectedParentLabel" value="" readonly tooltip="Parent Unit" />';
            stringbuilder += '   <input type="hidden" id="hastreeview_parentkey" value="" readonly tooltip="Selected Unit" />';
            stringbuilder += '   <input type="hidden" id="hastreeview_parentkeytext" value="" readonly tooltip="parent Unit Text" />';
            stringbuilder += '   <input type="hidden" id="hastreeview_selectedkey" value="" readonly />';

            stringbuilder += '   <div class="form-group">';
            if (!options._isrequredtoprocess) {
                stringbuilder += '   <input type="text" name="hastreeview_selectedtext" id="hastreeview_selectedtext"  value="" disabled readonly style="font-size:18px;font-weight:bold;    width:462px ;background-color:white;border:none;" />';
            }
            else {
                stringbuilder += '   <input type="text" name="hastreeview_selectedtext" id="hastreeview_selectedtext"  value="" disabled readonly style="font-size:18px;font-weight:bold;    width:462px ;background-color:white;border:none;" class="form-control input-validation-error" data-val="true" data-val-required="ادخال فصيلة الدم" aria-describedby="hastreeview_selectedtext-error"/>';
                stringbuilder += '   <span class="field-validation-valid text-danger" data-valmsg-for="hastreeview_selectedtext" data-valmsg-replace="true"></span>';
            }
            stringbuilder += '   </div>';


            stringbuilder += '   <div id="MySearch">';
            stringbuilder += '     <label class="labelNormal required" >' + options._searchgrouplabel + '</label>';
            stringbuilder += '     <input type="text" title="Use \'Tab key\' to search" id="hastreeview_search" value="" style="font-size:18px;font-weight:bold;margin-left: 40px;  width: 386px;"  />';
            stringbuilder += '     <button type="button" id="btnbacklist" class="btn btn-primary btn-md btnbacklist" style="margin-bottom: 5px;">' + options._searchbuttontext + '</button>';
            stringbuilder += '   </div>';

            stringbuilder += '';
            stringbuilder += '';

            stringbuilder += '   <br />';
            stringbuilder += '  <div id="DivListPlaceHolder">';
            stringbuilder += '      <select  class="customunitselect" size="14" style="width:550px;font-weight:bold;" id="customunitselect" name="selectionField" multiple="no" >';
            stringbuilder += '      </select>';
            stringbuilder += '  </div > ';
            stringbuilder += '</div>';
            stringbuilder += '';
            stringbuilder += '';

            this.append(stringbuilder);
            return this;

        };


        $(document).ready(function () {
            if (options._firsttimekeyvaluetoload != -99) {

                $(hastreeview_selectedtext).val(options._primetextname);
                $("#selectedParentLabel").html($(hastreeview_selectedtext).val());
                $(hastreeview_selectedkey).val(options._firsttimekeyvaluetoload);
                
                LoadCurentParentKey(options._firsttimekeyvaluetoload,'');
                load_unit_list(options._firsttimekeyvaluetoload, '');
                if (options._callbackmehtodname != "") window[options._callbackmehtodname]($('#hastreeview_selectedkey').val());
            }
            else load_unit_list(-99, '');
        });

        function load_unit_list(key, keyname) {
            try {
                $("#customunitselect").empty();

                var keyentitykey = (key != '-99' ? key : '');
                var keyentityname = (keyname != '-99' ? keyname : '');
                console.log(keyentitykey);
                console.log(keyentityname);
                var dataobject = {
                    entitykey: keyentitykey,
                    entityname: keyentityname,
                };

                ajaxPostObjectHandler("/UnitListBox/GetOrganization", dataobject, function (response) {
                    if (response != '') {

                        var data = response.data;
                        console.log(data);
                        if ($('#customunitselect').prop) {
                            var options = $('#customunitselect').prop('options');
                        }
                        else {
                            var options = $('#customunitselect').attr('options');
                        }
                        $('option', $('#customunitselect')).remove();

                        $.each(data, function (val, item) {
                            options[options.length] = new Option(item.Text, item.Id);
                        });

                        if ($("#hastreeview_parentkey").val() == '10000010' && $("#hastreeview_selectedkey").val() == '10000010') {
                            $("#btnbacklist").attr("disabled", "disabled");
                        }
                        else
                            $("#btnbacklist").removeAttr("disabled");
                    }
                    else
                        return;
                }, true);
            } catch (e) {
                $.alert({
                    title: "_informationTitle",
                    content: e.message,
                    type: 'red'
                });
            }
        }
        $('body').on('change', '.customunitselect', function (event) {
            try {
                if (event.handled !== true) {
                    event.handled = true;
                    $('#hastreeview_search').val('');
                    $("#hastreeview_selectedtext").val($(this).find('option:selected').text());
                    $("#selectedParentLabel").html($("#hastreeview_selectedtext").val());
                    $("#hastreeview_selectedkey").val(this.value);

                    LoadCurentParentKey(this.value, '');
                    load_unit_list($("#hastreeview_selectedkey").val());

                    if ($("#hastreeview_parentkey").val() == '') {
                        $("#btnbacklist").attr("disabled", "disabled");
                    }
                    else
                        $("#btnbacklist").removeAttr("disabled");

                    if (options._callbackmehtodname != "") window[options._callbackmehtodname]($('#hastreeview_selectedkey').val());
                    return;
                }
            } catch (e) {
                $.alert({
                    title: "_informationTitle",
                    content: e.message,
                    type: 'red'
                });
            }

        });
        
        function LoadCurentParentKey(key, keyname) {
            try {

                $.ajax({
                    type: "GET",
                    data: { "keyEntityKey": key },
                    async: false,
                    url: apiURL + 'api/Unit/getunitParentKeyforReport',
                    headers: {
                        "Authorization": headerauth,
                        "Content-Type": "application/json",
                    },
                    success: function (response) {
                        if (response.str != "") {
                            var data = JSON.parse(response.str);

                            for (var i = 0; i < data.length; i++) {
                                $("#hastreeview_parentkey").val(data[i].Id);
                                $("#hastreeview_parentkeytext").val(data[i].Text);
                            }
                        }
                    },
                    error: function (xhr) {
                        console.log(xhr);
                    }
                });

            } catch (e) {
                $.alert({
                    title: _getCookieForLanguage("_informationTitle"),
                    content: e.message,
                    type: 'red'
                });
            }
        }
        function LoadCurentunitName(key, keyname) {
            try {

                $.ajax({
                    type: "GET",
                    data: { "keyEntityKey": (key != '-99' ? key : ''), "keyEntityName": (keyname != '' ? keyname : '') },
                    async: false,
                    url: apiURL + 'api/Unit/KAF_GetUnit',
                    headers: {
                        "Authorization": headerauth,
                        "Content-Type": "application/json",
                    },
                    success: function (response) {

                        var data = JSON.parse(response.str);

                        for (var i = 0; i < data.length; i++) {
                            $("#selectedParentLabel").html(data[i].Text);
                        }
                    },
                    error: function (xhr) {
                        console.log(xhr);
                    }
                });

            } catch (e) {
                $.alert({
                    title: _getCookieForLanguage("_informationTitle"),
                    content: e.message,
                    type: 'red'
                });
            }
        }
        $('body').on('click', '#btnbacklist', function (event) {
            try {
                $('#hastreeview_search').val('');
                if ($("#hastreeview_parentkey").val() == '') {
                    //alert("reached end of list.");
                    $.alert({
                        title: _getCookieForLanguage("_informationTitle"),
                        content: "Reached end of list.",
                        type: 'red'
                    });
                    return false;

                }
                else {
                    $("#hastreeview_selectedkey").val($("#hastreeview_parentkey").val());

                    $("#hastreeview_selectedtext").val($("#hastreeview_parentkeytext").val());
                    LoadCurentParentKey($("#hastreeview_selectedkey").val(), '');
                    load_unit_list($("#hastreeview_selectedkey").val(), '');

                    LoadCurentunitName($("#hastreeview_selectedkey").val(), '');

                    if (options._callbackmehtodname != "") window[options._callbackmehtodname]($('#hastreeview_selectedkey').val());
                }

            } catch (e) {
                $.alert({
                    title: _getCookieForLanguage("_informationTitle"),
                    content: e.message,
                    type: 'red'
                });
            }

        });
        $('body').on('keydown', '#hastreeview_search', function (e) {
            try {

                var code = e.keyCode || e.which;
                if (code === 9) {
                    e.preventDefault();
                    load_unit_list('-99', this.value);
                }
            }
            catch (e) {
                $.alert({
                    title: _getCookieForLanguage("_informationTitle"),
                    content: e,
                    type: 'red'
                });
            }

        });

        //function getSelectedTextAndIDArray()
        //var arrayselectedtext = $("#hastreeview_selectedtext").html().split("-");
        //return arrayselectedtext;

        return this.initialize();
    }   
}) (jQuery);




