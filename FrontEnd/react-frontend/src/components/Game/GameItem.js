import { Link } from "react-router-dom";

const GameItem = (prop) => {
  return (
    <div className="default-class">
      <br></br>
      <ul>
        <div className="text-2xl">
          <Link to={`/games/${prop.game.id}`}>Game name: {prop.game.name}</Link>
          Game name:
        </div>

        <li>
          Game state: <a className="font-semibold">{prop.game.gameState}</a>
        </li>
        <li>
          Admin ID: <a className="font-semibold">{prop.game.admin}</a>
        </li>
      </ul>
    </div>
  );
};
export default GameItem;
