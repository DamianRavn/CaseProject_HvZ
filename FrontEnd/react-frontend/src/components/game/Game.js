import { useGetGameQuery } from "../../features/apiSlice";
import { useParams } from "react-router-dom";
import React from "react";

export const Game = () => {
  const { gameId } = useParams();

  const { data: game, isFetching, isSuccess } = useGetGameQuery(gameId);

  const handleJoinGame = () => {
    alert("Join Game has been pushed.")
    //navigator("/");
  };

  let content;
  if (isFetching) {
    content = <h1>Loading game data</h1>;
  } else if (isSuccess) {
    content = (
      <div>
        <h1>Game name: {game.name}</h1>
        <h1>Game status: {game.gameState}</h1>
        <h1>Game admin: {game.admin}</h1>
        {game.gameState === "Registration" &&
        <>
        <br></br>
        <button className="btn" onClick={handleJoinGame}>
        Join Game
        </button>
        </>
      }
      </div>
    );
  }
  return (
    <>
      <div>{content}</div>
    </>
  );
};
