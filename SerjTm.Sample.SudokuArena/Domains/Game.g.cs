using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;
using NitroBolt.Functional;
using NitroBolt.Immutable;
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

}