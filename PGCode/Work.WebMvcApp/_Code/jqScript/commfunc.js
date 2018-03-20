﻿(function ($) {
    $.UiMessage = function (jsonobj) {
        if (jsonobj.message != null) {
            if (jsonobj.message != '') {
                $('#messagepop')
                    .dialog({
                        title: jsonobj.title,
                        modal: true,
                        buttons: [
                            {
                                text: 'Close', click: function () { $(this).dialog("close"); }
                            }
                        ],
                        show: { effect: "fade", duration: 300 },
                        hide: { effect: "fade", duration: 300 }
                    })
                    .html(jsonobj.message.replace(/\r\n/g, '<br />'))
                    .dialog('open');
            }
        }
    };

    $.ajax_GetNewId = function () {
        var NewId = 0;
        $.post("GetNewId").done(function (data, textStatus, jqXHR) {
            NewId = jQuery.parseJSON(data);
        });
        return NewId;
    };

    $.parseMsJsonDate = function (value) {
        var dateRegExp = /^\/Date\((.*?)\)\/$/;
        var dateInfo = dateRegExp.exec(value);
        var dateObject = new Date(parseInt(dateInfo[1], 10));
        return dateObject.getFullYear() + '/' + (dateObject.getMonth() + 1) + '/' + dateObject.getDate();
    };

    $.CollectQuery = function () {
        var getelement = $("#gridform table input");
        var getQueryStr = '';

        $.each(getelement,
            function (index, value) {
                if (value.value != '') {
                    getQueryStr += value.id + '=' + encodeURIComponent(value.value) + '&';
                }
            }
        );
        return getQueryStr;
    };

    $.pageQuery = function (GridID) {
        return 'page=' + jQuery("#" + GridID).getGridParam('page');
    };

    $.FilesCount = function (elementId, ajax_url_CountFiles, Id, FileKind) {

        $("#wait").html('檔案計算中...請稍侯!');
        $("#wait").show();
        var count_ct = 0;
        $.post(ajax_url_CountFiles,{ 'id': Id, 'FileKind': FileKind })
        .done(function (data, textStatus, jqXHR) {
            var jsonobj = jQuery.parseJSON(data);
            count_ct = jsonobj.filesObject.length;
        })
        .always(function () {
            $("#wait").hide();
        });
        return count_ct;
    };

    $.FilesHave = function (elementId, ajax_url_CountFiles, Id, FileKind) {

        var count_ct = $.FilesCount(elementId, ajax_url_CountFiles, Id, FileKin);
        return count_ct > 0;
    };

    $.FilesListHandle = function (elementId, ajax_url_ListFiles, ajax_url_DeleteFiles, Id, FileKind) {

        $.post(ajax_url_ListFiles, { 'id': Id, 'FileKind': FileKind })
        .done(function (data, textStatus, jqXHR) {

            $("#" + elementId).html(''); //清空 filesLits
            var jsonobj = jQuery.parseJSON(data);
            //以下為FileList顯示介面
            for (var ij = 0; ij < jsonobj.filesObject.length; ij++) {

                if (jsonobj.filesObject[ij].IsImage) {
                    $("#" + elementId)
                    .append(
                        $('<div style="padding:3px;width:420px;height:120px">')
                        .append($('<div style="padding:3px;margin-right:5px;float:left;border:1px; border-style:solid">').html('<a class="fancybox" rel="group" href="' + jsonobj.filesObject[ij].OriginFilePath + '"><img src="' + jsonobj.filesObject[ij].RepresentFilePath + '"></a>'))
                        .append($('<div style="padding:5px">').html(jsonobj.filesObject[ij].FileName))
                        .append($('<div style="padding:5px">').html(Math.ceil((jsonobj.filesObject[ij].Size / 1024)) + ' KB'))
                        .append($('<div style="padding:5px">').html('<button type="button" class="DeleteFilesButton" listElementId="' + elementId + '" listaction="' + ajax_url_ListFiles + '" delaction="' + ajax_url_DeleteFiles + '" idx="' + Id + '" FileKind="' + FileKind + '" FileName="' + jsonobj.filesObject[ij].FileName + '">刪除</button>'))
                        .append($('<div style="padding:5px">').html(jsonobj.filesObject[ij].OriginFilePath))
                    );
                } else {
                    var setFileKind = 'DocFiles';
                    if (jsonobj.filesObject[ij].FilesKind != null) {
                        setFileKind = jsonobj.filesObject[ij].FilesKind;
                    }
                    $("#" + elementId)
                    .append(
                        $('<div style="padding:3px;width:420px;height:60px;">')
                        .append($('<div style="padding:3px;margin-right:5px;float:left;">').html('<button class="DownLoadFilesButton" type="button" area="' + gb_area + '" controller="' + gb_controller + '" Id="' + Id + '" FileKind="' + setFileKind + '" FileName="' + jsonobj.filesObject[ij].FileName + '" >下載</button>' + '<button type="button" class="DeleteFilesButton" listElementId="' + elementId + '" listaction="' + ajax_url_ListFiles + '" delaction="' + ajax_url_DeleteFiles + '" idx="' + Id + '" FileKind="' + setFileKind + '" filename="' + jsonobj.filesObject[ij].FileName + '">刪除</button>'))
                        .append($('<div style="padding:5px">').html(jsonobj.filesObject[ij].FileName))
                        .append($('<div style="padding:5px">').html(Math.ceil((jsonobj.filesObject[ij].Size / 1024)) + ' KB'))
                    );
                }
            }
            $(".DeleteFilesButton").button({ icons: { primary: 'ui-icon-closethick', secondary: '' } });
            $(".DownLoadFilesButton").button({ icons: { primary: 'ui-icon-arrowstop-1-s', secondary: '' } });
            $(".fancybox").fancybox();
        })
        .always(function () {
            
        });
    };

    $.FileDownLoad = function (Id, FilesKind, FileName) {
        //利用Hidden iframe 下載檔案
        var path = gb_approot + gb_area + '/' + gb_controller + '/DownLoadFile?Id=' + Id + '&FileName=' + encodeURIComponent(FileName) + '&FilesKind=' + FilesKind;
        $('#ifm_filedownload').attr('src', path);
    };

    $.AjaxFormOnFailure = function (ajaxContext) {
        var response = ajaxContext.get_response();
        var statusCode = response.get_statusCode();
        alert("AJAX Request Failure： " + statusCode);
    };

    $(document).on('click', '.DeleteFilesButton', function () {

        var idx = $(this).attr('idx');
        var filekind = $(this).attr('filekind');
        var filename = $(this).attr('filename');

        var url_ListFiles = $(this).attr('listaction');
        var url_DeleteFiles = $(this).attr('delaction');
        var listElementId = $(this).attr('listElementId');

        $.post(url_DeleteFiles,{ 'id': idx, 'FileKind': filekind, 'FileName': filename })
        .done(function (data, textStatus, jqXHR) {
            var jsonobj = jQuery.parseJSON(data);
            $.FilesListHandle(listElementId, url_ListFiles, url_DeleteFiles, idx, filekind);
        });
    });
    $(document).on('click', '.DownLoadFilesButton', function () {
        var gId = $(this).attr('Id');
        var gFileKind = $(this).attr('FileKind');
        var gFileName = $(this).attr('FileName');

        $.FileDownLoad(gId, gFileKind, gFileName);
    });

    $.fn.extend({
        center: function () {
            this.css("position", "absolute");
            this.css("top", ($(document).height() - this.height()) / 2 + $(document).scrollTop() + "px");
            this.css("left", ($(document).width() - this.width()) / 2 + $(document).scrollLeft() + "px");
            return this;
        },
        check: function () {
            return this.each(function () { this.checked = true; });
        },
        uncheck: function () {
            return this.each(function () { this.checked = false; });
        },
        addressajax: function (options) {
            //地址處理
            options = $.extend({
                zipElement: $('#zip'),
                countyElement: $('#county'),
                cityValue: '桃園縣',
                countyValue: '中壢市'
            }, options || {});

            var cityElement = $(this);

            if (options.cityValue != '')
                $(this).val(options.cityValue);

            $(this).change(function () {
                options.countyElement.empty();
                $.post(gb_approot + '_Code/Ashx/AjaxGetCounty.ashx?uid=' + uniqid(), { 'city': $(this).val() })
                .done(function (data, textStatus, jqXHR) {
                    var jsonobj = jQuery.parseJSON(data);

                    if (jsonobj.result) {
                        for (var property in jsonobj.data) {
                            var option_html;
                            if (options.countyValue == property) {
                                option_html = '<option value="' + property + '" selected>' + jsonobj.data[property] + '</option>';
                            } else {
                                option_html = '<option value="' + property + '">' + jsonobj.data[property] + '</option>';
                            }
                            options.countyElement.append(option_html);
                        }
                        options.countyElement.trigger('change');
                    }

                    if (jsonobj.message != '')
                        $.UiMessage(jsonobj);

                });
            }).trigger('change');

            options.countyElement.change(function () {
                $.post(gb_approot + '_Code/Ashx/AjaxGetZip.ashx?uid=' + uniqid(), { 'city': cityElement.val(), 'county': $(this).val() })
                .done(function (data, textStatus, jqXHR) {

                    var jsonobj = jQuery.parseJSON(data);
                    if (jsonobj.result)
                        options.zipElement.val(jsonobj.data);

                    if (jsonobj.message != '')
                        $.UiMessage(jsonobj);
                });
            }).trigger('change');
            return this;
        },
        selectajax: function (options) {

            options = $.extend({
                relation_element: $('#relation'),
                master_value: 0,
                relation_value: 0,
                data_url: ''
            }, options || {});

            var master_element = $(this);

            if (options.master_value > 0)
                $(this).val(options.master_value);

            $(this).change(function () {
                options.relation_element.empty();
                $.post( options.data_url + '?uid=' + uniqid(),{ 'master_value': $(this).val() })
                .done(function (data, textStatus, jqXHR) {
                    var jsonobj = jQuery.parseJSON(data);

                    if (jsonobj.result) {
                        for (var property in jsonobj.data) {
                            var option_html;
                            if (options.relation_value == property)
                                option_html = '<option value="' + property + '" selected>' + jsonobj.data[property] + '</option>';
                            else
                                option_html = '<option value="' + property + '">' + jsonobj.data[property] + '</option>';

                            options.relation_element.append(option_html);
                        }
                    }

                    if (jsonobj.message != '')
                        $.UiMessage(jsonobj);
                });
            }).trigger('change');

            return this;
        },
        addr_query_tw: function (options) {
            options = $.extend({
                element_zip: $('#zip')
            }, options || {});

            var targetElement = this;

            this.autocomplete({
                select: function (event, ui) {
                    if (ui.item.zip != null) {
                        options.element_zip.val(ui.item.zip);
                    }
                },
                delay: 500,
                source: function (request, response) {
                    $.get("ajax_AddrEdit_TW", { 'val': targetElement.val() }, null, "json")
                        .done(function (data, textStatus, jqXHR) {
                            response(data);
                        });
                }
            });
        },
        textbox_key_numeric: function () {
            this.keypress(function (e) {
                if ((e.shiftKey && e.keyCode == 45) || e.which != 8 &&
                    e.which != 0 && (e.which < 48 || e.which > 57)) {
                    return false;
                }
            });
        }
    });
})(jQuery);

jQuery.validator.addMethod("TWIDCheck", function (value, element, param) {
    var a = new Array('A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'X', 'Y', 'W', 'Z', 'I', 'O');
    var b = new Array(1, 9, 8, 7, 6, 5, 4, 3, 2, 1);
    var c = new Array(2);
    var d;
    var e;
    var f;
    var g = 0;
    var h = /^[a-z](1|2)\d{8}$/i;
    if (value.search(h) == -1) {
        return false;
    }
    else {
        d = value.charAt(0).toUpperCase();
        f = value.charAt(9);
    }
    for (var i = 0; i < 26; i++) {
        if (d == a[i])//a==a
        {
            e = i + 10; //10
            c[0] = Math.floor(e / 10); //1
            c[1] = e - (c[0] * 10); //10-(1*10)
            break;
        }
    }
    for (i = 0; i < b.length; i++) {
        if (i < 2) {
            g += c[i] * b[i];
        }
        else {
            g += parseInt(value.charAt(i - 1), 10) * b[i];
        }
    }
    if ((g % 10) == f) {
        return true;
    }
    if ((10 - (g % 10)) != f) {
        return false;
    }
    return true;
}, "請輸入有效的身份證字號!");

function uniqid() { var newDate = new Date(); return newDate.getTime(); }

