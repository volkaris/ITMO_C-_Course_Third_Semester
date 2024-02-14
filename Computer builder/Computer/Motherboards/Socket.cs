namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Motherboards;

public class Socket
{
    public Socket(string socketName)
    {
        SocketName = socketName;
    }

    private string SocketName { get; }

    public bool CompatibleWith(Socket other)
    {
        return SocketName == other.SocketName;
    }
}