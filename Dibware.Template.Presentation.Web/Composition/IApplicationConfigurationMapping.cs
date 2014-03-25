using Dibware.Template.Presentation.Web.Modules.Configuration;
using Ninject.Modules;

namespace Dibware.Template.Presentation.Web.Composition
{
    public class IApplicationConfigurationMapping : NinjectModule
    {
        public override void Load()
        {
            Bind<IApplicationConfiguration>()
                .To<ApplicationConfiguration>();
        }
    }
}