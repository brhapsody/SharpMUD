namespace SharpMUD.Interfaces
{
    public interface IConnection
    {
        void ProcessInput(Connection c);
        void ProcessOutput(Connection c);
    }
}