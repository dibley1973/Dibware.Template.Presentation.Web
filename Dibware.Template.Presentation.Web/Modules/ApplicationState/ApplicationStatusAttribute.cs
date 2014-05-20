﻿using Dibware.Template.Core.Domain.Entities.Application;
using Dibware.Template.Presentation.Web.Controllers.Base;
using Dibware.Template.Presentation.Web.Models.Home;
using Dibware.Template.Presentation.Web.Resources;
using System;
using System.Web.Mvc;

namespace Dibware.Template.Presentation.Web.Modules.ApplicationState
{
    /// <summary>
    /// Checks the application status and redirects to the Application Status
    /// </summary>
    public sealed class ApplicationStatusAttribute : ActionFilterAttribute
    {
        #region Declarations

        private const Int32 ApplicationActiveState = 1;

        #endregion

        #region Methods

        /// <summary>
        /// Called when the action is executing.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // TODO: Uncomment and finish implementing!

            //// Load the current status
            //Status applictionStatus = GetIsActiveStatus(filterContext);

            //// check if the state is active...
            //Boolean isActive = (applictionStatus.State == ApplicationActiveState);
            //if (!isActive)
            //{
            //    // ... it is not so redirect to the message view
            //    filterContext.Result = new ViewResult
            //    {
            //        ViewName = ViewNames.Status,
            //        ViewData = filterContext.Controller.ViewData,
            //        TempData = filterContext.Controller.TempData
            //    };
            //    filterContext.Controller.ViewData.Model = new StatusViewModel
            //    {
            //        Message = applictionStatus.Message
            //    };
            //}

            // Pass on through to the base class
            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// Gets the is active status.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        private Status GetIsActiveStatus(ActionExecutingContext filterContext)
        {
            if(filterContext.Controller is BaseControllerWithDataLookup)
            {
                var dataLookUpcontroller = filterContext.Controller as BaseControllerWithDataLookup;
                var status = dataLookUpcontroller.LookupService.FindById<Status>(1);
                // TODO: Remove hard-coded 1 and replace with value from web.config or constant
                return status;
            }
            throw new NotImplementedException();
        }

        #endregion
    }
}