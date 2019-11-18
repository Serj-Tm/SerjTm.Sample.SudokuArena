import React, { Component, useState } from 'react';
import { Input, Button, Row, Col } from 'reactstrap';
import { oc } from 'ts-optchain';
import { User_Name, Arena } from '../models/arena';
import { ArenaView, ArenaViewProps } from '../controls/ArenaView';
import { TurnsView } from '../controls/TurnsView';


export class Home extends Component<HomeProps> {
  static displayName = Home.name;



  render () {
    return (
      <Row>
        <Col sm='10'>
          {
            this.props.arena.user == null
              ? <SignUp setUser={this.props.setUser} />
              : <ArenaView connection={this.props.connection} arena={this.props.arena} />
          }
        </Col>
        <Col sm='2'>
          <TurnsView arena={this.props.arena} />
        </Col>
      </Row>
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



interface SignUpProps {
  setUser: (user: User_Name) => void;
}


interface HomeProps extends SignUpProps, ArenaViewProps {
}