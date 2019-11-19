using NitroBolt.Functional;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace SerjTm.Sample.SudokuArena.Domains
{
 


    public partial class Game
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public ImmutableArray<int?> Field { get; private set; } = EmptyField;
        public ImmutableList<Turn> Turns { get; private set; } = ImmutableList<Turn>.Empty;

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
        public bool IsWin => Turns.Count(turn => !turn.IsSkipped) == CellCount;
        public bool IsFail => Enumerable.Range(0, CellCount)
            .Any(cell => Field[cell] == null && CellLines(cell).SelectMany(line => Numbers(this.Field, line)).Distinct().Count() == 9);

        static bool Check(ImmutableArray<int?> field)
        {
            return Lines.All(line => Check(field, line));
        }
        static bool Check(ImmutableArray<int?> field, IEnumerable<int> line)
        {
            return Numbers(field, line).GroupBy(n => n).All(group => group.Count() == 1);
        }

        static IEnumerable<int> Numbers(ImmutableArray<int?> field, IEnumerable<int> line) 
            => line.Select(cell => field[cell]).Where(n => n != null).Select(n => (int)n);

        static IEnumerable<int> Row(int row) => Enumerable.Range(0, 9).Select(col => 9 * row + col).ToArray();
        static IEnumerable<int> Column(int col) => Enumerable.Range(0, 9).Select(row => 9 * row + col).ToArray();
        static IEnumerable<int> Square(int square)
        {
            var squareRow = square / 3;
            var squareCol = square % 3;

            return Enumerable.Range(0, 9).Select(i =>
            {
                var row = i / 3;
                var col = i % 3;
                return 9 * (3 * squareRow + row) + (3 * squareCol + col);
            }).ToArray();
        }

        static IEnumerable<IEnumerable<int>> CellLines(int cell)
        {
            var row = cell / 9;
            var col = cell % 9;

            yield return Row(row);
            yield return Column(col);
            yield return Square(3 * (row / 3) + col / 3);
        }

        static readonly IEnumerable<IEnumerable<int>> Rows = Enumerable.Range(0, 9).Select(row => Row(row)).ToArray();
        static readonly IEnumerable<IEnumerable<int>> Columns = Enumerable.Range(0, 9).Select(col => Column(col)).ToArray();
        static readonly IEnumerable<IEnumerable<int>> Squares = Enumerable.Range(0, 9).Select(square => Square(square)).ToArray();

        static readonly IEnumerable<IEnumerable<int>> Lines = Rows.Concat(Columns).Concat(Squares).ToArray();

        public static readonly ImmutableArray<int?> EmptyField = Enumerable.Range(0, CellCount).Select(_ => (int?)null).ToImmutableArray();
    }

 


}
