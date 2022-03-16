import React, { useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
// omit other imports
import { fetchGames, selectAllGames } from "../../features/gameSlice";

export const GameList = () => {
  const dispatch = useDispatch();
  const games = useSelector(selectAllGames);

  const gameStatus = useSelector((state) => state.games.status);

  useEffect(() => {
    if (gameStatus === "idle") {
      dispatch(fetchGames());
    }
  }, [gameStatus, dispatch]);

  return <h1>{gameStatus}</h1>;
};
