using game.core;
using game_engine.core;
using game_engine.settings;
using game_engine.time;
using game_engine.window;

var settings = new HEngineSettings();
var engine = new HEngine(
    new HEngineClock(settings.FPS),
    new HEngineWindow(
        new GameCore(settings),
        settings));

engine.Run();