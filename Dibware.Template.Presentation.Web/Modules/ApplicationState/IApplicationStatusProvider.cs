using Dibware.Template.Core.Domain.Entities.Application;
using System;

namespace Dibware.Template.Presentation.Web.Modules.ApplicationState
{
    /// <summary>
    /// Defines the expected members for an Application Status Provider
    /// </summary>
    internal interface IApplicationStatusProvider
    {
        /// <summary>
        /// Gets the current state of the application
        /// </summary>
        /// <returns></returns>
        Status GetCurrentState();
    }
}