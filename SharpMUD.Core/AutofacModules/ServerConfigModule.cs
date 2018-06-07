using Autofac;
using SharpMUD.Core.Interfaces;

namespace SharpMUD.AutofacModules
{
    public class ServerConfigModule : Module
    {
        public string ConfigType { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ServerConfigManager>().As<IServerConfigManager>().SingleInstance();

            switch(ConfigType)
            {
                default:
                    builder.RegisterType<ServerConfigRepositoryJson>().As<IServerConfigRepository>().SingleInstance();
                    break;
            }
            base.Load(builder);
        }
    }
}
