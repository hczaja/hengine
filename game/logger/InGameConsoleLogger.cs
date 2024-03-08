using game_engine.logger;
using System.Text;

namespace game.logger
{
    class InGameConsoleLogger : ILogger
    {
        private readonly StringBuilder _buffer;

        public InGameConsoleLogger()
        {
            _buffer = new StringBuilder();
            OnLog = new EventHandler<EventArgs>((_, _) => { });
        }

        public string DisplayText => _buffer.ToString();
        public EventHandler<EventArgs> OnLog { get; set; }

        public void Log(string message)
        {              
            _buffer.AppendLine($"> {message}");
            OnLog?.Invoke(null, new EventArgs());
        }
    }
}
