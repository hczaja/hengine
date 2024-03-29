using game_contracts.logger;
using System.Text;

namespace game.logger
{
    class InGameConsoleLogger : ILogger
    {
        private StringBuilder buffer;

        public InGameConsoleLogger()
        {
            buffer = new StringBuilder();
            OnLog = new EventHandler<EventArgs>((_, _) => TryClearLog());
        }

        public string DisplayText => buffer.ToString();
        public EventHandler<EventArgs> OnLog { get; set; }

        private readonly int _charactersLimit = 20;

        private readonly int _logsLimit = 5000;
        private readonly int _logsToRemove = 2000;

        public void Log(IMessage message)
        {
            var parts = SplitMessage(message.Content);
            buffer.AppendLine($"> {parts.First()}");

            foreach (var line in parts.Skip(1))
            {
                buffer.AppendLine($"  {line}");
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

        private void TryClearLog()
        {
            if (buffer.Length > _logsLimit)
            {
                Console.WriteLine($"Buffer before clean: {buffer.Length}");
                buffer = buffer.Remove(0, _logsToRemove);
                Console.WriteLine($"Buffer after clean: {buffer.Length}");
            }
        }
    }
}
