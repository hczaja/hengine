using System.Net.Sockets;
using System.Text;

namespace rts_game;

internal class SocketWrapper
{
    private readonly Socket _socket;

    public SocketWrapper(Socket socket)
    {
        _socket = socket;
    }

    public async Task SendData(byte[] data) => await _socket.SendAsync(data, SocketFlags.None);

    public async Task<string> ReceiveData(byte[] buffer)
    {
        int count = await _socket.ReceiveAsync(buffer, SocketFlags.None);
        return Encoding.UTF8.GetString(buffer, 0, count);
    }
}
