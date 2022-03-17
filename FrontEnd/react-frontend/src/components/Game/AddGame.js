import React, { useState } from "react";
import { useSelector } from "react-redux";
import { useAddNewGameMutation } from "../../features/apiSlice";

export const AddGame = () => {
  const [name, setName] = useState("");
  const [gameState, setGameState] = useState("");
  const [admin, setAdmin] = useState("");

  const [addNewGame, { isLoading }] = useAddNewGameMutation();

  const onNameChanged = (e) => setName(e.target.value);
  const onGameStateChanged = (e) => setGameState(e.target.value);
  const onAdminChanged = (e) => setAdmin(e.target.value);

  const canSave = [name, gameState, admin].every(Boolean) && !isLoading;

  const onSaveGameClicked = async () => {
    if (canSave) {
      try {
        await addNewGame({ name, gameState, admin }).unwrap();
        setName("");
        setGameState("");
        setAdmin("");
      } catch (err) {
        console.error("Failed to save the game: ", err);
      }
    }
  };

  return (
    <section>
      <h2>Add a New Game</h2>
      <form>
        <label htmlFor="gameTitle">Post Title:</label>
        <input
          type="text"
          id="gameTitle"
          name="gameTitle"
          placeholder="Enter your game name!"
          value={name}
          onChange={onNameChanged}
        />
        <label htmlFor="gameState">State:</label>
        <input
          type="text"
          id="gameState"
          name="gameState"
          placeholder="Just made!"
          value={gameState}
          onChange={onGameStateChanged}
        />
        <label htmlFor="admin">Admin:</label>
        <input
          type="text"
          id="admin"
          name="admin"
          placeholder="1"
          value={admin}
          onChange={onAdminChanged}
        />
        <div
          style={{
            display: "flex",
            alignItems: "center",
          }}
        >
          <button type="button" onClick={onSaveGameClicked} disabled={!canSave}>
            Save Game
          </button>
        </div>
      </form>
    </section>
  );
};
