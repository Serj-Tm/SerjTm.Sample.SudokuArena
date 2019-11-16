using NitroBolt.Functional;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace SerjTm.Sample.SudokuArena.Domains
{
    public partial class World
    {
        public readonly Game Game = new Game();
        public readonly ImmutableDictionary<Guid, User> Users = ImmutableDictionary<Guid, User>.Empty;


        public (World world, TurnResult result) Turn(IUser_Id_Name user, int cell, int number)
        {
            var users = this.Users;
            var currentUser = users.Find(user.Id);
            if (currentUser != null)
            {
                currentUser = new User(user.Id, user.Name);
                users = users.Add(currentUser.Id, currentUser);
            }

            var world = this.With(users: users);
            
            var (game, turn) = this.Game.Turn(currentUser, cell, number);
            if (turn.IsSkipped)
                return (world.With(game: game), new TurnResult(turn));

            return (world.With(game: game.IsFinished ? new Game() : game), new TurnResult(turn, isFinished: game.IsFinished));
        }
        static ImmutableDictionary<Guid, User> Win(ImmutableDictionary<Guid, User> users, User user)
        {
            return users.SetItem(user.Id, user.With(winRate:user.WinRate + 1));
        }

    }

    public partial class TurnResult
    {
        public readonly Turn Turn;
        public readonly bool IsFinished = false;
    }

    public partial class Game
    {
        public readonly Guid Id = Guid.NewGuid();
        public readonly ImmutableArray<int?> Field = EmptyField;
        public readonly ImmutableList<Turn> Turns = ImmutableList<Turn>.Empty;

        public (Game game, Turn turn) Turn(User user, int cell, int number)
        {
            var isSkipped = Field[cell] != null;
            var field = this.Field.SetItem(cell, number);

            isSkipped |= !Check(field);

            var turn = new Domains.Turn(Turns.Count, user, cell, number, DateTime.UtcNow, isSkipped);
            var game = this.With(turns: Turns.Add(turn));

            return (isSkipped ? game : game.With(field:field), turn);
        }
        const int CellCount = 9 * 9;
        public bool IsFinished => Turns.Count(turn => !turn.IsSkipped) == CellCount;

        static bool Check(ImmutableArray<int?> field)
        {
            return Lines.All(line => Check(field, line));
        }
        static bool Check(ImmutableArray<int?> field, IEnumerable<int> line)
        {
            return line.Select(i => field[i]).Where(n => n != null).GroupBy(n => n).All(group => group.Count() == 1);
        }

        static readonly IEnumerable<IEnumerable<int>> Rows = Enumerable.Range(0, 9).Select(row => Enumerable.Range(0, 9).Select(col => 9 * row + col).ToArray()).ToArray();
        static readonly IEnumerable<IEnumerable<int>> Columns = Enumerable.Range(0, 9).Select(col => Enumerable.Range(0, 9).Select(row => 9 * row + col).ToArray()).ToArray();
        static readonly IEnumerable<IEnumerable<int>> Squares = Enumerable.Range(0, 9).Select(square =>
        {
            var squareRow = square / 3;
            var squareCol = square % 3;

            return Enumerable.Range(0, 9).Select(i =>
            {
                var row = i / 3;
                var col = i % 3;
                return 9 * (3 * squareRow + row) + (3 * squareCol + col);
            }).ToArray();
        }).ToArray();

        static readonly IEnumerable<IEnumerable<int>> Lines = Rows.Concat(Columns).Concat(Squares).ToArray();

        static readonly ImmutableArray<int?> EmptyField = Enumerable.Range(0, CellCount).Select(_ => (int?)null).ToImmutableArray();
    }
    public partial class Turn
    {
        public readonly int Id;
        public readonly User User; 
        public readonly int Cell;
        public readonly int Number;
        public readonly DateTime Time;
        public readonly bool IsSkipped = false;
    }
    public partial class Win
    {
        public readonly Guid Id = Guid.NewGuid();
        public readonly User User;
        public readonly DateTime Time;
    }
    public partial class User: IUser_Id_Name
    {
        public readonly Guid Id = Guid.NewGuid();
        public readonly string Name;
        public readonly int WinRate = 0;

        Guid IUser_Id_Name.Id => Id;

        string IUser_Id_Name.Name => Name;
    }

#pragma warning disable CA1707 // Identifiers should not contain underscores
    public interface IUser_Id_Name
    {
        Guid Id { get; }
        string Name { get; }
    }

    public partial class User_Id_Name: IUser_Id_Name
    {
        public readonly Guid Id = Guid.NewGuid();
        public readonly string Name;

        Guid IUser_Id_Name.Id => Id;

        string IUser_Id_Name.Name => Name;
    }
#pragma warning restore CA1707 // Identifiers should not contain underscores


}
