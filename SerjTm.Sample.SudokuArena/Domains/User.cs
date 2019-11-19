using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerjTm.Sample.SudokuArena.Domains
{
    public partial class User : IUser_Name
    {
        public string Name { get; private set; }
        public int WinRate { get; private set; } = 0;

    }

#pragma warning disable CA1707 // Identifiers should not contain underscores
    public interface IUser_Name
    {
        string Name { get; }
    }

    public partial class User_Name : IUser_Name
    {
        public string Name { get; private set; }

    }
#pragma warning restore CA1707 // Identifiers should not contain underscores
}
