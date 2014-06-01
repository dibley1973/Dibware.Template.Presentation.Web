// Create objects
dibware = typeof (dibware) == 'undefined' ? {} : dibware;

// View model
dibware.notifications = {

    // handles when a notifcation is dismissed
    notificationOnDismiss: function (notificationId) {
        var that = this;

        // Debugging only
        alert(notificationId);




        // Callback to run once ajax has completed
        var onAjaxSuccess = function (response) {
            // Do nothing
        }

        // Callback to run on any ajax error and unblock the screen
        var onAjaxError = function (xhr, status, err, options) {


            $.ajaxError(xhr, status, err, options);
        }

        // Ajax server
        $.appAjax(that.getNotificationDismissUrl, {
            type: 'POST',
            data: { id: notificationId },
            callback: onAjaxSuccess,
            errorHandler: onAjaxError
        });

    }
};