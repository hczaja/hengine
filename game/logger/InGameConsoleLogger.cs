using game_engine.logger;
using System.Text;

namespace game.logger
{
    class InGameConsoleLogger : ILogger
    {
        private readonly StringBuilder _buffer = new StringBuilder(128);

        public string DisplayText => _buffer.ToString();

        public void Log(string message)
        {
            _buffer.Append(message);
        }
    }
}
