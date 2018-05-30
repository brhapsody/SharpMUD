using SharpMUD.Interfaces;
using System;
using System.Text;

namespace SharpMUD
{
    public static class CommandParser
    {
        public static void Parse(string command, IConnection c)
        {
            string result = $"I parsed: {command}";
            c.AppendOutput(result);;
        }
    }
}