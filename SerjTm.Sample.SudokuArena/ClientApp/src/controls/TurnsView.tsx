import React, { Component } from 'react';
import { Row, Col } from 'reactstrap';
import { Arena } from '../models/arena';
import './TurnsView.css';


export function TurnsView(props: { arena: Arena }) {
  return (
    <div>
      {
        props.arena.turns.map((turn, k) =>
          [
            <Row key={k} className={`${turn.isSkipped ? 'skipped' : ''}`}>
              <Col sm='6'>{turn.user.name}</Col>
              <Col sm='3'>{Math.floor(turn.cell / 9)}:{turn.cell - 9 * Math.floor(turn.cell / 9)}</Col>
              <Col sm='3'>{turn.number + 1}</Col>
            </Row>,
            turn.isWin ? <Row><Col sm='12' className='win'>Win!</Col></Row> : null,
            turn.isFail ? <Row><Col sm='12' className='fail'>Fail</Col></Row> : null,
            ]
          )
        }
    </div>
    );
}