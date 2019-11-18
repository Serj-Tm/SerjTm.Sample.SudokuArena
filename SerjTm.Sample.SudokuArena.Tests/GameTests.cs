using SerjTm.Sample.SudokuArena.Domains;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Xunit;

namespace SerjTm.Sample.SudokuArena.Tests
{
    public class GameTests
    {

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        public void CheckSkipped(int number)
        {
            var numbers = new int?[]
            {
                0, 1, 2, 3, 4, 5, 6, 7, 8,
                3, 4, 5, 0, 1, 2,
            };
            var field = numbers.Concat(Game.EmptyField.Skip(numbers.Length)).ToImmutableArray();

            var game = new Game(field:field);

            Assert.True(game.Turn(new User("user1"), 15, number).turn.IsSkipped);

        }
        [Fact]
        public void CheckFail()
        {
            var numbers = new int?[]
            {
                0, 1, 2, 3, 4, 5, 6, 7, 8,
                3, 4, 5, 0, 1, 2,
            };
            var field = numbers.Concat(Game.EmptyField.Skip(numbers.Length)).ToImmutableArray();

            var game = new Game(field: field);

            Assert.True(game.IsFail);

        }
    }
}
