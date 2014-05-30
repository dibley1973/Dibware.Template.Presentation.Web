using Dibware.Template.Core.Domain.Contracts.Services;
using Dibware.Template.Presentation.Web.Controllers.Base;
using Dibware.Template.Presentation.Web.Exceptions;
using Dibware.Template.Presentation.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        // POST: /administration/adjustmentCodeExclusions/edit/{id}
        [HttpPost]
        [HandleModelStateExceptionForJson]
        public JsonResult GetAllCurrentForUser(string username)
        {
            if(String.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(username);
            }

            var notifcations = 
                _notificationService.GetAllCurrentForUser(username);

            return Json(notifcations);
        }

        #endregion
    }
}