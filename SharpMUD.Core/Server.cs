using System;
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
    public class Server
    {
        private bool shutdown = false;
        private readonly IServerConfigManager _serverConfigManager;
        private readonly IConnectionManager _connectionManager;
        private readonly ISocketServer _socketServer;

        private static readonly ILog log = LogManager.GetLogger(typeof(Server));

        public Server(IServerConfigManager configManager, IConnectionManager connectionManager, ISocketServer socketServer)
        {
            _serverConfigManager = configManager;
            _connectionManager = connectionManager;
            _socketServer = socketServer;
            log.Debug("<-- Instantiated");
        }

        public void Startup()
        {
            log.Info("SharpMUD is starting up...");
            _serverConfigManager.LoadSettings();
            
            //
            // load all from DB as needed



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
