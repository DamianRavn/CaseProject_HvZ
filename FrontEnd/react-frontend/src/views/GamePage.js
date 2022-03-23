import { Game } from "../components/game/Game.js";
import { useNavigate } from "react-router-dom";
import { useParams } from "react-router-dom";




const GamePage = () => {
  const navigator = useNavigate();
  const { gameId } = useParams();

  
  console.log("gameId:")
  console.log(gameId)

  const gotoGameRegistration = () => {
    navigator("/gamereg");
  };

  const gotoLanding = () => {
    navigator("/");
  };

  const gotoAdmin = () => {
    navigator("/admin");
  };

  return (
    <div className="default-class">
      <div className="font-semibold">
        <div className="text-4xl">
          <h1>Game Page</h1>
        </div>
      </div>
      <br></br>

      <button className="btn" onClick={gotoGameRegistration}>
        Go Back
      </button>

      <Game></Game>
      
    </div>
  );
};

export default GamePage;
