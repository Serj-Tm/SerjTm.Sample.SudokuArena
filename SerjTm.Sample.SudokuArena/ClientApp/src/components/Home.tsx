import React, { Component } from 'react';
import * as signalR from "@aspnet/signalr";
import { Arena } from '../models/arena';
import { ArenaView } from '../controls/ArenaView';


export class Home extends Component<HomeProps> {
  static displayName = Home.name;



  render () {
    return (

      <ArenaView connection={this.props.connection} arena={this.props.arena}/>
    );
  }
}


interface HomeProps {
  connection?: signalR.HubConnection;
  arena: Arena;
}