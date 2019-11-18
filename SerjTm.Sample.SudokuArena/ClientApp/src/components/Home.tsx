import React, { Component, useState } from 'react';
import { User_Name, Arena } from '../models/arena';
import { ArenaView, ArenaViewProps } from '../controls/ArenaView';
import { Input, Button } from 'reactstrap';
import { oc } from 'ts-optchain';


export class Home extends Component<HomeProps> {
  static displayName = Home.name;



  render () {
    return (
      [
        this.props.arena.user == null
          ? <SignUp setUser={this.props.setUser}/>
          : <ArenaView connection={this.props.connection} arena={this.props.arena} />,
        <TurnsView arena={this.props.arena}/>
      ]
    );
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

function TurnsView(props: { arena: Arena }) {
  console.log(props.arena.turns);
  return (
    <div>
      {
        props.arena.turns.map((turn, k) =>
          <div key={k}>{turn.cell}{' '}{turn.number + 1}</div>
        )
      }
    </div>
    );
}

interface SignUpProps {
  setUser: (user: User_Name) => void;
}


interface HomeProps extends SignUpProps, ArenaViewProps {
}