import { Link } from 'react-router-dom'

const GameItem = (prop) => {
  return (
    <div className="bg-blue w-full p-8 flex justify-center">
      <div className="rounded bg-grey-light w-64 p-2">
        <div className="text-center mt-2">
          <Link to={`/game/${prop.game.id}`}>
            {' '}
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

          <div className="bg-white p-2 rounded mt-1 border-b border-grey">
            <button> Do we want a button here for participation?</button>
            <div className="text-grey-darker mt-2 ml-2 flex justify-between items-start"></div>
          </div>
        </div>
      </div>
    </div>
  )
}
export default GameItem
