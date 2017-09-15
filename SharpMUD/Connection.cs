using SharpMUD.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;

namespace SharpMUD
{
    public class Connection : IConnection
    {
        private string _inString;
        private Queue<string> _inStringBuffer;
        private string _outBuffer;
        public int ConnectedState;

        public string OutToSocket { get; set; }

        public Connection()
        {
            _inStringBuffer = new Queue<string>();
        }

        public void ProcessInput(Connection c)
        {
            // a command is in the inbound, let's process it
            if (!String.IsNullOrEmpty(c._inString))
                CommandParser.Parse(c._inString, c);

            // queue up the next command for the next cycle
            _inString = _inStringBuffer.Dequeue();
        }

        public void ProcessOutput(Connection c)
        {
            // I have stuff to send, so put it in the wicket for the socket to pick it up
            if (!String.IsNullOrEmpty(c._outBuffer))
            {
                c.OutToSocket += String.Copy(c._outBuffer);
                c._outBuffer = "";
            }
        }

    }

}
