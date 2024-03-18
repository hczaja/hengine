using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game.character.diary;

interface IDiary
{
    IEnumerable<IQuest> Finished { get; }
    IEnumerable<IQuest> Active { get; }
}

interface IQuest
{
    string Title { get; }
    string Description { get; }
    string Author { get; }
    IEnumerable<string> Logs { get; }
    IEnumerable<Func<bool>> Conditions { get; }
}

class Quest : IQuest
{
    public string Title => "test";

    public string Description => "description lorem ipsum";

    public string Author => "jon snow";

    public IEnumerable<string> Logs => new List<string>();

    public IEnumerable<Func<bool>> Conditions => new List<Func<bool>>();
}
