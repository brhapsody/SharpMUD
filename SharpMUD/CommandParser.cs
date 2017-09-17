using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SharpMUD
{
    public static class CommandParser
    {
        public static void Parse(string command, Connection c)
        {
            string result = $"I parsed: {command}";
            c._outBuffer += result;
        }
    }
}