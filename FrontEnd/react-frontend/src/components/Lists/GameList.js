import React, { useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
// omit other imports
import { fetchGames, selectAllGames } from "../../features/gameSlice";
import GameItem from "../HtmlItems/GameItem"

export const GameList = () => {
  const dispatch = useDispatch();
  const games = useSelector(selectAllGames);

  const gameStatus = useSelector((state) => state.games.status);
  const gameList = useSelector((state) => state.games);
  
  
  //console.log(gameList.games)
  
  

  useEffect(() => {
    if (gameStatus === "idle") {
      dispatch(fetchGames());
    }
  }, [gameStatus, dispatch]);

  if(gameStatus !== "success"){
    return <h1>{gameStatus}</h1>;
  }



  return <>{ gameList.games.map(game => <GameItem key={game.id} game={ game } />) } </>
};
