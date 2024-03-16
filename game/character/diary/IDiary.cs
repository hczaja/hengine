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
