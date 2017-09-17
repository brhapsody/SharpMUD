using System.IO;
using System.Reflection;
using Autofac;
using SharpMUD.AutofacModules;
using SharpMUD.Interfaces;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Repository;

namespace SharpMUD
{
    class Server
    {
        private bool shutdown = false;
        private readonly IServerConfigManager _serverConfigManager;
        private readonly IConnectionManager _connectionManager;
        private readonly ISocketServer _socketServer;

        private static readonly ILog log = LogManager.GetLogger(typeof(Server));

        // main configures the Autofac container and creates it, then sends flow to the actual server
        static void Main()
        {
            // start up logging
            XmlConfigurator.Configure(LogManager.GetRepository(Assembly.GetEntryAssembly()), new FileInfo("logconfig.xml"));
            
            log.Info("SharpMUD is starting up...");

            var container = ModuleLoader.BuildContainer();

            Server server = container.Resolve<Server>();
            server.Startup();
        }

        public Server(IServerConfigManager configManager, IConnectionManager connectionManager, ISocketServer socketServer)
        {
            _serverConfigManager = configManager;
            _connectionManager = connectionManager;
            _socketServer = socketServer;
            log.Debug("<-- Instantiated");
        }

        void Startup()
        {
            _serverConfigManager.LoadSettings();
            
            //
            // load all shit from DB as needed



            _socketServer.Init();
            // now for the main loop
            while (!shutdown)
            {
                _connectionManager.ReadInboundBuffers();
                // aggression
                // world update
                _connectionManager.PushOutboundBuffers();
                // sync
            }
            Shutdown();
        }

        void Shutdown()
        {
            
        }

    }
}
