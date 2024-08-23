using game_engine.core;
using game_engine.time;
using rts_game;

var engine = new HEngine(
    new HEngineClock(),
    new MainRTSWindow(new RTSCore()));

engine.Run();
