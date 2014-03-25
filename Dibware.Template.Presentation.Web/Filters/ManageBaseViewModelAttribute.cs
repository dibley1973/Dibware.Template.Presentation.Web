using Dibware.Template.Presentation.Web.Controllers.Base;
using Dibware.Template.Presentation.Web.Models.Base;
using Dibware.Template.Presentation.Web.Resources;
using System;
using System.Web.Mvc;

namespace Dibware.Template.Presentation.Web.Filters
{
    public sealed class ManageBaseViewModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // Check we're dealing with a view result
            if (filterContext.Result.GetType() == typeof(ViewResult))
            {
                BaseViewModel baseModel;
                var viewModel = filterContext.Controller.ViewData.Model;

                // Check to see if the action created a view model or not
                if (viewModel == null)
                {
                    // Action did not create view model...

                    // Create new base model and set as the view model
                    baseModel = new BaseViewModel();
                    filterContext.Controller.ViewData.Model = baseModel;
                }
                else
                {
                    // Action did create a view model...

                    // Check view model has inherited from the base model, which it MUST!
                    if (!(viewModel is BaseViewModel))
                    {
                        // Oh dear.. it hasn't. Throw toys out of pram.
                        throw new ApplicationException(String.Format(ExceptionMessages.ModelDoesNotInheritFromBaseViewModelFormat, viewModel.GetType()));
                    }

                    // View model does inherit from base (hooray). Cast it as the base view model
                    baseModel = viewModel as BaseViewModel;
                }

                // Check the controller has inherited from base
                if (!(filterContext.Controller is BaseController))
                {
                    // Oh no.. user hasnt inherited from base controller. Ohhhh noooo
                    throw new ApplicationException(String.Format(ExceptionMessages.ControllerDoesNotInheritFromBaseControllerFormat, filterContext.Controller.GetType()));
                }

                // Fill that base view model with some data
                ((BaseController)filterContext.Controller).FillBaseViewModel(baseModel);
            }

            base.OnActionExecuted(filterContext);
        }
    }
}