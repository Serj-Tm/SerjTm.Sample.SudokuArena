import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import * as signalR from "@aspnet/signalr";
import { Arena, Turn, Game, User_Name_Rate } from './models/arena';
import { Home } from './components/Home';
import { TopView } from './controls/TopView';

import './custom.css'

function connectToSignalR(applyArena:(f:(arena:Arena)=>Arena)=>void) {

  const connection = new signalR.HubConnectionBuilder()
    .withUrl("/hub")
    .configureLogging(signalR.LogLevel.Debug)
    .build();


  connection.on("turned", (turn: Turn, isWin:boolean, isFail:boolean) => {
    applyArena((arena:Arena) => arena.turned(turn, isWin, isFail));
  });
  connection.on("game", (game: Game) => {
    applyArena((arena: Arena) => arena.gamed(game));
  });
  connection.on("top", (users: User_Name_Rate[]) => {
    applyArena((arena: Arena) => arena.with({ users: users }));
  });

  return connection;
}

export default class App extends Component<{}, AppState> {
  static displayName = App.name;

  constructor(props: any) {
    super(props);

    this.state = { arena: new Arena() };
  }

  componentDidMount() {
    const connection = connectToSignalR(this.applyArena);
    connection.start();
    this.setState({ connection: connection });
  }

  componentWillUnmount() {
    if (this.state.connection != null) {
      this.state.connection.stop();
    }

  }

  applyArena = (f: (arena: Arena) => Arena) =>{
    this.setState(prevState => ({ ...prevState, arena: f(prevState.arena) }));
  }

  render () {
    return (
      <Layout>
        <Route exact path='/' render={(props) => <Home connection={this.state.connection} arena={this.state.arena} setUser={user => this.applyArena(arena => arena.with({ user: user }))} />} />
        <Route path='/top' render={(props) => <TopView users={this.state.arena.users} />} />
      </Layout>
    );
  }
}

interface AppState {
  connection?: signalR.HubConnection;
  arena: Arena;
}

