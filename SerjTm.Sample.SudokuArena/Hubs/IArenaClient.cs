using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerjTm.Sample.SudokuArena.Hubs
{
    public interface IArenaClient
    {
        Task Turned(string user, int number, int cell);
        //Task Arena(int[] cells);
    }
}
