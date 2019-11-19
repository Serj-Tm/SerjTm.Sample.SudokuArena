import * as signalR from "@aspnet/signalr";
import { Arena, Turn, Game, User_Name_Rate } from '../models/arena';


export function connectToSignalR(applyArena: (f: (arena: Arena) => Arena) => void) {

  const connection = new signalR.HubConnectionBuilder()
    .withUrl("/hub")
    .configureLogging(signalR.LogLevel.Debug)
    .build();

  connection.on("turned", (turn: Turn, isWin: boolean, isFail: boolean) => {
    applyArena((arena: Arena) => arena.turned(turn, isWin, isFail));
  });
  connection.on("game", (game: Game) => {
    applyArena((arena: Arena) => arena.gamed(game));
  });
  connection.on("top", (users: User_Name_Rate[]) => {
    applyArena((arena: Arena) => arena.with({ users: users }));
  });

  return connection;
}