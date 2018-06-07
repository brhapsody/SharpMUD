using SharpMUD.Core.Interfaces;
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

        public void AppendOutput(string argument)
        {
            _outBuffer += argument;
        }

        public void ProcessInput()
        {
            // a command is in the inbound, let's process it
            if (!String.IsNullOrEmpty(_inString))
                CommandParser.Parse(_inString, this);

            // queue up the next command for the next cycle
            if (_inStringBuffer.Count != 0)
                _inString = _inStringBuffer.Dequeue();
            else
                _inString = "";
        }

        public void ProcessOutput()
        {
            // I have stuff to send, so put it in the wicket for the socket to pick it up
            if (!String.IsNullOrEmpty(_outBuffer))
            {
                _outToSocket += _outBuffer;
                _outBuffer = "";
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
