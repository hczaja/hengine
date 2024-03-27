using game_contracts.diary;

namespace game.character.diary;

class QuestStorage
{
    private IEnumerable<IQuest> Quests { get; }

    public QuestStorage()
    {
        Quests = LoadQuests();
    }

    private IEnumerable<IQuest> LoadQuests()
    {
        var quests = new List<IQuest>();
        using (var reader = new StreamReader(""))
        {
            string data = reader.ReadToEnd();
        }

        return quests;
    }

    public IQuest GetById(string id)
    {
        throw new NotImplementedException();
    }
}

