export class Arena {
  constructor(cells?: number[]) {
    this.cells = cells || [];
  }
  cells: number[];

  turned(cell: number, number: number) {
    const cells = { ...this.cells };
    cells[cell] = number;

    return new Arena(cells);
  }
}