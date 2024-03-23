using System.Drawing;

namespace game_engine.logger;

public interface IMessage
{
    string Content { get; }
    Color Color { get; }
}
