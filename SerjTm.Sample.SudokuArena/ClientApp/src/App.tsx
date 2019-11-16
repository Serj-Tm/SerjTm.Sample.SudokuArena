import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import * as signalR from "@aspnet/signalr";
import { Arena } from './models/arena';

import './custom.css'

function connectToSignalR(applyArena:(f:(arena:Arena)=>Arena)=>void) {

  const connection = new signalR.HubConnectionBuilder()
    .withUrl("/hub")
    .build();

  connection.on("turned", (username: string, cell: number, number: number) => {
    applyArena((arena:Arena) => arena.turned(cell, number));
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
        <Route exact path='/' render={(props) => <Home connection={this.state.connection} arena={this.state.arena}/>} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data' component={FetchData} />
      </Layout>
    );
  }
}

interface AppState {
  connection?: signalR.HubConnection;
  arena: Arena;
}

