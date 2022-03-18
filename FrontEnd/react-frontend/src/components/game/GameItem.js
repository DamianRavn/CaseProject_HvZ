import { Link } from "react-router-dom";
import { PlayerList } from "./PlayerCount";

const GameItem = (prop) => {
  return (
    <div className="default-class">
      <br></br>
      <ul>
        <div className="text-2xl">
          <Link to={`/game/${prop.game.id}`}>Game name: {prop.game.name}</Link>
        </div>

        <li>
          Game state: <a className="font-semibold">{prop.game.gameState}</a>
        </li>
        <li>
          <a className="font-semibold">
            <PlayerList gameId={prop.game.id}></PlayerList>
          </a>
        </li>
      </ul>
    </div>
  );
};
export default GameItem;
