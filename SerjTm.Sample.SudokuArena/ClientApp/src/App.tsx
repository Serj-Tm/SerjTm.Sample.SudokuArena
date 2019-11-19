import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import * as signalR from "@aspnet/signalr";
import { Arena, Turn, Game, User_Name_Rate } from './models/arena';
import { Home } from './components/Home';
import { TopView } from './controls/TopView';
import { connectToSignalR } from './api/arena-signalr';

import './custom.css'


export default class App extends Component<{}, AppState> {
  static displayName = App.name;

  constructor(props: any) {
    super(props);

    this.state = { arena: new Arena() };
  }

  componentDidMount() {
    this.reconnect();
  }

  componentWillUnmount() {
    this.stopConnection();
  }

  applyArena = (f: (arena: Arena) => Arena) =>{
    this.setState(prevState => ({ ...prevState, arena: f(prevState.arena) }));
  }

  reconnect = () => {
    this.stopConnection();

    const connection = connectToSignalR(this.applyArena);
    connection.start();
    this.setState({ connection: connection });
  }
  stopConnection = () => {
    if (this.state.connection != null) {
      this.state.connection.stop();
    }
  }

  render () {
    return (
      <Layout>
        <Route exact path='/' render={(props) => <Home connection={this.state.connection} arena={this.state.arena} setUser={user => this.applyArena(arena => arena.with({ user: user }))} reconnect={this.reconnect} />} />
        <Route path='/top' render={(props) => <TopView users={this.state.arena.users} />} />
      </Layout>
    );
  }
}

interface AppState {
  connection?: signalR.HubConnection;
  arena: Arena;
}

