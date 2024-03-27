using game_contracts.diary;

namespace game.character.diary;

class CharacterDiary : IDiary
{
    public CharacterDiary()
    {
        Finished = new List<IQuest>();
        Active = new List<IQuest>();

        (Active as List<IQuest>).Add(new Quest("test", "description", "jon snow"));
        (Active as List<IQuest>).Add(new Quest("new test", "finished!", "joe biden"));

        (Finished as List<IQuest>).Add(new Quest("one", "one description", "one direction"));
        (Finished as List<IQuest>).Add(new Quest("two", "two description description", "two direction"));
        (Finished as List<IQuest>).Add(new Quest("three", "three description description description", "three direction"));
        (Finished as List<IQuest>).Add(new Quest("four", "four description description description description", "four direction"));
        (Finished as List<IQuest>).Add(new Quest("five", "five description", "five direction"));
        (Finished as List<IQuest>).Add(new Quest("six", "six description description", "six direction"));
    }

    public IEnumerable<IQuest> Finished { get; } 

    public IEnumerable<IQuest> Active { get; } 
}
