using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerjTm.Sample.SudokuArena.Hubs
{
    public class ArenaHub:Hub<IArenaClient>
    {
        public async Task SendTurn(string user, int cell, int number)
        {
            await Clients.All.Turned(user, cell, number)
                .ConfigureAwait(false);
        }

        public async Task Turn(string user, int cell, int number)
        {
            await Clients.All.Turned(user, cell, number)
                .ConfigureAwait(false);
        }
    }
}
