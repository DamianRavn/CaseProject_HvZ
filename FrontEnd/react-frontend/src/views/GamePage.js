import { Game } from "../components/game/Game.js";
import { useNavigate } from "react-router-dom";
import { useParams } from "react-router-dom";
import React, { useState } from "react";




const GamePage = (pr) => {

  let [content, setContent] = useState(<Game/>);



  const navigator = useNavigate();
  const { gameId } = useParams();

  const gotoGameRegistration = () => {
    navigator("/gamereg");
  };

  const displayDescription = () => {
    setContent(<Game/>)
  };

  const displayPlayersInfo = () => {
    setContent(<h1>playerInfo</h1>)
  };

  const displayRules = () => {
    setContent(<h1>Rules</h1>)
  };

  const displayMap = () => {
    setContent(<h1>Map</h1>)
    
  };

  

  return (
    <div className="default-class">
      <div className="font-semibold">
        <div className="text-4xl">
          <h1>Game Page</h1>
        </div>
      </div>
      <br></br>

      
      <button className="btn" onClick={displayDescription}>
        Game Description
      </button>
      <button className="btn" onClick={displayPlayersInfo}>
        Players Info
      </button>
      <button className="btn" onClick={displayRules}>
        Rules
      </button>
      <button className="btn" onClick={displayMap}>
        Map
      </button>

      
        <div>{content}</div>
      

      

      <button className="btn" onClick={gotoGameRegistration}>
        Go Back
      </button>
      
    </div>
  );
};

export default GamePage;
