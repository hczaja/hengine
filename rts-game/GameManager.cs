using System.Net.Sockets;

namespace rts_game;

public class GameManager
{
    private readonly SocketWrapper _socket;
    private readonly GameState _gameState;

    public GameManager(Socket socket)
    {
        _gameState = new GameState();
        _socket = new SocketWrapper(socket);
    }

    public IEnumerable<Unit> GetGameObjects() => _gameState.Units;
}
