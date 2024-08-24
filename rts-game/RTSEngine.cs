using game_engine.core;
using game_engine.time;
using game_engine.window;
using System.Net.Sockets;

namespace rts_game;

public class RTSEngine : HEngine
{
    public RTSEngine(IClock clock, IWindow window) 
        : base(clock, window)
    { }
}
