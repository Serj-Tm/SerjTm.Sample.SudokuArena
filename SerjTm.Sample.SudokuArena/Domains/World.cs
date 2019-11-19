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
        public Game Game { get; private set; } = new Game();
        public ImmutableDictionary<string, User> Users { get; private set; } = ImmutableDictionary<string, User>.Empty;

        public IEnumerable<User> Top => Users.Values.OrderByDescending(user => user.WinRate).Take(30).ToArray();

        public (World world, TurnResult result) Turn(IUser_Name user, int cell, int number)
        {
            var users = this.Users;
            var currentUser = users.Find(user.Name);
            if (currentUser == null)
            {
                currentUser = new User(user.Name);
                users = users.Add(currentUser.Name, currentUser);
            }

            var world = this.With(users: users);

            var (game, turn) = this.Game.Turn(currentUser, cell, number);
            if (turn.IsSkipped)
                return (world.With(game: game), new TurnResult(turn));

            return (world.With(
                  game: game.IsWin || game.IsFail ? new Game() : game, 
                  users: game.IsWin ? Win(world.Users, turn.User) : world.Users
                ), 
                new TurnResult(turn, isWin: game.IsWin, isFail: game.IsFail)
              );
        }
        static ImmutableDictionary<string, User> Win(ImmutableDictionary<string, User> users, User user)
        {
            return users.SetItem(user.Name, (users.Find(user.Name) ?? user).With(winRate: user.WinRate + 1));
        }

    }
}
