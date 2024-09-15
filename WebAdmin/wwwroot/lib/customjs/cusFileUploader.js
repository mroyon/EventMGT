
function fileSizeSI(size) {

    if (!isNaN(parseFloat(size)) && isFinite(size)) {

        var e = (Math.log(size) / Math.log(1e3)) | 0;
        var strret = +(size / Math.pow(1e3, e)).toFixed(2) + ' ' + ('kMGTPEZY'[e - 1] || '') + 'B';

        return strret;
    }
    else
        return size;
}
function base64ArrayBuffer(arrayBuffer) {
    var base64 = ''
    var encodings = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/'

    var bytes = new Uint8Array(arrayBuffer)
    var byteLength = bytes.byteLength
    var byteRemainder = byteLength % 3
    var mainLength = byteLength - byteRemainder

    var a, b, c, d
    var chunk

    // Main loop deals with bytes in chunks of 3
    for (var i = 0; i < mainLength; i = i + 3) {
        // Combine the three bytes into a single integer
        chunk = (bytes[i] << 16) | (bytes[i + 1] << 8) | bytes[i + 2]

        // Use bitmasks to extract 6-bit segments from the triplet
        a = (chunk & 16515072) >> 18 // 16515072 = (2^6 - 1) << 18
        b = (chunk & 258048) >> 12 // 258048   = (2^6 - 1) << 12
        c = (chunk & 4032) >> 6 // 4032     = (2^6 - 1) << 6
        d = chunk & 63               // 63       = 2^6 - 1

        // Convert the raw binary segments to the appropriate ASCII encoding
        base64 += encodings[a] + encodings[b] + encodings[c] + encodings[d]
    }

    // Deal with the remaining bytes and padding
    if (byteRemainder == 1) {
        chunk = bytes[mainLength]

        a = (chunk & 252) >> 2 // 252 = (2^6 - 1) << 2

        // Set the 4 least significant bits to zero
        b = (chunk & 3) << 4 // 3   = 2^2 - 1

        base64 += encodings[a] + encodings[b] + '=='
    } else if (byteRemainder == 2) {
        chunk = (bytes[mainLength] << 8) | bytes[mainLength + 1]

        a = (chunk & 64512) >> 10 // 64512 = (2^6 - 1) << 10
        b = (chunk & 1008) >> 4 // 1008  = (2^6 - 1) << 4

        // Set the 2 least significant bits to zero
        c = (chunk & 15) << 2 // 15    = 2^4 - 1

        base64 += encodings[a] + encodings[b] + encodings[c] + '='
    }

    return base64
}

function formatBytes(bytes, decimals = 0) {
    if (!+bytes) return '0 Bytes'

    const k = 1024
    const dm = decimals < 0 ? 0 : decimals
    const sizes = ['Bytes', 'KB', 'MB', 'GB', 'TB', 'PB', 'EB', 'ZB', 'YB']

    const i = Math.floor(Math.log(bytes) / Math.log(k))

    return `${parseFloat((bytes / Math.pow(k, i)).toFixed(dm))} ${sizes[i]}`
}


(function ($) {

    "use strict";

    var methods = {
        init: function (options) {

        },
        show: function () { },// IS
        hide: function () { },// GOOD
        update: function (content) { }// !!!
    };

    $.fn.kaffileUploader = function (options) {

        var defaults = {
            _tableid: '_defaulttableid',
            _fileuploadbuttontext: 'defaultfileuploadbuttontext',
            _fileinputname: 'defaultupload',
            _containeruploadpreview: 'defaultcontainer',
            _containerdeletebuttontext: '',
            _ismultiple: true,
            _uploadedfileextension: '',
            _fileobject: null
        };

        var options = $.extend({}, defaults, options);

        $.fn.kaffileUploader.GetFilesForActions = function (val) {

            var fileobjects = [];
            $('#' + val + " div.wrapperiv").each(function (i, el) {

                var actualfilename = $(this).find('span.filename').text();
                var filename = $(this).find('input.filename').val();
                var imgdata = $(this).find('img').attr('src');
                var filetype = $(this).find('input.filetype').val();
                var fileextension = $(this).find('input.fileextension').val();
                var filesize = $(this).find('span.filesize').text();

                var filepath = $(this).find('input.filepath').val();
                var fileid = $(this).find('input.fileid').val();
                var currentstate = $(this).find('input.currentstate').val();
                var CurrentState = 0;

                if (currentstate == "Added") CurrentState = 1;
                if (currentstate == "Unchanged") CurrentState = 2; // Update other fields but do not change or update file
                else if (currentstate == "Deleted") CurrentState = 3;
                //else CurrentState = 0;

                var actualfilename = actualfilename.split('.').shift();

                if (fileid > 0)
                    filename = filename;
                else
                    filename = Date.now().toString(36).toUpperCase() + (Math.random() * 100000000000000000).toString(36).toUpperCase();

                var fileobject = {
                    "fileid": fileid,
                    "filepath": filepath,
                    "actualfilename": actualfilename,
                    "filename": filename,
                    "filetype": filetype,
                    "extension": fileextension,
                    "filesize": filesize,
                    "currentstate": currentstate,
                    "CurrentState": CurrentState
                };
                fileobjects.push(fileobject);
            });

            return fileobjects;
        };


        var stringbuilder = '';
        var dir = $("html").attr("dir");
        if (dir == "rtl") {
            this.initialize = function () {
                stringbuilder = '<div class="custom-file" id="upload_button">';
                if (options._containerdeletebuttontext != '') {

                    if (options._uploadedfileextension == '') {
                        if (options._ismultiple)
                            stringbuilder += '<input type="file" accept=".doc, .docx, .pdf, .xls, .xlsx, .jpg, .png, .jpeg, .gif, .bmp, .tif, .tiff|image/*" ngf-select ng-model="new_files" id="' + options._fileinputname + '" ng-change="fs.uploadFiles(new_files)" multiple>';
                        else
                            stringbuilder += '<input type="file" accept=".doc, .docx, .pdf, .xls, .xlsx, jpg, .png, .jpeg, .gif, .bmp, .tif, .tiff|image/*" ngf-select ng-model="new_files" id="' + options._fileinputname + '" ng-change="fs.uploadFiles(new_files)">';
                    }
                    else {
                        if (options._ismultiple)
                            stringbuilder += '<input type="file" accept="' + options._uploadedfileextension + '" ngf-select ng-model="new_files" id="' + options._fileinputname + '" ng-change="fs.uploadFiles(new_files)" multiple>';
                        else
                            stringbuilder += '<input type="file" accept="' + options._uploadedfileextension + '" ngf-select ng-model="new_files" id="' + options._fileinputname + '" ng-change="fs.uploadFiles(new_files)">';
                    }
                    stringbuilder += '<label class="custom-file-label" for="' + options._fileinputname + '">Choose file</label>';
                }
                stringbuilder += '</div>';

                stringbuilder += '<div   id="' + options._tableid + '">';

                stringbuilder += '<div class="row" min-height:200px;"  id="' + options._containeruploadpreview + '">';


                stringbuilder += '</div>';
                stringbuilder += '</div>';

                stringbuilder += '';

                this.append(stringbuilder);
                return this;
            };
        } else {
            this.initialize = function () {

                stringbuilder = '<div class="custom-file" id="upload_button">';
               
                    if (options._containerdeletebuttontext != '') {

                        if (options._uploadedfileextension == '') {
                            if (options._ismultiple)
                                stringbuilder += '<input class="custom-file-input" type="file" accept=".doc, .docx, .pdf, .xls, .xlsx, .jpg, .png, .jpeg, .gif, .bmp, .tif, .tiff|image/*" ngf-select ng-model="new_files" id="' + options._fileinputname + '" ng-change="fs.uploadFiles(new_files)" multiple>';
                            else
                                stringbuilder += '<input class="custom-file-input" type="file" accept=".doc, .docx, .pdf, .xls, .xlsx, jpg, .png, .jpeg, .gif, .bmp, .tif, .tiff|image/*" ngf-select ng-model="new_files" id="' + options._fileinputname + '" ng-change="fs.uploadFiles(new_files)">';
                        }
                        else {
                            if (options._ismultiple)
                                stringbuilder += '<input class="custom-file-input" type="file" accept="' + options._uploadedfileextension + '" ngf-select ng-model="new_files" id="' + options._fileinputname + '" ng-change="fs.uploadFiles(new_files)" multiple>';
                            else
                                stringbuilder += '<input class="custom-file-input" type="file" accept="' + options._uploadedfileextension + '" ngf-select ng-model="new_files" id="' + options._fileinputname + '" ng-change="fs.uploadFiles(new_files)">';
                        }
                        stringbuilder += '<label class="custom-file-label" for="' + options._fileinputname + '">Choose file</label>';
                    }
                    stringbuilder += '</div>';

                    stringbuilder += '<div  id="' + options._tableid + '">';

                    stringbuilder += '<div class="row"  min-height:200px;" id="' + options._containeruploadpreview + '">';


                    stringbuilder += '</div>';
                    stringbuilder += '</div>';
                    stringbuilder += '';

                    this.append(stringbuilder);
                    return this;
                };
            }
            //var baseurl = $('#txtBaseUrl').val();

            $(document).ready(function () {

                $('#' + options._fileinputname).change(function () {
                    var fileUpload = $('#' + options._fileinputname).get(0);
                    var files = fileUpload.files;
                    var fileData = new FormData();
                    for (var i = 0; i < files.length; i++) {

                        fileData.append(files[i].name, files[i]);
                        var filesize = files[i].size;
                        var fileName = files[i].name;
                        var fileURL = [];
                        var str = "";
                        writeDiv(files[i], $('#' + options._containeruploadpreview), options._containerdeletebuttontext);

                        if (options._ismultiple) {
                        }
                        else {
                            $('#btn_' + options._fileinputname).addClass('hidden');
                            $('#btn_' + options._fileinputname).addClass('disabled');
                        }

                    }
                });


                function writeDiv(file, containeruploadpreview, containerdeletebuttontext) {
                    var str = "";
                    var reader = new FileReader();
                    reader.onload = function (event) {
                        var extension = file.name.split('.').pop().toLowerCase();
                        extension = '.' + extension;
                        var cont = event.target.result
                        var base64String = cont.replace(/^[^,]*,/, '');

                        var baseurl = window.location.origin;
                        var imgsource = '';

                        str = '<div class="col-lg-2 wrapperiv">';

                        str += '<div class="fileupload fileupload-design fu-clickable form-horizontal form-bordered fu-started">';
                        str += '<div class="fu-preview fu-image-preview">';

                        if (extension == '.pdf')
                            imgsource = baseurl + "/img/PDF_file_icon.png";
                        else if (extension == '.jpg' || extension == '.png' || extension == '.bmp' || extension == '.gif' || extension == '.jpeg')
                            imgsource = event.target.result;
                        else if (extension == '.doc' || extension == '.docx')
                            imgsource = baseurl + "/img/word-icon.png";
                        else if (extension == '.xlsx' || extension == '.xls')
                            imgsource = baseurl + "/img/excel-icon.png";

                        str += '<div class="fu-image">';

                        str += '<img style="height:120px; width: 120px;" data-fu-thumbnail="" src= "' + imgsource + '" />';
                        str += '</div>';
                        str += '<div class="fu-details">';

                        str += '<div class="fu-size">';
                        str += '<span data-fu -size="" class="filesize"><strong>' + formatBytes(file.size)+ '</strong></span>';
                        str += '</div>';
                        str += '<div class="fu-filename">';
                        str += '<span data-fu-name="" class="filename">' + file.name + '</span>';
                        str += '</div>';

                        str += '<div  style="padding-top: 15px;">';
                        str += '<a class=" fu-download" download="' + file.name + '" target="_blank" href="' + event.target.result + '"><i class="fas fa-download" style="font-size:18px;"></i></a>';
                        str += '<a  class="fu-remove" href="#" onclick="javascript:deletefile(this);"><i class="fas fa-trash-alt" style="font-size:18px;color: red"></i></a>';


                        str += '<input type="hidden" value="' + file.name + '" id="filename" class="filename"/>';
                        str += '<input type="hidden" value="' + file.type + '" id="filetype" class="filetype"/>';
                        str += '<input type="hidden" value="' + base64String + '" id="filepath" class="filepath"/>';
                        str += '<input type="hidden" value="' + extension + '" id="fileextension" class="fileextension"/>';
                        str += '<input type="hidden" value="Added" id="currentstate" class="currentstate"/>';
                        str += '<input type="hidden" value="-99" id="fileid" class="fileid"/>';


                        str += '</div>';
                        str += '</div>';
                        str += '</div>';

                        str += '</div>';
                        str += '</div>';

                        $(containeruploadpreview).append(str);
                    }
                    reader.readAsDataURL(file);
                }

                this.deletefile = function (val) {
                    try {
                        var fileid = $(val).siblings('input#fileid').val();
                        var filename = $(val).siblings('input#filename').val();
                        var currentstate = $(val).siblings('input#currentstate').val();

                        if (fileid > 0) {
                            $(val).siblings('input#currentstate').val('Deleted');
                            $(val).parent().parent().parent().parent().parent().hide();
                        }
                        else {
                            $(val).parent().parent().parent().parent().parent().remove();
                        }

                        return;

                    } catch (e) {
                        $.alert({
                            title: _getCookieForLanguage("_informationTitle"),
                            content: e.message,
                            type: 'red'
                        });
                    }
                };
            });

            this.loadpreloaddata = function (_fileobjectmaster, containeruploadpreview, ismultiple, fileinputname) {
                var str = "";
                var _fileobject = null;

                //var appSetting = '@(System.Configuration.ConfigurationManager.AppSettings["FtpServerSetting"].ToString())';
                console.log(_fileobjectmaster);
                $.each(_fileobjectmaster, function (key, valueObj) {
                 
                    var blob = null;
                    var xhr = new XMLHttpRequest();
                    //xhr.open("GET", ftpSettingAddress + valueObj.filepath + valueObj.filename + valueObj.extension, true);
                    xhr.open("GET", valueObj.filepath, true);
                    xhr.responseType = "blob";
                    xhr.onreadystatechange = function () {
                        if (xhr.readyState == 4) {
                            blob = xhr.response;
                            var myReader = new FileReader();
                            myReader.readAsArrayBuffer(blob);
                            myReader.addEventListener("loadend", function (e) {
                                var cont = e.srcElement.result;
                                var base64String = base64ArrayBuffer(cont);
                                var stringLength = base64String.length;
                                //var sizeInBytes = Math.ceil(stringLength / 4) * 3;
                                var xsize = (stringLength * (3 / 4)) - 1;
                                var filesize = formatBytes(xsize);
                                //var sizeInBytes = 4 * Math.ceil((stringLength / 3)) * 0.5624896334383812;
                                //var sizeInKb = sizeInBytes / 1000;

                                var baseurl = window.location.origin;
                                var imgsource = '';

                                str = '<div class="col-lg-2 wrapperiv">';
                                str += '<div class="fileupload fileupload-design fu-clickable form-horizontal form-bordered fu-started">';
                        str += '<div class="fu-preview fu-image-preview">';

                                if (valueObj.extension == '.pdf')
                                    imgsource = baseurl + "/img/PDF_file_icon.png";
                                else if (valueObj.extension == '.jpg' || valueObj.extension == '.png' || valueObj.extension == '.bmp' || valueObj.extension == '.gif' || valueObj.extension == '.jpeg')
                                    imgsource = 'data:' + valueObj.filetype + ';base64,' + base64String;
                                else if (valueObj.extension == '.doc' || valueObj.extension == '.docx')
                                    imgsource = baseurl + "/img/word-icon.png";
                                else if (valueObj.extension == '.xlsx' || valueObj.extension == '.xls')
                                    imgsource = baseurl + "/img/excel-icon.png";

                        str += '<div class="fu-image">';

                        str += '<img style="height:120px; width: 120px;" data-fu-thumbnail="" src= "' + imgsource + '" />';
                        str += '</div>';
                        str += '<div class="fu-details">';

                        str += '<div class="fu-size">';
                                str += '<span data-fu -size="" class="filesize"><strong>' + filesize + '</strong></span>';
                        str += '</div>';
                        str += '<div class="fu-filename">';
                                str += '<span data-fu-name="" class="filename">' + valueObj.actualfilename + '</span>';
                        str += '</div>';

                        str += '<div  style="padding-top: 15px;">';
                                str += '<a class=" fu-download" download="' + valueObj.actualfilename + '" target="_blank" href="data:' + valueObj.filetype + ';base64,' + base64String + '"><i class="fas fa-download" style="font-size:18px;"></i></a>';
                        str += '<a  class="fu-remove" href="#" onclick="javascript:deletefile(this);"><i class="fas fa-trash-alt" style="font-size:18px;color: red"></i></a>';


                                str += '<input type="hidden" value="' + valueObj.filename + '" id="filename" class="filename"/>';
                                str += '<input type="hidden" value="' + valueObj.filetype + '" id="filetype" class="filetype"/>';
                        str += '<input type="hidden" value="' + base64String + '" id="filepath" class="filepath"/>';
                                str += '<input type="hidden" value="' + valueObj.extension + '" id="fileextension" class="fileextension"/>';
                                str += '<input type="hidden" value="' + valueObj.currentstate + '" id="currentstate" class="currentstate"/>';
                                str += '<input type="hidden" value="' + valueObj.fileid +'" id="fileid" class="fileid"/>';


                        str += '</div>';
                        str += '</div>';
                        str += '</div>';

                        str += '</div>';
                        str += '</div>';

                                $(containeruploadpreview).append(str);

                                if (ismultiple === false) {
                                    if (base64String !== null && base64String !== "") {
                                        $('#btn_' + fileinputname).addClass('hidden');
                                    }
                                }
                            });
                        }
                    }
                    xhr.send();
                });
            }
            return this.initialize();
        };

    }) (jQuery);



