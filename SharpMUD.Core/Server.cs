using log4net;

namespace SharpMUD.Core
{
    public class Server
    {
        private bool shutdown = false;
        private readonly IServerConfigManager _serverConfigManager;
        private readonly IConnectionManager _connectionManager;
        private readonly ISocketServer _socketServer;
        private readonly ICommandManager _commandManager;

        private static readonly ILog log = LogManager.GetLogger(typeof(Server));

        public Server(IServerConfigManager configManager, IConnectionManager connectionManager, ISocketServer socketServer, ICommandManager commandManager)
        {
            _serverConfigManager = configManager;
            _connectionManager = connectionManager;
            _socketServer = socketServer;
            _commandManager = commandManager;
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
