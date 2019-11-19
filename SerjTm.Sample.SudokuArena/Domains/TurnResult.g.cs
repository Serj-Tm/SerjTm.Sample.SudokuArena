using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;
using NitroBolt.Functional;
using NitroBolt.Immutable;
using System.Threading.Tasks;

namespace SerjTm.Sample.SudokuArena.Domains
{
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

 
}