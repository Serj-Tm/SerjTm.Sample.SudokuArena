using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;
using NitroBolt.Functional;
using NitroBolt.Immutable;
using System.Threading.Tasks;

namespace SerjTm.Sample.SudokuArena.Domains
{
    partial class User
    {
        public User(string name, int ? winRate = null)
        {
            Name = name;
            WinRate = winRate ?? WinRate;
        }

        public User With(string name = null, int ? winRate = null)
        {
            return new User(name ?? Name, winRate ?? WinRate);
        }
    }


    partial class User_Name
    {
        public User_Name(string name)
        {
            Name = name;
        }

        public User_Name With(string name = null)
        {
            return new User_Name(name ?? Name);
        }
    }

}