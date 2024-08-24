using rts_game.client;
using System.Net;

var hostName = Dns.GetHostName();
IPHostEntry localhost = await Dns.GetHostEntryAsync(hostName);

var ipAddress = localhost.AddressList[0];
var port = 8080;

IPEndPoint ipEndPoint = new(ipAddress, port);

GameClient client = new GameClient(ipEndPoint);
client.Run().Wait();