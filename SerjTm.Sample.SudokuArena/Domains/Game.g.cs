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

    partial class TurnResult
    {
        public TurnResult(Turn turn, bool ? isWin = null, bool ? isFail = null)
        {
            Turn = turn;
            IsWin = isWin ?? IsWin;
            IsFail = isFail ?? IsFail;
        }

        public TurnResult With(Turn turn = null, bool ? isWin = null, bool ? isFail = null)
        {
            return new TurnResult(turn ?? Turn, isWin ?? IsWin, isFail ?? IsFail);
        }
    }

    public static partial class TurnResultHelper
    {
        public static TurnResult By(this IEnumerable<TurnResult> items, Turn turn = null, bool ? isWin = null, bool ? isFail = null)
        {
            if (turn != null)
                return items.FirstOrDefault(_item => _item.Turn == turn);
            if (isWin != null)
                return items.FirstOrDefault(_item => _item.IsWin == isWin);
            if (isFail != null)
                return items.FirstOrDefault(_item => _item.IsFail == isFail);
            return null;
        }
    }

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

    partial class Turn
    {
        public Turn(int id, User user, int cell, int number, DateTime time, bool ? isSkipped = null)
        {
            Id = id;
            User = user;
            Cell = cell;
            Number = number;
            Time = time;
            IsSkipped = isSkipped ?? IsSkipped;
        }

        public Turn With(int ? id = null, User user = null, int ? cell = null, int ? number = null, DateTime? time = null, bool ? isSkipped = null)
        {
            return new Turn(id ?? Id, user ?? User, cell ?? Cell, number ?? Number, time ?? Time, isSkipped ?? IsSkipped);
        }
    }

    public static partial class TurnHelper
    {
        public static Turn By(this IEnumerable<Turn> items, int ? id = null, User user = null, int ? cell = null, int ? number = null, DateTime? time = null, bool ? isSkipped = null)
        {
            if (id != null)
                return items.FirstOrDefault(_item => _item.Id == id);
            if (user != null)
                return items.FirstOrDefault(_item => _item.User == user);
            if (cell != null)
                return items.FirstOrDefault(_item => _item.Cell == cell);
            if (number != null)
                return items.FirstOrDefault(_item => _item.Number == number);
            if (time != null)
                return items.FirstOrDefault(_item => _item.Time == time);
            if (isSkipped != null)
                return items.FirstOrDefault(_item => _item.IsSkipped == isSkipped);
            return null;
        }
    }

    partial class User
    {
        public User(string name, int ? winRate = null)
        {
            Name = name;
            WinRate = winRate ?? WinRate;
        }

        public User With(string name = null, int ? winRate = null)
        {
            return new User(name ?? Name, winRate ?? WinRate);
        }
    }

    public static partial class UserHelper
    {
        public static User By(this IEnumerable<User> items, string name = null, int ? winRate = null)
        {
            if (name != null)
                return items.FirstOrDefault(_item => _item.Name == name);
            if (winRate != null)
                return items.FirstOrDefault(_item => _item.WinRate == winRate);
            return null;
        }
    }

    partial class User_Name
    {
        public User_Name(string name)
        {
            Name = name;
        }

        public User_Name With(string name = null)
        {
            return new User_Name(name ?? Name);
        }
    }

    public static partial class User_NameHelper
    {
        public static User_Name By(this IEnumerable<User_Name> items, string name = null)
        {
            if (name != null)
                return items.FirstOrDefault(_item => _item.Name == name);
            return null;
        }
    }
}