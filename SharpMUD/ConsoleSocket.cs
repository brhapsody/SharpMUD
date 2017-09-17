using System.Runtime.CompilerServices;
using SharpMUD.Interfaces;
using System.Threading;
using System;
using log4net;

namespace SharpMUD
{
    public class ConsoleSocket : ISocketServer
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ConsoleSocket));
        private readonly IConnectionManager _connectionManager;
        private readonly IConnection _connection;
        private static bool close = false;
        private static Thread listenerThread;
        private static Thread writerThread;

        public ConsoleSocket(IConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
            _connection = _connectionManager.NewConnection();
            log.Debug("<-- Instantiated.");
        }

        public void Init()
        {
            ThreadStart listener = Listen;
            listenerThread = new Thread(listener);
            listenerThread.Start();
            log.Debug("Initialized console listener.");

            ThreadStart writer = Write;
            writerThread = new Thread(writer);
            writerThread.Start();
            log.Debug("Initialized console writer.");
            _connection.ConnectedState = (int) ConnectedStates.ConnectedPlaying;
        }

        private void Write()
        {
            while (!close)
            {
                string output = _connection.WriteToConnection();
                if (!String.IsNullOrEmpty(output))
                    Console.WriteLine(output);

            }
            log.Debug("Terminating console listener.");
            listenerThread.Abort();
        }
        private void Listen()
        {
            while (!close)
            {
                _connection.ReadFromConnection(Console.ReadLine());
            }
            log.Debug("Terminating console writer.");
            writerThread.Abort();
        }

        public void Close()
        {
            close = true;
            
        }
    }
}