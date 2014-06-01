using Dibware.Template.Core.Domain.Contracts.Services;
using Dibware.Template.Presentation.Web.Controllers.Base;
using Dibware.Template.Presentation.Web.Filters;
using System;
using System.Web.Mvc;

namespace Dibware.Template.Presentation.Web.Controllers
{
    public class NotificationsController : BaseController
    {
        #region Private Members

        private INotificationService _notificationService;

        #endregion

        #region Constructors

        public NotificationsController(INotificationService notificationService)
        {
            this._notificationService = notificationService;
        }


        #endregion

        #region Actions

        //
        // POST: /notifications/getallcurrentforuser/{username}
        [HttpPost]
        [HandleModelStateExceptionForJson]
        public JsonResult GetAllCurrentForUser(string username)
        {
            if (String.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(username);
            }

            var notifcations =
                _notificationService.GetAllCurrentForUser(username);

            return Json(notifcations);
        }

        //
        // POST: /notifications/dismissnotification/{notificationId}
        public JsonResult DismissNotification(Int32 notificationId)
        {
            String username = User.Name;
            Boolean dismissed = false;
            dismissed = _notificationService.DismissForUser(notificationId, username);
            return Json(dismissed);
        }

        #endregion
    }
}