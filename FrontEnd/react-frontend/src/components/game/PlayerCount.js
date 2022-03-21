import { useGetPlayerNonAdminQuery } from "../../features/apiSlice";

export const PlayerCount = (props) => {
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
    content = <>{gamePlayerCount}</>;
  } else if (isError) {
    content = <h1>{error.toString()}</h1>;
  }

  return <>{content}</>;
};
