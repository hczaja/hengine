using System.Net.Sockets;
using System.Net;
using game_engine.time;

namespace rts_game.client;

public class GameClient : IDisposable
{
    private readonly Socket _client;
    private readonly IPEndPoint _endpoint;

    private readonly RTSEngine _engine;

    public GameClient(IPEndPoint endpoint)
    {
        _endpoint = endpoint;
        _client = new Socket(
            _endpoint.AddressFamily,
            SocketType.Stream,
            ProtocolType.Tcp);

        _engine = new RTSEngine(
            new HEngineClock(),
            new MainRTSWindow(new RTSCore(_client)));
    }

    public async Task Run()
    {
        //Console.WriteLine("Connecting to server...");
        //await _client.ConnectAsync(_endpoint);

        //Console.WriteLine("Connected.");
        _engine.Run();

        //while (true)
        //{
        //    // Send message.
        //    var message = "Hi friends!<|EOM|>";
        //    var messageBytes = Encoding.UTF8.GetBytes(message);
        //    _ = await _client.SendAsync(messageBytes, SocketFlags.None);
        //    Console.WriteLine($"Socket client sent message: \"{message}\"");

        //    // Receive ack.
        //    var buffer = new byte[1_024];
        //    var received = await _client.ReceiveAsync(buffer, SocketFlags.None);
        //    var response = Encoding.UTF8.GetString(buffer, 0, received);
        //    if (response == "<|ACK|>")
        //    {
        //        Console.WriteLine(
        //            $"Socket client received acknowledgment: \"{response}\"");
        //        break;
        //    }
        //}

    }

    public void Dispose()
    {
        _client.Shutdown(SocketShutdown.Both);
        _client.Dispose();
    }
}
