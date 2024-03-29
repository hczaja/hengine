using game_contracts.logger;
using System.Drawing;

namespace game_graphics.logger;

record Message(string Content) : IMessage 
{ 
    public Color Color { get; init; }
}
