export class Arena {
  constructor(cells?: number[], user?: User_Name) {
    this.cells = cells || [];
    this.user = user;
  }
  user?: User_Name = undefined;
  cells: number[];
  

  turned(turn: Turn) {
    if (turn.isSkipped)
      return this;

    const cells = { ...this.cells };
    cells[turn.cell] = turn.number;

    return new Arena(cells, this.user);
  }
  gamed(game: Game) {
    const cells = [];
    for (const i in game.turns) {
      const turn = game.turns[i];
      if (turn.isSkipped)
        continue;
      cells[turn.cell] = turn.number;
    }
    return new Arena(cells, this.user);
  }
  withUser(user: User_Name) {
    return new Arena(this.cells, user);
  }
}

export interface Turn {
  cell: number;
  number: number;
  isSkipped: boolean;
}

export interface Game {
  turns: Turn[];
}

export interface User_Name{
  name: string;
}