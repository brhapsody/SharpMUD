using System;
using System.Collections.Generic;
using System.IO;
using log4net;
using Newtonsoft.Json;
using SharpMUD.Interfaces;
using SharpMUD.Models;

namespace SharpMUD
{
    public class ServerConfigRepositoryJson : IServerConfigRepository
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ServerConfigRepositoryJson));
        private ServerConfigObject _configObject;

        public ServerConfigRepositoryJson()
        {
            log.Debug("<-- Instantiated");
        }

        public ServerConfigObject GetConfigObject()
        {
            ReadFile("server.json");
            return _configObject;
        }

        private void ReadFile(string filename)
        {
            try
            {
                using (StreamReader stream = new StreamReader(filename))
                {
                    string json = stream.ReadToEnd();
                    _configObject = JsonConvert.DeserializeObject<ServerConfigObject>(json);
                    stream.Close();
                }
            }
            catch (FileNotFoundException)
            {
                log.Error($"{filename} does not exist.  Creating.");
                SaveFile(filename, _configObject);
            }
            catch (IOException e)
            {
                log.Error($"Unable to load configuration file {filename}: {e}!");
            }
            log.Debug($"Loaded settings file {filename}");
        }

        private void SaveFile(string filename, ServerConfigObject configObject)
        {
            try
            {
                using (StreamWriter stream = new StreamWriter(filename))
                {
                    string json = JsonConvert.SerializeObject(configObject, Formatting.Indented);
                    stream.Write(json);
                    stream.Flush();
                }
            }
            catch (IOException e)
            {
                log.Error($"Unable to create new file {filename}: {e}!");
            }

            log.Info("Created new server settings file from defaults.");
        }
    }
}