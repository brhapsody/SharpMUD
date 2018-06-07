using System.Collections.Generic;
using log4net;
using SharpMUD.Core.Interfaces;
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
        private readonly Func<ConnectionManager, IConnection> _connectionFactory;
        private static readonly ILog log = LogManager.GetLogger(typeof(ConnectionManager));
        public List<IConnection> ConnectedList;

        public ConnectionManager(Func<ConnectionManager, IConnection> connectionFactory)
        {
            _connectionFactory = connectionFactory;
            ConnectedList = new List<IConnection>();
            log.Debug("<-- Instantiated.");
        }

        public IConnection NewConnection()
        {
            var connection = _connectionFactory(this);
            ConnectedList.Add(connection);
            return connection;
        }

        public void PushOutboundBuffers()
        {
            foreach (IConnection c in ConnectedList)
            {
                if (c.ConnectedState < (int) ConnectedStates.ConnectedPlaying)
                    continue;

                c.ProcessOutput();
            }
        }

        public void ReadInboundBuffers()
        {
            foreach (IConnection c in ConnectedList)
            {
                // not here yet!
                if (c.ConnectedState < (int) ConnectedStates.ConnectedPlaying)
                    continue;

                // read next command and parse it
                c.ProcessInput();
            }
        }
    }
}
