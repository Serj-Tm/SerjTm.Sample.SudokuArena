using SerjTm.Sample.SudokuArena.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerjTm.Sample.SudokuArena.Hubs
{
    public interface IArenaClient
    {
        Task Turned(Turn turn, bool isWin, bool isFail);
        Task Game(Game game);
        Task Win(User user);

        Task Top(IEnumerable<User> users);
    }
}
