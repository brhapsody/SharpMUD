using System.Collections.Generic;
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
        public List<Connection> ConnectedList;

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
