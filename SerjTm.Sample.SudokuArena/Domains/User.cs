using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerjTm.Sample.SudokuArena.Domains
{
    public partial class User : IUser_Name
    {
        public readonly string Name;
        public readonly int WinRate = 0;

        string IUser_Name.Name => Name;
    }

#pragma warning disable CA1707 // Identifiers should not contain underscores
    public interface IUser_Name
    {
        string Name { get; }
    }

    public partial class User_Name : IUser_Name
    {
        public readonly string Name;


        string IUser_Name.Name => Name;
    }
#pragma warning restore CA1707 // Identifiers should not contain underscores
}
