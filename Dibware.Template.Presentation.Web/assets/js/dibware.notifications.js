/*jslint browser: true, devel:true */
/*global $, jQuery, dibware:true */

// Create objects
dibware = (dibware === undefined) ? {} : dibware;

// View model
dibware.notifications = {

    // Stores the url that is used to get a period on change of the select period drop down list
    notificationDismissUrl: null,

    // Initialises the function
    init: function (notificationDismissUrl) {
        "use strict";
        this.notificationDismissUrl = notificationDismissUrl;
    },

    // handles when a notifcation is dismissed
    notificationOnDismiss: function (notificationId) {
        "use strict";
        var that = this,
            onAjaxSuccess,
            onAjaxError;

        // Callback to run once ajax has completed
        onAjaxSuccess = function () {
            // Success
            window.status = 'Notifcation dismissed';
        };

        // Callback to run on any ajax error and unblock the screen
        onAjaxError = function (xhr, status, err, options) {
            $.ajaxError(xhr, status, err, options);
        };

        // Use Ajax to call to the server
        $.appAjax(that.notificationDismissUrl, {
            type: 'POST',
            data: { notificationId: notificationId },
            callback: onAjaxSuccess,
            errorHandler: onAjaxError
        });
    }
};