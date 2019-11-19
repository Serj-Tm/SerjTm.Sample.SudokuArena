using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerjTm.Sample.SudokuArena.Domains
{
    public partial class TurnResult
    {
        public readonly Turn Turn;
        public readonly bool IsWin = false;
        public readonly bool IsFail = false;
    }

}
