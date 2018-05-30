using System.Collections.Generic;
using log4net;


namespace SharpMUD.Models
{

    // this is the object model for the ServerConfigManager's config data
    public class ServerConfigObject
    {
        public int Port { get; set; }
        public string Logfile { get; set; }
        public List<string> Invalidnames { get; set; }

        private static readonly ILog log = LogManager.GetLogger(typeof(ServerConfigObject));

        // critical default values for the object.
        // normally I like to programmatically control all defaults, but if
        // the critical server configuration is missing, we want to create it

        public ServerConfigObject()
        {
            Port = 4000;
            Logfile = "server.log";
            Invalidnames = new List<string>();

            log.Debug("<-- Instantiated");
        }
    }
}
