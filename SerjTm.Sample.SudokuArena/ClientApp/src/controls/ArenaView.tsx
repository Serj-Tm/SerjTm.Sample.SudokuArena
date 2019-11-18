import React, { Component } from 'react';
import * as signalR from "@aspnet/signalr";
import { Table } from 'reactstrap';
import { Arena } from '../models/arena';
import './ArenaView.css';


const displayNumber = (i: number) => i + 1;

export class ArenaView extends Component<ArenaViewProps> {
  static displayName = ArenaView.name;

  turn = (cell: number, number: number) => {
    if (this.props.connection != null) {
      this.props.connection.send("turn", this.props.arena.user, cell, number);
    }
  }


  render() {
    return (
      <Table bordered className='field'>
        <tbody>
          {
            range(9).map(row => (
              <tr key={row}>
                {range(9).map(col => {
                  const cell = 9 * row + col;
                  const square_row = row - 3 * Math.floor(row / 3);
                  const square_col = col - 3 * Math.floor(col / 3);
                  return (
                    <td key={col} className={`sq-r${square_row} sq-c${square_col}`}>
                      {
                        this.props.arena.cells[cell] == null
                          ? this.numberSelector(cell)
                          : (
                            <div className='number'>
                              {displayNumber(this.props.arena.cells[cell])}
                            </div>
                            )
                      }
                    </td>
                  );
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
      <Table borderless size="sm" className='number-selector'>
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