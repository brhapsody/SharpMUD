using System;
using Autofac;
using SharpMUD.Core;

namespace SharpMUD.AutofacModules
{
    public class ManagersModule : Module
    {
        public string ConfigType { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConnectionManager>().As<IConnectionManager>().SingleInstance();
            builder.RegisterType<CommandManager>().As<ICommandManager>().SingleInstance();
            builder.RegisterType<ServerConfigManager>().As<IServerConfigManager>().SingleInstance();


            builder.RegisterType<Connection>().As<IConnection>();
            //builder.RegisterType<Connection>().InstancePerDependency();

            base.Load(builder);
        }
    }
}