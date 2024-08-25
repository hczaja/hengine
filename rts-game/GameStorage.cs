using System.Net.Sockets;

namespace rts_game;

public class GameStorage
{
    private readonly SocketWrapper _socket;
    private readonly GameState _gameState;

    public GameStorage(Socket socket)
    {
        _gameState = new GameState();
        _socket = new SocketWrapper(socket);
    }

    public IEnumerable<IGameObject> GetGameObjects() => _gameState.Units;
}
