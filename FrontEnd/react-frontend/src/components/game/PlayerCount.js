import { useGetPlayerNonAdminQuery } from "../../features/apiSlice";
import GameItem from "./GameItem";

export const PlayerList = (props) => {
  const {
    data: players,
    isLoading,
    isSuccess,
    isError,
    error,
  } = useGetPlayerNonAdminQuery();

  let content;
  if (isLoading) {
    content = <h1>Loading players</h1>;
  } else if (isSuccess) {
    let gamePlayerCount = 0;
    players.forEach((player) => {
      if (player.game === props.gameId) gamePlayerCount++;
    });
    content = <h1>Number of Players: {gamePlayerCount}.</h1>;
  } else if (isError) {
    content = <h1>{error.toString()}</h1>;
  }

  return <div>{content}</div>;
};
