using SerjTm.Sample.SudokuArena.Domains;
using SerjTm.Sample.SudokuArena.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerjTm.Sample.SudokuArena.Engines
{
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
        public (World world, Game game) NewGame()
        {
            return WorldStorage.UpdateWorld(world => 
                { 
                    var newWorld = world.With(game: new Game()); 
                    return (newWorld, newWorld.Game); 
                } );
        }

        public World World => WorldStorage.World;
    }
}
