namespace SharpMUD.Interfaces
{
    public interface IConnection
    {
        int ConnectedState { get; set; }

        void ProcessInput(Connection c);
        void ProcessOutput(Connection c);
        void ReadFromConnection(string argument);
        string WriteToConnection();

    }
}