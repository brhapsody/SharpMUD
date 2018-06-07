using System;

namespace SharpMUD.Core.Interfaces
{
    public interface IServerConfigManager
    {
        T GetSettingByName<T>(string key) where T : IConvertible;
        void LoadSettings();
    }
}