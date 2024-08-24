using System.Net;
using System.Net.Sockets;
using System.Text;

namespace rts_game.server;

public class GameServer : IDisposable
{
    private readonly Socket _listener;

    public GameServer(IPEndPoint endpoint)
    {
        _listener = new Socket(
            endpoint.AddressFamily,
            SocketType.Stream,
            ProtocolType.Tcp);

        _listener.Bind(endpoint);
        _listener.Listen(10);
    }

    public async Task Run()
    {
        Console.WriteLine("Waiting for a connection...");
        var handler = await _listener.AcceptAsync();

        while (true)
        {
            var buffer = new byte[1_024];

            var received = await handler.ReceiveAsync(buffer, SocketFlags.None);
            var response = Encoding.UTF8.GetString(buffer, 0, received);

            string eom = "<|EOM|>";
            if (response.IndexOf(eom) > -1)
            {
                Console.WriteLine($"Server received message: {response.Replace(eom, "")}");

                string messageFromServer = "<|ACK|>";
                byte[] bytes = Encoding.UTF8.GetBytes(messageFromServer);

                await handler.SendAsync(bytes, 0);
                Console.WriteLine($"Server sent a reponse: \"{messageFromServer}\"");
                //break;
            }
        }
    }

    public void Dispose()
    {
        Console.WriteLine("Server shutdown...");
        _listener.Dispose();
    }
}
