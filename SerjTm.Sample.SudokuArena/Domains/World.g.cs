using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;
using NitroBolt.Functional;
using NitroBolt.Immutable;
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

 
}