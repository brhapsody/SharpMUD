using System;
using System.Text;
using SharpMUD.Core.Interfaces;

namespace SharpMUD
{
    public class CommandManager : ICommandManager
    {
        public static void Parse(string command, IConnection c)
        {
            string result = $"I parsed: {command}";
            c.AppendOutput(result);
        }
    }
}