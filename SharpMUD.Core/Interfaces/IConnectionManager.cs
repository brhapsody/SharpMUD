using System.Collections.Generic;

namespace SharpMUD.Core
{
    public interface IConnectionManager
    {
        void ReadInboundBuffers();
        void PushOutboundBuffers();
        IConnection NewConnection();

    }
}