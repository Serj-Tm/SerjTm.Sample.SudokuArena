export class Arena {
  constructor(cells?: number[], user?: User_Name, turns?: Turn[], users?: User_Name_Rate[]) {
    this.cells = cells || [];
    this.user = user;
    this.turns = turns || [];
    this.users = users || [];
  }
  cells: number[];
  user?: User_Name = undefined;
  turns: Turn[] = [];
  users: User_Name_Rate[] = [];
  

  turned(turn: Turn, isWin: boolean, isFail: boolean) {
    turn = { ...turn, isWin: isWin, isFail: isFail };
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

  with(props: { cells?: number[], user?: User_Name, turns?: Turn[], users?: User_Name_Rate[] }) {
    return new Arena(props.cells || this.cells, props.user || this.user, props.turns || this.turns, props.users || this.users);
  }
}

export interface Turn {
  user: User_Name;
  cell: number;
  number: number;
  isSkipped: boolean;
  isWin?: boolean;
  isFail?: boolean;
}

export interface Game {
  turns: Turn[];
}

export interface User_Name{
  name: string;
}

export interface User_Name_Rate extends User_Name {
  winRate?: number;
}