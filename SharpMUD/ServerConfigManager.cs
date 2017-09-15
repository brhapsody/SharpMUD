using System;
using SharpMUD.Interfaces;
using SharpMUD.Models;
using System.Reflection;
using log4net;

namespace SharpMUD
{
    public class ServerConfigManager : IServerConfigManager
    {
        private readonly IServerConfigRepository _configRepository;
        private static readonly ILog log = LogManager.GetLogger(typeof(ServerConfigManager));
        private ServerConfigObject _settingDb;

        public ServerConfigManager(IServerConfigRepository repository)
        {
            _configRepository = repository;
            log.Debug("<-- Instantiated");
        }

        public T GetSettingByName<T>(string key) where T : IConvertible
        {
            PropertyInfo setting = _settingDb.GetType().GetProperty(key);
            if (setting != null)
            {
                var result = setting.GetValue(_settingDb, null);
                return (T) Convert.ChangeType(result, setting.PropertyType);
            }
            return default(T);
        }

        public void LoadSettings()
        {
            _settingDb = _configRepository.GetConfigObject();
        }
    }
}
