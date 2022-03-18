import { useGetPlayerNonAdminQuery } from "../../features/apiSlice";
import GameItem from "./GameItem";

export const PlayerList = (gameId) => {
  const {
    data: players,
    isLoading,
    isSuccess,
    isError,
    error,
  } = useGetPlayerNonAdminQuery();

  // let gameId = 1;
  let content;
  if (isLoading) {
    content = <h1>Loading players</h1>;
  } else if (isSuccess) {
    let gamePlayerCount = 0
    players.forEach(player => {
      if(player.game === gameId) gamePlayerCount++ 
    });
    console.log("Total number of players in Game " + gameId + ": " + gamePlayerCount) 
    content = <h1>Players in game {gameId}: {gamePlayerCount}.</h1>;
  } else if (isError) {
    content = <h1>{error.toString()}</h1>;
  }

  return <div>{content}</div>;
};
