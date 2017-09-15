using System.Collections.Generic;

namespace SharpMUD.Interfaces
{
    public interface IConnectionManager
    {
        void ReadInboundBuffers();
        void PushOutboundBuffers();
    }
}