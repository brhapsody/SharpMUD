using System.IO;
using System.Reflection;
using Autofac;
using log4net;
using log4net.Config;
using SharpMUD.AutofacModules;

namespace SharpMUD
{
    class SharpMUD
    {
        // main configures the Autofac container and creates it, then sends flow to the actual server
        static void Main()
        {
            // start up logging
            XmlConfigurator.Configure(LogManager.GetRepository(Assembly.GetEntryAssembly()), new FileInfo("logconfig.xml"));

            var container = ModuleLoader.BuildContainer();

            Server server = container.Resolve<Server>();
            server.Startup();
        }
    }
}
