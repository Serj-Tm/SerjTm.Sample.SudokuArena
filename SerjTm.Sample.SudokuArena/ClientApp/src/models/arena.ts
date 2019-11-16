export class Arena {
  constructor(cells?: number[]) {
    this.cells = cells || [];
  }
  cells: number[];

  turned(turn: Turn) {
    if (turn.isSkipped)
      return this;

    const cells = { ...this.cells };
    cells[turn.cell] = turn.number;

    return new Arena(cells);
  }
  gamed(game: Game) {
    const cells = [];
    for (const i in game.turns) {
      const turn = game.turns[i];
      if (turn.isSkipped)
        continue;
      cells[turn.cell] = turn.number;
    }
    return new Arena(cells);
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