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

            await Clients.All.Turned(result.Turn);

            if (result.IsWin || result.IsFail)
            {
                await Clients.All.Game(world.Game);
            }

        }

        public async override Task OnConnectedAsync()
        {
            await Clients.Caller.Game(this.ArenaEngine.World.Game);

            base.OnConnectedAsync();
        }

    }
}
