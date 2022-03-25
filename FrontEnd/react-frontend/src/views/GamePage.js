import { Game } from '../components/game/Game.js'
import { PlayerList } from "../components/game/PlayerList"
import { useGetGameQuery } from "../features/apiSlice";
import { useNavigate } from 'react-router-dom'
import { useParams } from 'react-router-dom'
import KeycloakService from '../services/KeycloakService'
import { useEffect } from 'react'
import React, { useState } from "react";

const GamePage = (pr) => {
  const navigator = useNavigate();

  let [content, setContent] = useState(<Game/>);
  
  const { gameId } = useParams();
  const { data: game, isFetching, isSuccess } = useGetGameQuery(gameId);

  
  const gotoGameRegistration = () => {
    navigator('/gamereg')
  }

  const gotoAdmin = () => {
    navigator('/admin')
  }
  
  const displayDescription = () => {
    setContent(<Game/>)
  };

  const displayPlayersInfo = () => {
    setContent(<>
    <h1>Players:</h1>
    <PlayerList ids={game.players} />
    </>
    )
    
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
  )
}

export default GamePage
