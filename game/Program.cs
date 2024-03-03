using game.core;
using game_engine.core;
using game_engine.time;
using game_engine.window;

var engine = new HEngine(
    new HEngineClock(),
    new HEngineWindow(new GameCore()));

engine.Run();