import { useGetPlayerNonAdminQuery } from "../../features/apiSlice";
import GameItem from "./GameItem";

export const PlayerList = () => {
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
    content = <h1>Player List console.log() </h1>;
    players.map((player) => console.log(player)) //<GameItem key={player.id} player={player} />);
  } else if (isError) {
    content = <h1>{error.toString()}</h1>;
  }

  return <div>{content}</div>;
};
