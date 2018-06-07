using System;
using Autofac;
using SharpMUD.Core.Interfaces;

namespace SharpMUD.AutofacModules
{
    public class ConnectionManagerModule : Module
    {
        public string ConfigType { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConnectionManager>().As<IConnectionManager>().SingleInstance();
            builder.RegisterType<Connection>().As<IConnection>();
            //builder.RegisterType<Connection>().InstancePerDependency();

            base.Load(builder);
        }
    }
}