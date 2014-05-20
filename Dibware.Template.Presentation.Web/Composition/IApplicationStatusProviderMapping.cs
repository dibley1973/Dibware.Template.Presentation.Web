using Dibware.Template.Presentation.Web.Modules.ApplicationState;
using Ninject.Modules;
using System;

namespace Dibware.Template.Presentation.Web.Composition
{
    public class IApplicationStatusProviderMapping : NinjectModule
    {
        public override void Load()
        {
            Bind<IApplicationStatusProvider>()
                .To<MvcApplicationStatusProvider>();
        }
    }
}