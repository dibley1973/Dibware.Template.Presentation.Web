$(window).ready(function () {
    /* ajaxError:
    * Handles an ajax error by looking for status code 400
    * which indicates a model state error thrown by the mvc server
    * side code
    **************************************************************/
    $.extend({
        ajaxError: function (xhr, status, err, options) {
            var defaults = {
                parentSelector: null
            };
            var options = $.extend({}, defaults, options);

            if (xhr.status == 400) {
                // Parse response to json    
                var json = $.parseJSON(xhr.responseText);

                // Test for a key which will inidicate an element on the page to highlight
                if (json.Key != null) {
                    // Get elem and determine if it exists
                    if (options.parentSelector != null) {
                        var $elem = $(options.parentSelector).find('#' + json.Key.replace('[', '_').replace(']', '_').replace(/\./g, '_'));
                    } else {
                        var $elem = $('#' + json.Key.replace('[', '_').replace(']', '_').replace(/\./g, '_'));
                    }
                    if ($elem.length > 0) {
                        $elem.addClass('hasError').change(function () { $(this).removeClass('hasError'); });
                    }
                }

                // Show error message in the usual fashion
                $.handleError(json.Value);
            } else {
                $.handleError(xhr.responseText);
            }
        }
    });

    /* appAjax:
    * Extends jquery with an extended jquery ajax method.
    * The main benefit is so we can test for the xhr response code
    * and handle our bespoke server side ajax exceptions that raise
    * these codes
    **************************************************************/
    $.extend({
        appAjax: function (url, options) {
            var defaults = {
                async: true,
                errorHandler: $.ajaxError,
                contentType: 'application/x-www-form-urlencoded',
                callback: null,
                type: 'POST',
                data: null
            };
            var options = $.extend({}, defaults, options);

            // Remove all highlighted error fields
            $('.hasError').removeClass('hasError');

            $.ajax({
                url: url,
                cache: false,
                type: options.type,
                data: options.data,
                traditional: true,
                contentType: options.contentType,
                async: options.async,
                error: options.errorHandler,
                success: function (data, status, xhr) {
                    if (options.callback != null) {
                        window.setTimeout(function () {
                            options.callback(data);
                        }, 10);
                    }
                }
            });
        }
    });
});