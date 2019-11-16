import React, { Component } from 'react';
import * as signalR from "@aspnet/signalr";
import { Table } from 'reactstrap';
import { Arena } from '../models/arena';

export class Home extends Component<HomeProps> {
  static displayName = Home.name;

  turn = (cell: number, number: number) => {
    if (this.props.connection != null) {
      this.props.connection.send("turn", "user1", cell, number);
    }
  }


  render () {
    return (
      <Table bordered>
        <tbody>
          {
            [0, 3, 6].map(row => (
              <tr key={row}>
                {[0, 1, 2].map(col => (
                  <td key={col} onClick={() => this.turn(row + col, row + col)}>{this.props.arena.cells[row + col]}</td>
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

interface HomeProps {
  connection?: signalR.HubConnection;
  arena: Arena;
}