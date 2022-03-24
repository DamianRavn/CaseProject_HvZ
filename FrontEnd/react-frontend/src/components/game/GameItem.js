import { Link } from "react-router-dom";
import KeycloakService from "../../services/KeycloakService";

const GameItem = (prop) => {
  const handleJoinGame = () => {
    alert("Join Game has been pushed.");
    //navigator("/");
  };
  

  if (KeycloakService.isLoggedIn()) {
    localStorage.setItem("access-token", KeycloakService.getToken());
    return (
      <div className="bg-blue w-full p-8 flex justify-center">
        <div className="rounded-md bg-grey-light w-64 p-2 border border-black">
          <div className="text-center mt-2 border-b hover:bg-gray-400 rounded">
            <Link to={`/game/${prop.game.id}`}>
              {" "}
              <h2 className="font-bold">{prop.game.name}</h2>
            </Link>
          </div>
          <div className="text-center mt-2">
            <div className="bg-white p-2 rounded mt-1 border-b border-grey">
              <p>
                Game state <b>{prop.game.gameState}</b>
              </p>
            </div>

            <div className="bg-white p-2 rounded mt-1 border-b border-grey">
              <p>
                Number of players <b>{prop.game.players.length}</b>
              </p>
            </div>

            <div className="bg-white p-2 rounded mt-1">
              <button className="btn" onClick={handleJoinGame}>
                Join Game
              </button>
              <div className="text-grey-darker mt-2 ml-2 flex justify-between items-start"></div>
            </div>
          </div>
        </div>
      </div>
    );
  }

  return (
    <div className="bg-blue w-full p-8 flex justify-center">
      <div className="rounded-md bg-grey-light w-64 p-2 border border-black">
        <div className="text-center mt-2 border-b">
          <Link to={`/game/${prop.game.id}`}>
            {" "}
            <h2 className="font-bold">{prop.game.name}</h2>
          </Link>
        </div>
        <div className="text-center mt-2">
          <div className="bg-white p-2 rounded mt-1 border-b border-grey">
            <p>
              Game state <b>{prop.game.gameState}</b>
            </p>
          </div>

          <div className="bg-white p-2 rounded mt-1">
            <p>
              Number of players <b>{prop.game.players.length}</b>
            </p>
          </div>
        </div>
      </div>
    </div>
  );
};
export default GameItem;
