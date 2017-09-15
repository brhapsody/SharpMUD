using SharpMUD.Models;

namespace SharpMUD.Interfaces
{
    public interface IServerConfigRepository
    {
        ServerConfigObject GetConfigObject();
    }
}