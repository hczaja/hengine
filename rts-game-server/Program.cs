using rts_game.server;
using System.Net;

var hostName = Dns.GetHostName();
IPHostEntry localhost = await Dns.GetHostEntryAsync(hostName);

var ipAddress = localhost.AddressList[0];
var port = 8080;

IPEndPoint ipEndPoint = new(ipAddress, port);

GameServer server = new GameServer(ipEndPoint);
server.Run().Wait();