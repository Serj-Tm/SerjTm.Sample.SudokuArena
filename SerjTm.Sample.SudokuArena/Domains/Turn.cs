using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerjTm.Sample.SudokuArena.Domains
{
    public partial class Turn
    {
        public int Id { get; private set; }
        public User User { get; private set; }
        public int Cell { get; private set; }
        public int Number { get; private set; }
        public DateTime Time { get; private set; }
        public bool IsSkipped { get; private set; } = false;
    }
}
