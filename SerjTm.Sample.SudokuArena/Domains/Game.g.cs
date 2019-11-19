using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;
using NitroBolt.Functional;
using NitroBolt.Immutable;
using NitroBolt.Functional;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace SerjTm.Sample.SudokuArena.Domains
{
    partial class Game
    {
        public Game(Guid? id = null, ImmutableArray<int ? >? field = null, ImmutableList<Turn> turns = null)
        {
            Id = id ?? Id;
            Field = field ?? Field;
            Turns = turns ?? Turns;
        }

        public Game With(Guid? id = null, ImmutableArray<int ? >? field = null, ImmutableList<Turn> turns = null)
        {
            return new Game(id ?? Id, field ?? Field, turns ?? Turns);
        }
    }

    public static partial class GameHelper
    {
        public static Game By(this IEnumerable<Game> items, Guid? id = null, ImmutableList<Turn> turns = null)
        {
            if (id != null)
                return items.FirstOrDefault(_item => _item.Id == id);
            if (turns != null)
                return items.FirstOrDefault(_item => _item.Turns == turns);
            return null;
        }
    }
}