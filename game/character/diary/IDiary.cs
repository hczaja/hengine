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
    public Quest(string title, string description, string author)
        => (Title, Description, Author) = (title, description, author);

    public string Title { get; }

    public string Description { get; }

    public string Author { get; }

    public IEnumerable<string> Logs => new List<string>();

    public IEnumerable<Func<bool>> Conditions => new List<Func<bool>>();
}
