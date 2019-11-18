import React, { Component } from 'react';
import * as signalR from "@aspnet/signalr";
import { Table } from 'reactstrap';
import { Arena } from '../models/arena';


const displayNumber = (i: number) => i + 1;

export class ArenaView extends Component<ArenaViewProps> {
  static displayName = ArenaView.name;

  turn = (cell: number, number: number) => {
    if (this.props.connection != null) {
      this.props.connection.send("turn", { id: "f3488a67-9418-4cb1-84b6-04dd873cffaa", name: "user1" }, cell, number);
    }
  }


  render() {
    return (
      <Table bordered>
        <tbody>
          {
            range(9).map(row => (
              <tr key={row}>
                {range(9).map(col => {
                  const cell = 9 * row + col;
                  return <td key={col}>{this.props.arena.cells[cell] == null ? this.numberSelector(cell) : displayNumber(this.props.arena.cells[cell])}</td>
                })
                }
              </tr>
            ))
          }

        </tbody>
      </Table>
    );
  }
  numberSelector(cell: number) {
    return (
      <Table borderless size="sm">
        <tbody>
          {
            range(3).map(row => (
              <tr key={row}>
                {range(3).map(col => (
                  <td key={col} onClick={() => this.turn(cell, 3 * row + col)}>{displayNumber(3 * row + col)}</td>
                ))
                }
              </tr>
            ))
          }

        </tbody>
      </Table>
    );
  }
}

function range(n: number) {
  return Array.from(Array(n).keys());
}


export interface ArenaViewProps {
  connection?: signalR.HubConnection;
  arena: Arena;
}