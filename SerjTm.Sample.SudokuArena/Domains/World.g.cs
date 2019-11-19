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
    partial class World
    {
        public World(Game game = null, ImmutableDictionary<string, User> users = null)
        {
            Game = game ?? Game;
            Users = users ?? Users;
        }

        public World With(Game game = null, ImmutableDictionary<string, User> users = null)
        {
            return new World(game ?? Game, users ?? Users);
        }
    }

    public static partial class WorldHelper
    {
        public static World By(this IEnumerable<World> items, Game game = null, ImmutableDictionary<string, User> users = null)
        {
            if (game != null)
                return items.FirstOrDefault(_item => _item.Game == game);
            if (users != null)
                return items.FirstOrDefault(_item => _item.Users == users);
            return null;
        }
    }
}