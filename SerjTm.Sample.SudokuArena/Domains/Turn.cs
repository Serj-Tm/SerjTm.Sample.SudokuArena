using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerjTm.Sample.SudokuArena.Domains
{
    public partial class Turn
    {
        public readonly int Id;
        public readonly User User;
        public readonly int Cell;
        public readonly int Number;
        public readonly DateTime Time;
        public readonly bool IsSkipped = false;
    }
}
