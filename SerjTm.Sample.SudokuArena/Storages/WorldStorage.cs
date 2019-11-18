using SerjTm.Sample.SudokuArena.Domains;
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

    public static class Freelock
    {
        public static (T, TResult) Exchange<T, TResult>(ref T item, Func<T, (T, TResult)> f) where T:class
        {
            for (; ; )
            {
                var currentItem = item;
                var (newItem, result) = f(currentItem);
                if (Interlocked.Exchange(ref item, newItem) == currentItem)
                    return (item, result);
            }
        }
    }

    public class ArenaEngine
    {
        public ArenaEngine(WorldStorage worldStorage)
        {
            this.WorldStorage = worldStorage;
        }
        private readonly WorldStorage WorldStorage;

        public (World world, TurnResult result) Turn(IUser_Name user, int cell, int number)
        {
            return WorldStorage.UpdateWorld(world => world.Turn(user, cell, number));
        }
        public World World => WorldStorage.World;
    }
}
