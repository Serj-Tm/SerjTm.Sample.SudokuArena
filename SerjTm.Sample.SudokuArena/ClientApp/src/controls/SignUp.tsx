import React, { useState } from 'react';
import { User_Name } from '../models/arena';
import { Input, Button } from 'reactstrap';


export function SignUp({ setUser }: SignUpProps) {
  const [userName, setUserName] = useState('');

  return (
    <div>
      Представьтесь, пожалуйста <br />
      <Input value={userName} onChange={e => setUserName(e.target.value)} /><br />
      <Button disabled={userName == ''} onClick={e => setUser({ name: userName })}>Fight!</Button>
    </div>

  );
}



export interface SignUpProps {
  setUser: (user: User_Name) => void;
}

