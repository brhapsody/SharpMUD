using Autofac;
using SharpMUD.Interfaces;

namespace SharpMUD.AutofacModules
{
    public class ConnectionManagerModule : Module
    {
        public string ConfigType { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConnectionManager>().As<IConnectionManager>().SingleInstance();
            builder.RegisterType<Connection>().As<IConnection>();

        }
    }
}