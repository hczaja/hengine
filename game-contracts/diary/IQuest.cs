namespace game_contracts.diary;

public interface IQuest
{
    string Title { get; }
    string Description { get; }
    string Author { get; }
    IEnumerable<string> Logs { get; }
    IEnumerable<Func<bool>> Conditions { get; }
}
