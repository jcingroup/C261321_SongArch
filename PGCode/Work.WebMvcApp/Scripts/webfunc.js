(function ($) {

    $.parseMsJsonDate = function (value) {
        var dateRegExp = /^\/Date\((.*?)\)\/$/;
        var dateInfo = dateRegExp.exec(value);
        var dateObject = new Date(parseInt(dateInfo[1]));
        return dateObject.getFullYear() + '/' + (dateObject.getMonth()+1) + '/' + dateObject.getDate();
    }

    $.fn.extend({

    })
})(jQuery);

function uniqid() { var newDate = new Date; return newDate.getTime(); }
