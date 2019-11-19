using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;
using NitroBolt.Functional;
using NitroBolt.Immutable;
using System;
using System.Collections.Generic;
using System.Linq;
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

    public static partial class UserHelper
    {
        public static User By(this IEnumerable<User> items, string name = null, int ? winRate = null)
        {
            if (name != null)
                return items.FirstOrDefault(_item => _item.Name == name);
            if (winRate != null)
                return items.FirstOrDefault(_item => _item.WinRate == winRate);
            return null;
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

    public static partial class User_NameHelper
    {
        public static User_Name By(this IEnumerable<User_Name> items, string name = null)
        {
            if (name != null)
                return items.FirstOrDefault(_item => _item.Name == name);
            return null;
        }
    }
}