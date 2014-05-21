using System;
using System.Collections.Generic;
using System.Configuration;

namespace Dibware.Template.Presentation.Web.Modules.ApplicationState
{
    public class ApplicationStatusSection : ConfigurationSection
    {
        // Create a "ApplicationStatusProvider" attribute.
        [ConfigurationProperty("DefaultProvider", IsRequired = false)]
        public String DefaultProvider
        {
            get
            {
                return (String)this["DefaultProvider"];
            }
            set
            {
                this["DefaultProvider"] = value;
            }
        }

        [ConfigurationProperty("Providers", IsRequired = false)]
        public List<ApplicationStatusProvider> Providers
        {
            get
            {
                return (List<ApplicationStatusProvider>)this["Providers"];
            }
            set
            {
                this["Providers"] = value;
            }
        }

    }
}