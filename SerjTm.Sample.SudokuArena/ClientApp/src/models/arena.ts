export class Arena {
  constructor(cells?: number[], user?: User_Name, turns?:Turn[]) {
    this.cells = cells || [];
    this.user = user;
    this.turns = turns || [];
  }
  cells: number[];
  user?: User_Name = undefined;
  turns: Turn[] = [];
  

  turned(turn: Turn) {
    let cells = this.cells;
    if (!turn.isSkipped) {
      cells = { ...this.cells }
      cells[turn.cell] = turn.number;
    }

    return this.with({ cells: cells, turns: [turn].concat(this.turns).slice(0, 20) });
  }
  gamed(game: Game) {
    const cells = [];
    for (const i in game.turns) {
      const turn = game.turns[i];
      if (turn.isSkipped)
        continue;
      cells[turn.cell] = turn.number;
    }
    return this.with({ cells: cells });
  }
  with(props: { cells?: number[], user?: User_Name, turns?: Turn[] }) {
    return new Arena(props.cells || this.cells, props.user || this.user, props.turns || this.turns);
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