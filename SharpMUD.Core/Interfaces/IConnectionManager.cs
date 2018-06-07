using System.Collections.Generic;

namespace SharpMUD.Core.Interfaces
{
    public interface IConnectionManager
    {
        void ReadInboundBuffers();
        void PushOutboundBuffers();
        IConnection NewConnection();

    }
}