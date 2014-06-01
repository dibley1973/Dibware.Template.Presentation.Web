/*jslint browser: true, devel:true */
/*global $, jQuery, dibware:true */

$(window).ready(function () {
    "use strict";

    /* handleError:
    * Extends jquery with a method to handle client side errors
    **************************************************************/
    $.extend({
        handleError: function (message) {
            if (message === 'undefined' || message === null) {
                message = 'Sorry, something has gone a little wrong... if the problem persists please contact the help desk.';
            }

            alert(message);
        }
    });
});