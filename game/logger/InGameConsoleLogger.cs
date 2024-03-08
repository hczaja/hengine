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

        private readonly int _charactersLimit = 20;

        public void Log(string message)
        {
            var parts = SplitMessage(message);
            _buffer.AppendLine($"> {parts.First()}");

            foreach (var line in parts.Skip(1))
            {
                _buffer.AppendLine($"  {line}");
            }

            OnLog?.Invoke(null, new EventArgs());
        }

        private IEnumerable<string> SplitMessage(string message)
        {
            ICollection<string> result = [];

            while ($"> {message}".Length > _charactersLimit)
            {
                result.Add(string.Join("", message.Take(_charactersLimit)));
                message = string.Join("", message.Skip(_charactersLimit));
            }

            if (message.Length > 0)
            {
                result.Add(message);
            }

            return result;
        }
    }
}
