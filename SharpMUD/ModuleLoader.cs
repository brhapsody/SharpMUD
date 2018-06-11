using Autofac;
using SharpMUD.Core;

namespace SharpMUD.AutofacModules
{
    public class ModuleLoader
    {   
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            //composition root
            builder.RegisterType<Server>().SingleInstance();

            // ServerConfigManager, ServerConfigRepository
            builder.RegisterModule<ServerConfigModule>();

            builder.RegisterModule<ManagersModule>();

            builder.RegisterModule<ConsoleSocketModule>();

            return builder.Build();
        }
    }
}