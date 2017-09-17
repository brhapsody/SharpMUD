using SharpMUD.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using log4net;

namespace SharpMUD
{
    public class Connection : IConnection
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Connection));
        private readonly IConnectionManager _connectionManager;

        private string _inString;
        private Queue<string> _inStringBuffer;
        public string _outBuffer;
        private string _outToSocket;

        public int ConnectedState { get; set; }

        public Connection(IConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
            _inStringBuffer = new Queue<string>();
            log.Debug("<-- Instantiated.");
        }

        public void ProcessInput(Connection c)
        {
            // a command is in the inbound, let's process it
            if (!String.IsNullOrEmpty(c._inString))
                CommandParser.Parse(c._inString, c);

            // queue up the next command for the next cycle
            if (_inStringBuffer.Count != 0)
                _inString = _inStringBuffer.Dequeue();
            else
                _inString = "";

        }

        public void ProcessOutput(Connection c)
        {
            // I have stuff to send, so put it in the wicket for the socket to pick it up
            if (!String.IsNullOrEmpty(c._outBuffer))
            {
                c._outToSocket += c._outBuffer;
                c._outBuffer = "";
            }
        }

        public void ReadFromConnection(string argument)
        {
            if (!String.IsNullOrEmpty(argument))
              _inStringBuffer.Enqueue(argument);

        }

        public string WriteToConnection()
        {
            if (!String.IsNullOrEmpty(_outToSocket))
            {
                string result = _outToSocket;
                _outToSocket = "";
                return result;
            }

            return null;
        }

    }

}
