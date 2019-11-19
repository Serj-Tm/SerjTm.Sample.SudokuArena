import React from 'react';
import { Row, Col } from 'reactstrap';
import { User_Name_Rate } from '../models/arena';
import './TurnsView.css';


export function TopView({ users }: { users: User_Name_Rate[] }) {
  return (
    <div>
      {
        users.map((user, k) =>
          <Row key={k}>
            <Col sm={{ size:2, offset: 2 }}>{user.name}</Col>
            <Col sm="1">{user.winRate}</Col>
          </Row>
        )
      }
    </div>
  );
}