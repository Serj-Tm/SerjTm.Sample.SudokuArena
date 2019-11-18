import React, { Component } from 'react';
import { Arena } from '../models/arena';
import './TurnsView.css';


export function TurnsView(props: { arena: Arena }) {
  console.log(props.arena.turns);
  return (
    <div>
      {
        props.arena.turns.map((turn, k) =>
          <div key={k} className={`${turn.isSkipped ? 'skipped' : ''}`}>{turn.cell}{' '}{turn.number + 1}</div>
        )
      }
    </div>
    );
}