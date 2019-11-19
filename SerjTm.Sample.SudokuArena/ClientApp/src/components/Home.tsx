import React, { Component, useState } from 'react';
import { Input, Button, Row, Col } from 'reactstrap';
import { oc } from 'ts-optchain';
import * as signalR from "@aspnet/signalr";
import { User_Name, Arena } from '../models/arena';
import { ArenaView, ArenaViewProps } from '../controls/ArenaView';
import { TurnsView } from '../controls/TurnsView';


export class Home extends Component<HomeProps> {
  static displayName = Home.name;



  render() {

    console.log(oc(this.props.connection).state());
    return (
      oc(this.props.connection).state() != signalR.HubConnectionState.Connected
        ? <Button onClick={() => this.props.reconnect}>Подключиться к серверу</Button>
      : (
        <Row>
          <Col sm='10'>
            {
              this.props.arena.user == null
                ? <SignUp setUser={this.props.setUser} />
                : (
                  <div>
                    <h3>{this.props.arena.user.name}</h3>
                    <ArenaView connection={this.props.connection} arena={this.props.arena} />
                    <Button disabled={this.props.arena.cells.length != 0} onClick={this.sendWin}>Auto win</Button>{' '}
                    <Button disabled={this.props.arena.cells.length != 0} onClick={this.sendFail}>Auto fail</Button>{' '}
                  </div>
                  )
            }
          </Col>
          <Col sm='2'>
            <TurnsView arena={this.props.arena} />
          </Col>
        </Row>
        )
    );
  }

  sendField = async (field: number[]) => {
    if (this.props.connection == null)
      return;

    for (var cell in field) {
      await this.props.connection.send("turn", this.props.arena.user, cell, field[cell] - 1);
    }

  }
  sendWin = async () => {

    const field = [
      5, 3, 4, 6, 7, 8, 9, 1, 2,
      6, 7, 2, 1, 9, 5, 3, 4, 8,
      1, 9, 8, 3, 4, 2, 5, 6, 7,
      8, 5, 9, 7, 6, 1, 4, 2, 3,
      4, 2, 6, 8, 5, 3, 7, 9, 1,
      7, 1, 3, 9, 2, 4, 8, 5, 6,
      9, 6, 1, 5, 3, 7, 2, 8, 4,
      2, 8, 7, 4, 1, 9, 6, 3, 5,
      3, 4, 5, 2, 8, 6, 1, 7, 9
    ];

    this.sendField(field);

  }
  sendFail = async () => {

    const field = [
      1, 2, 3, 4, 5, 6, 7, 8, 9,
      4, 5, 6, 1, 2, 3,
    ];

    this.sendField(field);

  }
}

function SignUp(props: { setUser: (user: User_Name) => void}) {
  const [userName, setUserName] = useState('');

  return (
    <div>
      Представьтесь, пожалуйста <br />
      <Input value={userName} onChange={e => setUserName(e.target.value)} /><br/>
      <Button disabled={userName == ''} onClick={e=>props.setUser({name:userName})}>Fight!</Button>
    </div>

    );
}



interface SignUpProps {
  setUser: (user: User_Name) => void;
}


interface HomeProps extends SignUpProps, ArenaViewProps {
  reconnect: () => void;
}