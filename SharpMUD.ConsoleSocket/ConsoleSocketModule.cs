using Autofac;
using SharpMUD.Core.Interfaces;

namespace SharpMUD.AutofacModules
{
    public class ConsoleSocketModule : Module
    {
       
        // TODO:  config autofac to scan for modules instead of manually declaring
    
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConsoleSocket>().As<ISocketServer>();

            base.Load(builder);
        }
    }
}