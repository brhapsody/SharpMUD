using System;

namespace SharpMUD.Core
{
    public interface IServerConfigManager
    {
        T GetSettingByName<T>(string key) where T : IConvertible;
        void LoadSettings();
    }
}