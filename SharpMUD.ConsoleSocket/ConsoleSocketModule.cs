using Autofac;
using SharpMUD.Interfaces;

namespace SharpMUD.AutofacModules
{
    public class ConsoleSocketModule : Module
    {
        public string ConfigType { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConsoleSocket>().As<ISocketServer>();

            base.Load(builder);
        }
    }
}