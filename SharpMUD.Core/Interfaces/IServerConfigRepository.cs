using SharpMUD.Models;

namespace SharpMUD.Core
{
    public interface IServerConfigRepository
    {
        ServerConfigObject GetConfigObject();
    }
}