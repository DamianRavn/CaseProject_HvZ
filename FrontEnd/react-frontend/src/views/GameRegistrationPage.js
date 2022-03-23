import { useNavigate } from "react-router-dom";
import { GameList } from "../components/game/GameList";

const GameRegistrationPage = () => {
  const navigator = useNavigate();

  const gotoLanding = () => {
    navigator("/");
  };

  const gotoCreateNewGamePage = () => {
    navigator("/newgame");
  };

  return (
    <div className="default-class">
      <div className="font-semibold">
        <div className="text-4xl">
          <h1>Game Registration Page</h1>
        </div>
        <div className="text-3xl">
          <h1>You are signed in</h1>
        </div>
      </div>
      <br></br>

      <button className="btn" onClick={gotoLanding}>
        Log Out
      </button>

      <button className="btn" onClick={gotoCreateNewGamePage}>
        Create New Game
      </button>
      Button takes you to /newgame


      <br></br>
      <GameList></GameList>
      <br></br>

      

    </div>
  );
};

export default GameRegistrationPage;
