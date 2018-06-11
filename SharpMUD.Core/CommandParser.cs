using System;
using System.Text;

namespace SharpMUD.Core
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