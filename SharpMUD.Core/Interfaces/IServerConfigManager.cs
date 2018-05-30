using System;

namespace SharpMUD.Interfaces
{
    public interface IServerConfigManager
    {
        T GetSettingByName<T>(string key) where T : IConvertible;
        void LoadSettings();
    }
}