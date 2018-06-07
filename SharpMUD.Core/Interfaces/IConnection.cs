namespace SharpMUD.Core.Interfaces
{
    public interface IConnection
    {
        int ConnectedState { get; set; }

        void ProcessInput();
        void ProcessOutput();
        void ReadFromConnection(string argument);
        string WriteToConnection();
        void AppendOutput(string argument);
    }
}