namespace SharpMUD.Core
{
    public interface IConnection
    {
        ConnectedStates ConnectedState { get; set; }

        void ProcessInput();
        void ProcessOutput();
        void ReadFromConnection(string argument);
        string WriteToConnection();
        void AppendOutput(string argument);
    }
}