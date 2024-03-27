namespace game_contracts.diary;

public interface IDiary
{
    IEnumerable<IQuest> Finished { get; }
    IEnumerable<IQuest> Active { get; }
}
