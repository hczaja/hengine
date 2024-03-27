using game_contracts.diary;

namespace game.character.diary;

class Quest : IQuest
{
    public Quest(string title, string description, string author)
        => (Title, Description, Author) = (title, description, author);

    public string Title { get; }

    public string Description { get; }

    public string Author { get; }

    public IEnumerable<string> Logs => new List<string>();

    public IEnumerable<Func<bool>> Conditions => new List<Func<bool>>();
}
