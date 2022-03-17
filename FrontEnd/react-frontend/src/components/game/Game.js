import { useGetGameQuery } from "../../features/apiSlice";
import { useParams } from "react-router-dom";

export const Game = () => {
  const { gameId } = useParams();

  const { data: game, isFetching, isSuccess } = useGetGameQuery(gameId);

  let content;
  if (isFetching) {
    content = <h1>Loading game data</h1>;
  } else if (isSuccess) {
    content = (
      <div>
        <h1>Game name: {game.name}</h1>
        <h1>Game status: {game.gameState}</h1>
        <h1>Game admin: {game.admin}</h1>
      </div>
    );
  }
  return <div>{content}</div>;
};
