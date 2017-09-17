using System.Collections.Generic;
using log4net;
using SharpMUD.Interfaces;
using System;

namespace SharpMUD
{
    public enum ConnectedStates
    {
        ConnectedNegotiating,
        ConnectedPlaying
    }

    public class ConnectionManager : IConnectionManager
    {
        private readonly Func<ConnectionManager, Connection> _connectionFactory;
        private static readonly ILog log = LogManager.GetLogger(typeof(ConnectionManager));
        public List<Connection> ConnectedList;

        public ConnectionManager(Func<ConnectionManager, Connection> connectionFactory)
        {
            _connectionFactory = connectionFactory;
            ConnectedList = new List<Connection>();
            log.Debug("<-- Instantiated.");
        }

        public Connection NewConnection()
        {
            var connection = _connectionFactory(this);
            ConnectedList.Add(connection);
            return connection;
        }

        public void PushOutboundBuffers()
        {
            foreach (Connection c in ConnectedList)
            {
                if (c.ConnectedState < (int) ConnectedStates.ConnectedPlaying)
                    continue;

                c.ProcessOutput(c);
            }
        }

        public void ReadInboundBuffers()
        {
            foreach (Connection c in ConnectedList)
            {
                // not here yet!
                if (c.ConnectedState < (int) ConnectedStates.ConnectedPlaying)
                    continue;

                // read next command and parse it
                c.ProcessInput(c);
            }
        }
    }
}
