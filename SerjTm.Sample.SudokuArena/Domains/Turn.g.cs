using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;
using NitroBolt.Functional;
using NitroBolt.Immutable;
using System.Threading.Tasks;

namespace SerjTm.Sample.SudokuArena.Domains
{
    partial class Turn
    {
        public Turn(int id, User user, int cell, int number, DateTime time, bool ? isSkipped = null)
        {
            Id = id;
            User = user;
            Cell = cell;
            Number = number;
            Time = time;
            IsSkipped = isSkipped ?? IsSkipped;
        }

        public Turn With(int ? id = null, User user = null, int ? cell = null, int ? number = null, DateTime? time = null, bool ? isSkipped = null)
        {
            return new Turn(id ?? Id, user ?? User, cell ?? Cell, number ?? Number, time ?? Time, isSkipped ?? IsSkipped);
        }
    }

 
}