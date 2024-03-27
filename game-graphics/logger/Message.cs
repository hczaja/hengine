using game_engine.logger;
using System.Drawing;

namespace game.logger;

record Message(string Content) : IMessage 
{ 
    public Color Color { get; init; }
}
