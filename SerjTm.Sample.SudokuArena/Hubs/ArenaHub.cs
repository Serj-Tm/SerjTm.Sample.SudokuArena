using Microsoft.AspNetCore.SignalR;
using SerjTm.Sample.SudokuArena.Domains;
using SerjTm.Sample.SudokuArena.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerjTm.Sample.SudokuArena.Hubs
{
    public class ArenaHub:Hub<IArenaClient>
    {
        public ArenaHub(ArenaEngine engine)
        {
            this.ArenaEngine = engine;
        }
        private ArenaEngine ArenaEngine;
        public async Task Turn(User_Name user, int cell, int number)
        {
            var (world, result) = ArenaEngine.Turn(user, cell, number);

            await Clients.All.Turned(result.Turn, result.IsWin, result.IsFail);

            if (result.IsWin || result.IsFail)
            {
                await Clients.All.Game(world.Game);
                await Clients.All.Top(world.Top);
            }

        }
        public async Task Top()
        {
            await Clients.Caller.Top(ArenaEngine.World.Top);
        }

        public async override Task OnConnectedAsync()
        {
            await Clients.Caller.Game(this.ArenaEngine.World.Game);
            await Clients.Caller.Top(this.ArenaEngine.World.Top);

            base.OnConnectedAsync();
        }

    }
}
