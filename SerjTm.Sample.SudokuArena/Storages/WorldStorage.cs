using SerjTm.Sample.SudokuArena.Domains;
using SerjTm.Sample.SudokuArena.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SerjTm.Sample.SudokuArena.Storages
{
    public class WorldStorage
    {
        public World World => world;
        private World world = new World();

        public (World world, TResult result) UpdateWorld<TResult>(Func<World, (World, TResult)> f)
        {
            return Freelock.Exchange(ref this.world, f);
        }
    }

 


}
