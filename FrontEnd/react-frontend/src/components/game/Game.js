import {
  useAddNewPlayerMutation,
  useGetGameQuery,
} from '../../features/apiSlice'
import { useParams } from 'react-router-dom'
import { PlayerList } from './PlayerList'
import React from 'react'
import { AddPlayer } from './AddPlayer'
import { useState } from 'react'

export const Game = () => {
  const { gameId } = useParams()

  const { data: game, isFetching, isSuccess } = useGetGameQuery(gameId)

  const [isRegistered, setRegistered] = useState(false)

  const handleJoinGame = () => {
    setRegistered(true)
  }

  let content
  if (isFetching) {
    content = <h1>Loading game data</h1>
  } else if (isSuccess) {
    content = (
      <div>
        <h1>Game name: {game.name}</h1>
        <h1>Game status: {game.gameState}</h1>
        <h1>Game admin: {game.admin}</h1>
        <h1>Players:</h1>
        <PlayerList ids={game.players} />
        {game.gameState === 'Registration' && (
          <button className="btn" onClick={handleJoinGame}>
            Join Game
          </button>
        )}
        {isRegistered && <AddPlayer />}
      </div>
    )
  }
  return (
    <>
      <div>{content}</div>
    </>
  )
}
