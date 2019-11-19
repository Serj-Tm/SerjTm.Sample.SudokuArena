using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerjTm.Sample.SudokuArena.Domains
{
    public partial class TurnResult
    {
        public Turn Turn { get; private set; }
        public bool IsWin { get; private set; } = false;
        public bool IsFail { get; private set; } = false;
    }

}
