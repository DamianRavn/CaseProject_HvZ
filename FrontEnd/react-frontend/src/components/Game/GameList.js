import { useGetGamesQuery } from "../../features/apiSlice";
import GameItem from "./GameItem";

export const GameList = () => {
  const {
    data: games,
    isLoading,
    isSuccess,
    isError,
    error,
  } = useGetGamesQuery();

  let content;
  if (isLoading) {
    content = <h1>Loading games</h1>;
  } else if (isSuccess) {
    content = games.map((game) => <GameItem key={game.id} game={game} />);
  } else if (isError) {
    content = <h1>{error.toString()}</h1>;
  }

  return <div>{content}</div>;
};
