import React, { useState } from 'react';
import SelectedDropdown from './SelectedDropdown';

export default function FetchData() {
  // const [MoveStateId, setMoveStateId] = useState('');
  // const [StateIdTo, setStateIdTo] = useState('');
  // const [StateIdFrom, setStateIdFrom] = useState('');
  // const [MoveState, useMoveState] = useState('');

  // handleTravelReport = (event) => {
  //   setStateIdTo(event.target.value);
  //   setStateIdFrom(event.target.value);
  //   setMoveState(event.target.value);
  // }
  
  // updateReport = (event) => {
  //   event.preventDefault();
  //   setStateIdTo(IdTo);
  //   setStateIdFrom(IdFrom)
  //   setMoveState(MoveState);
  //   setStateIdTo("");
  //   setValue("");
  //   setMoveState("");
  // }
  // fetch('api/SampleData/WeatherForecasts')
  //   .then(response => response.json())
  //   .then(data => {
  //     this.setState({ forecasts: data, loading: false });
  //   });
  return (
    <div>
     <p style={{ color: 'red' }}>Hello, I bet you aren't from here! I'm not either! </p>
      <div>
        <SelectedDropdown />
        {/* <input type="text" value={input} onChange={handleInput} />
        <button onClick={updateName}>Save</button> */}
      </div>
    </div>
  );
}
