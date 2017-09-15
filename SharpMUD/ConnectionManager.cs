using System.Collections.Generic;
using log4net;
using SharpMUD.Interfaces;

namespace SharpMUD
{
    enum ConnectedStates
    {
        ConnectedNegotiating,
        ConnectedPlaying
    }

    public class ConnectionManager : IConnectionManager
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ConnectionManager));
        public List<Connection> ConnectedList;

        public ConnectionManager()
        {
            ConnectedList = new List<Connection>();
            log.Debug("<-- Instantiated.");
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
