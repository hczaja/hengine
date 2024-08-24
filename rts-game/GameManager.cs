using System.Net.Sockets;

namespace rts_game;

public class GameManager
{
    private readonly SocketWrapper _client;

    public GameManager(Socket socket)
    {
        _client = new SocketWrapper(socket);
    }
}
