using SharpMUD.Models;

namespace SharpMUD.Core.Interfaces
{
    public interface IServerConfigRepository
    {
        ServerConfigObject GetConfigObject();
    }
}